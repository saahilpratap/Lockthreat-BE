using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Lockthreat.Common;
using Lockthreat.Countries;
using Lockthreat.GRCPrograms.Dto;
using Lockthreat.Meetings.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Linq.Extensions;
using System.Linq.Dynamic.Core;
using Lockthreat.FacilitieDatacenters;
using Lockthreat.HardwareAssets.Dto;
using Abp.Extensions;

namespace Lockthreat.Meetings
{
  public class MeetingAppService : LockthreatAppServiceBase,IMeetingAppService
    {
        private readonly IRepository<Meeting, long> _meetingRepository;
        private readonly ICountriesAppservice _countriesAppservice;
        private readonly ICodeGeneratorCommonAppservice _codegeneratorRepository;
        private readonly IRepository<Employees.Employee, long> _employessRepository;
        private readonly IRepository<MeetingAttendUser, long> _meetingattenduserRepository;
        private readonly IRepository<MeetingAbsenteeUser, long> _meetingabsentRepository;
        private readonly IRepository<FacilitieDatacenter, long> _facilitiesDataCenterRepository;
        public MeetingAppService (
           IRepository<FacilitieDatacenter, long> facilitiesDataCenterRepository,
           IRepository<Meeting, long> meetingRepository,
           IRepository<MeetingAttendUser, long>  meetingattenduserRepository,
           IRepository<MeetingAbsenteeUser, long> meetingabsentRepository,
           ICodeGeneratorCommonAppservice codegeneratorRepositor,
           ICountriesAppservice countriesAppservice,
           IRepository<Employees.Employee, long> employessRepository
           )
        {
            _facilitiesDataCenterRepository = facilitiesDataCenterRepository;
            _meetingRepository = meetingRepository;
            _meetingabsentRepository = meetingabsentRepository;
            _meetingattenduserRepository = meetingattenduserRepository;
            _codegeneratorRepository = codegeneratorRepositor;
            _countriesAppservice = countriesAppservice;
            _employessRepository = employessRepository;
        }

