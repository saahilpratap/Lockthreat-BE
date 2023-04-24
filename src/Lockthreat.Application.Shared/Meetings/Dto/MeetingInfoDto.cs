using Abp.Domain.Entities.Auditing;
using Lockthreat.Countries.Dto;
using Lockthreat.DynamicEntityParameters.Dto;
using Lockthreat.GRCPrograms.Dto;
using Lockthreat.HardwareAssets.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Meetings.Dto
{
  public  class MeetingInfoDto : FullAuditedEntity<long>
    {
        public int? TenantId { get; set; }
        public string MeetingId { get; set; }
        public string MeetingTitle { get; set; }
        public string MeetingDescription { get; set; }
        public DateTime? MeetingStartDate { get; set; }
        public DateTime? MeetingEndDate { get; set; }
        public long? MeetingvenueId { get; set; }
        public string MeetingLocation { get; set; }
        public string City { get; set; }
        public int? CountryId { get; set; }
        public List<CountryDto> Countries { get; set; }
        public string MeetingAgenda { get; set; }
        public long? EmployeeId { get; set; }
        public List<ProgramUser> EmployeeLists   { get; set; }
        public string MinutesofMeeting { get; set; }
        public string MinutesofMeetingAttachedment { get; set; }  //stores Base 64 string
        public string MeetingConclusion { get; set; }
        public long? OrganizerId { get; set; }
        public List<ProgramUser> EmployeeOrganizerLists  { get; set; }
        public int? MeetingTypeId { get; set; }
        public List<GetDynamicValueDto> MeetingTypes  { get; set; }
        public int? MeetingClassificationId { get; set; }
        public List<GetDynamicValueDto> MeetingClassifications  { get; set; }
        public List<MeetingAbsenteeUserDto> SelectedMeetingAbsenteeUsers{ get; set; }
        public List<long> RemoveMeetingAbsenteeUsers{ get; set; }
        public List<MeetingAttendUserDto> SelectedMeetingAttendUsers{ get; set; }
        public List<long> RemoveMeetingAttendUsers  { get; set; }

        public List<FacilitieDatacenterListDto> MeetingLocationList { get; set; }

    }

    public class MeetingAbsenteeUserDto
    {
        public long Id { get; set; }
        public long? MeetingId { get; set; }
        public long? EmployeeId { get; set; }
    }

    public class MeetingAttendUserDto
    {
        public long Id { get; set; }
        public long? MeetingId { get; set; }
        public long? EmployeeId { get; set; }
    }
}