        public async Task<PagedResultDto<MeetingListDto>> GetAllMeetingList (MeetingInput  input)
        {
            try
            {
                var query = _meetingRepository.GetAllIncluding(x=>x.Organizer, y=>y.MeetingClassification, Z=>Z.MeetingType, xx=>xx.Employee)
                  .WhereIf(!input.Filter.IsNullOrWhiteSpace(), u => u.MeetingId.Contains(input.Filter.Trim()) || u.MeetingTitle.Contains(input.Filter.Trim()) ||
                        u.Organizer.Name.Contains(input.Filter.Trim()) || u.MeetingClassification.Value.Contains(input.Filter.Trim()) ||
                        u.Employee.Name.Contains(input.Filter.Trim()));


                var meetingCount = await query.CountAsync();
                var meetingitem = await query
                    .OrderBy(input.Sorting)
                    .PageBy(input)
                    .ToListAsync();

                var meetingDtos = ObjectMapper.Map<List<MeetingListDto>>(meetingitem);
                return new PagedResultDto<MeetingListDto>(
                   meetingCount,
                   meetingDtos.ToList()
                   );
            }
            catch(Exception ex)
            {
                throw;
            }

        }
        public async Task<MeetingInfoDto> GetMeetingInfo (long? MeetingId )
        {
            try
            {
                var Meetings  = new MeetingInfoDto();
                var MeetingInfo  = new Meeting();

                if (MeetingId > 0)
                {
                    MeetingInfo = await _meetingRepository.GetAll().FirstOrDefaultAsync(p => p.Id == MeetingId);
                }

                if (MeetingInfo.Id > 0)
                {
                    Meetings = ObjectMapper.Map<MeetingInfoDto>(MeetingInfo);
                    Meetings.SelectedMeetingAbsenteeUsers = ObjectMapper.Map<List<MeetingAbsenteeUserDto>>(await _meetingabsentRepository.GetAll().Where(p => p.MeetingId == MeetingInfo.Id).ToListAsync());
                    Meetings.SelectedMeetingAttendUsers = ObjectMapper.Map<List<MeetingAttendUserDto>>(await _meetingattenduserRepository.GetAll().Where(p => p.MeetingId == MeetingInfo.Id).ToListAsync());
                }
              
                var employees = await _employessRepository.GetAll().Include(e => e.LockThreatOrganization).ToListAsync();
                Meetings.EmployeeLists = ObjectMapper.Map<List<ProgramUser>>(employees);
                Meetings.EmployeeOrganizerLists = ObjectMapper.Map<List<ProgramUser>>(employees);
                Meetings.Countries= await _countriesAppservice.GetAll();
                List<FacilitieIdDto> checkid = await _countriesAppservice.GetFacilitieId();
                if (checkid.Count > 0)
                {
                    if (checkid.Count == 1)
                    {
                        Meetings.MeetingLocationList = ObjectMapper.Map<List<FacilitieDatacenterListDto>>(await _facilitiesDataCenterRepository.GetAll().Where(x => x.FacilityTypeId == checkid[0].Id).ToListAsync());
                    }
                    else
                    {
                        Meetings.MeetingLocationList = ObjectMapper.Map<List<FacilitieDatacenterListDto>>(await _facilitiesDataCenterRepository.GetAll().Where(x => x.FacilityTypeId == checkid[0].Id || (x.FacilityTypeId == checkid[1].Id)).ToListAsync());
                    }
                }
                Meetings.MeetingTypes = await _countriesAppservice.GetMeeetingType();
                Meetings.MeetingClassifications = await _countriesAppservice.GetMeetingClassification();               
                return Meetings;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task CreateorUpdateMeeting (MeetingInfoDto input)
        {
            try
            {
                if (string.IsNullOrEmpty(input.MeetingId))
                {
                    input.MeetingId = _codegeneratorRepository.GetNextId(LockthreatConsts.MOM, "MOM");
                }

                input.TenantId = AbpSession.TenantId;

                if (input.Id > 0)
                {
                    if (input.RemoveMeetingAttendUsers != null)
                    {
                        foreach (var user  in input.RemoveMeetingAttendUsers)
                        {
                            bool exist = _meetingattenduserRepository.GetAll().Any(t => t.Id == user);
                            if (exist)
                            {
                                await RemoveMeetingAttendUsers(user);
                            }
                        }
                    }

                    if (input.RemoveMeetingAbsenteeUsers != null)
                    {
                        foreach (var absentuser  in input.RemoveMeetingAbsenteeUsers)
                        {
                            bool exist = _meetingabsentRepository.GetAll().Any(t => t.Id == absentuser);
                            if (exist)
                            {
                                await RemoveMeetingAbsenteeUsers(absentuser);
                            }
                        }
                    }
                }

                await _meetingRepository.InsertOrUpdateAsync(ObjectMapper.Map<Meeting>(input));

                if (input.Id == 0)
                {
                    await _codegeneratorRepository.CodeCreate(LockthreatConsts.MOM, "MOM");
                }



            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task RemoveMeetingAttendUsers (long id)
        {
            try
            {
                var keyadminstrator = await _meetingattenduserRepository.FirstOrDefaultAsync(a => a.Id == id);
                await _meetingattenduserRepository.DeleteAsync(keyadminstrator);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task RemoveMeetingAbsenteeUsers (long id)
        {
            try
            {
                var businessunit = await _meetingabsentRepository.FirstOrDefaultAsync(a => a.Id == id);
                await _meetingabsentRepository.DeleteAsync(businessunit);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task RemoveMeetings (long MeetingId)
        {
            try
            {
                var meeting  = await _meetingRepository.GetAll().Where(p => p.Id == MeetingId).Include(p => p.SelectedMeetingAttendUsers).Include(x => x.SelectedMeetingAbsenteeUsers).FirstOrDefaultAsync();

                if (meeting.SelectedMeetingAbsenteeUsers.Count > 0)
                {
                    foreach (var item in meeting.SelectedMeetingAbsenteeUsers)
                    {
                        await RemoveMeetingAbsenteeUsers(item.Id);
                    }
                }

                if (meeting.SelectedMeetingAttendUsers.Count > 0)
                {
                    foreach (var item in meeting.SelectedMeetingAttendUsers)
                    {
                        await RemoveMeetingAttendUsers(item.Id);
                    }
                }
                await _meetingRepository.DeleteAsync(meeting);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

       
    }
}
