using Abp.Domain.Repositories;
using Abp.DynamicEntityParameters;
using AutoMapper;
using Lockthreat.Countries.Dto;
using Lockthreat.DynamicEntityParameters.Dto;
using Lockthreat.Meetings.Dto;
using Lockthreat.OrganizationSetup.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lockthreat.Countries
{
    public class CountriesAppservice : LockthreatAppServiceBase, ICountriesAppservice
    {

        private readonly IRepository<DynamicParameterValue> _DynamicParameterValueRepository;
        private readonly IRepository<DynamicParameter> _dynamicParameterManager;

        public CountriesAppservice(
          IRepository<DynamicParameterValue> DynamicParameterValueRepository,
          IRepository<DynamicParameter> dynamicParameterManager
          )
        {
            _DynamicParameterValueRepository = DynamicParameterValueRepository;
            _dynamicParameterManager = dynamicParameterManager;
        }
        public async Task<List<CountryDto>> GetAll()
        {

            var getCountries = new List<CountryDto>();
            try
            {
                var getcheckId = _dynamicParameterManager.FirstOrDefault(x => x.ParameterName.ToLower().Trim() == "country");
                if (getcheckId != null)
                {
                    getCountries = await _DynamicParameterValueRepository.GetAll()
                       .Where(l => l.DynamicParameterId == getcheckId.Id)
                        .Select(x => new CountryDto()
                        {
                            Id = x.Id,
                            Name = x.Value,
                        }).ToListAsync();

                    return getCountries;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return getCountries;
        }
        public async Task<List<GetDynamicValueDto>> GetAllConfidentiality()
        {
            var getconfidentiality = new List<GetDynamicValueDto>();
            try
            {
                var getcheckId = _dynamicParameterManager.FirstOrDefault(x => x.ParameterName.ToLower().Trim() == "confidentiality");
                if (getcheckId != null)
                {

                    var getConfidentiality = await _DynamicParameterValueRepository.GetAll().Where(l => l.DynamicParameterId == getcheckId.Id).ToListAsync();

                    if (getConfidentiality.Count() != 0)
                    {
                        getconfidentiality = ObjectMapper.Map<List<GetDynamicValueDto>>(getConfidentiality);
                    }
                    return getconfidentiality;

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return getconfidentiality;
        }
        public async Task<List<GetDynamicValueDto>> GetAllServiceType()
        {
            var getserviceTypes = new List<GetDynamicValueDto>();
            try
            {
                var getcheckId = _dynamicParameterManager.FirstOrDefault(x => x.ParameterName.ToLower().Trim() == "service type");
                if (getcheckId != null)
                {

                    var getserviceType = await _DynamicParameterValueRepository.GetAll().Where(l => l.DynamicParameterId == getcheckId.Id).ToListAsync();

                    if (getserviceType.Count() != 0)
                    {
                        getserviceTypes = ObjectMapper.Map<List<GetDynamicValueDto>>(getserviceType);
                    }
                    return getserviceTypes;

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return getserviceTypes;
        }
        public async Task<List<GetDynamicValueDto>> GetAllIntergrity()
        {
            var getinintegrity  = new List<GetDynamicValueDto>();
            try
            {
                var getcheckId = _dynamicParameterManager.FirstOrDefault(x => x.ParameterName.ToLower().Trim() == "integrity");
                if (getcheckId != null)
                {

                    var getConfidentiality = await _DynamicParameterValueRepository.GetAll().Where(l => l.DynamicParameterId == getcheckId.Id).ToListAsync();

                    if (getConfidentiality.Count() != 0)
                    {
                        getinintegrity = ObjectMapper.Map<List<GetDynamicValueDto>>(getConfidentiality);
                    }
                    return getinintegrity;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return getinintegrity;
        }
        public async Task<List<GetDynamicValueDto>> GetAllOthers()
        {
            var getothers = new List<GetDynamicValueDto>();
            try
            {
                var getcheckId = _dynamicParameterManager.FirstOrDefault(x => x.ParameterName.ToLower().Trim() == "others");
                if (getcheckId != null)
                {

                    var getother = await _DynamicParameterValueRepository.GetAll().Where(l => l.DynamicParameterId == getcheckId.Id).ToListAsync();

                    if (getother.Count() != 0)
                    {
                        getothers = ObjectMapper.Map<List<GetDynamicValueDto>>(getother);
                    }
                    return getothers;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return getothers;
        }
        public async Task<List<GetDynamicValueDto>> GetAvailibility()
        {
            var getavailibility = new List<GetDynamicValueDto>();
            try
            {
                var getcheckId = _dynamicParameterManager.FirstOrDefault(x => x.ParameterName.ToLower().Trim() == "availibility");
                if (getcheckId != null)
                {

                    var getother = await _DynamicParameterValueRepository.GetAll().Where(l => l.DynamicParameterId == getcheckId.Id).ToListAsync();

                    if (getother.Count() != 0)
                    {
                        getavailibility = ObjectMapper.Map<List<GetDynamicValueDto>>(getother);
                    }
                    return getavailibility;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return getavailibility;
        }
        public async Task<List<DynamicNameValueDto>> GetIndustrySectors()
        {
            var getIndustrySectors = new List<DynamicNameValueDto>();
            try
            {
                var getcheckId = _dynamicParameterManager.FirstOrDefault(x => x.ParameterName.ToLower().Trim() == "industry sector");
                if (getcheckId != null)
                {

                    var getother = await _DynamicParameterValueRepository.GetAll().Where(l => l.DynamicParameterId == getcheckId.Id)
                        .Select(x => new DynamicNameValueDto()
                        {
                            Id = x.Id,
                            Name = x.Value,
                        }).ToListAsync();
                    if (getother.Count() != 0)
                    {
                        getIndustrySectors = ObjectMapper.Map<List<DynamicNameValueDto>>(getother);
                    }
                    return getIndustrySectors;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return getIndustrySectors;
        }
        public async Task<List<DynamicNameValueDto>> GetComponents()
        {
            var getComponents = new List<DynamicNameValueDto>();
            try
            {
                var getcheckId = _dynamicParameterManager.FirstOrDefault(x => x.ParameterName.ToLower().Trim() == "Components");
                if (getcheckId != null)
                {

                    var getother = await _DynamicParameterValueRepository.GetAll().Where(l => l.DynamicParameterId == getcheckId.Id)
                        .Select(x => new DynamicNameValueDto()
                        {
                            Id = x.Id,
                            Name = x.Value,
                        }).ToListAsync();

                    if (getother.Count() != 0)
                    {
                        getComponents = ObjectMapper.Map<List<DynamicNameValueDto>>(getother);
                    }
                    return getComponents;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return getComponents;
        }
        public async Task<List<GetDynamicValueDto>> GetAllGrade()
        {
            var getallgrade  = new List<GetDynamicValueDto>();
            try
            {
                var getcheckId = _dynamicParameterManager.FirstOrDefault(x => x.ParameterName.ToLower().Trim() == "employee grade");
                if (getcheckId != null)
                {

                    var getother = await _DynamicParameterValueRepository.GetAll().Where(l => l.DynamicParameterId == getcheckId.Id).ToListAsync();

                    if (getother.Count() != 0)
                    {
                        getallgrade = ObjectMapper.Map<List<GetDynamicValueDto>>(getother);
                    }
                    return getallgrade;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return getallgrade;
        }            
        public async Task<List<GetDynamicValueDto>> GetAllUserType()
        {

            var getalluser = new List<GetDynamicValueDto>();
            try
            {
                var getcheckId = _dynamicParameterManager.FirstOrDefault(x => x.ParameterName.ToLower().Trim() == "user type");
                if (getcheckId != null)
                {

                    var getother = await _DynamicParameterValueRepository.GetAll().Where(l => l.DynamicParameterId == getcheckId.Id).ToListAsync();

                    if (getother.Count() != 0)
                    {
                        getalluser = ObjectMapper.Map<List<GetDynamicValueDto>>(getother);
                    }
                    return getalluser;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return getalluser;
        }
        public async Task<List<GetDynamicValueDto>> GetAllStrategicGoal()
        {
            var getAllGoal  = new List<GetDynamicValueDto>();
            try
            {
                var getcheckId = _dynamicParameterManager.FirstOrDefault(x => x.ParameterName.ToLower().Trim() == "strategic goal");
                if (getcheckId != null)
                {

                    var getgoal  = await _DynamicParameterValueRepository.GetAll().Where(l => l.DynamicParameterId == getcheckId.Id).ToListAsync();
                    if (getgoal.Count() != 0)
                    {
                        getAllGoal = ObjectMapper.Map<List<GetDynamicValueDto>>(getgoal);
                    }
                    return getAllGoal;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return getAllGoal;

        }
        public async Task<List<GetDynamicValueDto>> GetAllStrategicType()
        {
            var getAllStrategicType   = new List<GetDynamicValueDto>();
            try
            {
                var getcheckId = _dynamicParameterManager.FirstOrDefault(x => x.ParameterName.ToLower().Trim() =="strategic type");
                if (getcheckId != null)
                {

                    var getStrategicType = await _DynamicParameterValueRepository.GetAll().Where(l => l.DynamicParameterId == getcheckId.Id).ToListAsync();

                    if (getStrategicType.Count() != 0)
                    {
                        getAllStrategicType = ObjectMapper.Map<List<GetDynamicValueDto>>(getStrategicType);
                    }
                    return getAllStrategicType;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return getAllStrategicType;
        }
        public async Task<List<GetDynamicValueDto>> GetAllStrategicStatus ()
        {
            var getAllStrategicStatus  = new List<GetDynamicValueDto>();
            try
            {
                var getcheckId = _dynamicParameterManager.FirstOrDefault(x => x.ParameterName.ToLower().Trim() == "strategic status");
                if (getcheckId != null)
                {

                    var getStrategicStatus  = await _DynamicParameterValueRepository.GetAll().Where(l => l.DynamicParameterId == getcheckId.Id).ToListAsync();

                    if (getStrategicStatus.Count() != 0)
                    {
                        getAllStrategicStatus = ObjectMapper.Map<List<GetDynamicValueDto>>(getStrategicStatus);
                    }
                    return getAllStrategicStatus;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return getAllStrategicStatus;
        }
        public async Task<List<GetDynamicValueDto>> GetAllRiskGroup()
        {
            var getAllStrategicStatus = new List<GetDynamicValueDto>();
            try
            {
                var getcheckId = _dynamicParameterManager.FirstOrDefault(x => x.ParameterName.ToLower().Trim() == "risk group");
                if (getcheckId != null)
                {

                    var getStrategicStatus = await _DynamicParameterValueRepository.GetAll().Where(l => l.DynamicParameterId == getcheckId.Id).ToListAsync();

                    if (getStrategicStatus.Count() != 0)
                    {
                        getAllStrategicStatus = ObjectMapper.Map<List<GetDynamicValueDto>>(getStrategicStatus);
                    }
                    return getAllStrategicStatus;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return getAllStrategicStatus;
        }
        public async Task<List<GetDynamicValueDto>> GetKeyRiskStatus()
        {
            var getAllKeyRiskStatus  = new List<GetDynamicValueDto>();
            try
            {
                var getcheckId = _dynamicParameterManager.FirstOrDefault(x => x.ParameterName.ToLower().Trim() == "status");
                if (getcheckId != null)
                {

                    var getKeyRiskStatus  = await _DynamicParameterValueRepository.GetAll().Where(l => l.DynamicParameterId == getcheckId.Id).ToListAsync();
                    if (getKeyRiskStatus.Count() != 0)
                    {
                        getAllKeyRiskStatus = ObjectMapper.Map<List<GetDynamicValueDto>>(getKeyRiskStatus);
                    }
                    return getAllKeyRiskStatus;
                }
            }
            catch (Exception ex)
            {
                throw;
            } 
            return getAllKeyRiskStatus;
        }
        public async Task<List<GetDynamicValueDto>> GetFrequency()
        {
            var frequencys  = new List<GetDynamicValueDto>();
            try
            {
                var getcheckId = _dynamicParameterManager.FirstOrDefault(x => x.ParameterName.ToLower().Trim() == "frequency");
                if (getcheckId != null)
                {

                    var frequency = await _DynamicParameterValueRepository.GetAll().Where(l => l.DynamicParameterId == getcheckId.Id).ToListAsync();
                    if (frequency.Count() != 0)
                    {
                        frequencys = ObjectMapper.Map<List<GetDynamicValueDto>>(frequency);
                    }
                    return frequencys;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return frequencys;
        }
        public async Task<List<GetDynamicValueDto>> GetProcessType ()
        {
            var frequencys = new List<GetDynamicValueDto>();
            try
            {
                var getcheckId = _dynamicParameterManager.FirstOrDefault(x => x.ParameterName.ToLower().Trim() == "process type");
                if (getcheckId != null)
                {

                    var frequency = await _DynamicParameterValueRepository.GetAll().Where(l => l.DynamicParameterId == getcheckId.Id).ToListAsync();
                    if (frequency.Count() != 0)
                    {
                        frequencys = ObjectMapper.Map<List<GetDynamicValueDto>>(frequency);
                    }
                    return frequencys;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return frequencys;
        }
        public async Task<List<GetDynamicValueDto>> GetSLA ()
        {
            var frequencys = new List<GetDynamicValueDto>();
            try
            {
                var getcheckId = _dynamicParameterManager.FirstOrDefault(x => x.ParameterName.ToLower().Trim() == "sla");
                if (getcheckId != null)
                {

                    var frequency = await _DynamicParameterValueRepository.GetAll().Where(l => l.DynamicParameterId == getcheckId.Id).ToListAsync();
                    if (frequency.Count() != 0)
                    {
                        frequencys = ObjectMapper.Map<List<GetDynamicValueDto>>(frequency);
                    }
                    return frequencys;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return frequencys;
        }
        public async Task<List<GetDynamicValueDto>> GetRiviewperiod ()
        {
            var frequencys = new List<GetDynamicValueDto>();
            try
            {
                var getcheckId = _dynamicParameterManager.FirstOrDefault(x => x.ParameterName.ToLower().Trim() == "riview period");
                if (getcheckId != null)
                {

                    var frequency = await _DynamicParameterValueRepository.GetAll().Where(l => l.DynamicParameterId == getcheckId.Id).ToListAsync();
                    if (frequency.Count() != 0)
                    {
                        frequencys = ObjectMapper.Map<List<GetDynamicValueDto>>(frequency);
                    }
                    return frequencys;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return frequencys;
        }
        public async Task<List<GetDynamicValueDto>> GetProcessStatus()
        {
            var frequencys = new List<GetDynamicValueDto>();
            try
            {
                var getcheckId = _dynamicParameterManager.FirstOrDefault(x => x.ParameterName.ToLower().Trim() == "process status");
                if (getcheckId != null)
                {

                    var frequency = await _DynamicParameterValueRepository.GetAll().Where(l => l.DynamicParameterId == getcheckId.Id).ToListAsync();
                    if (frequency.Count() != 0)
                    {
                        frequencys = ObjectMapper.Map<List<GetDynamicValueDto>>(frequency);
                    }
                    return frequencys;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return frequencys;
        }
        public async Task<List<GetDynamicValueDto>> GetActivity()
        {
            var frequencys = new List<GetDynamicValueDto>();
            try
            {
                var getcheckId = _dynamicParameterManager.FirstOrDefault(x => x.ParameterName.ToLower().Trim() == "activity");
                if (getcheckId != null)
                {

                    var frequency = await _DynamicParameterValueRepository.GetAll().Where(l => l.DynamicParameterId == getcheckId.Id).ToListAsync();
                    if (frequency.Count() != 0)
                    {
                        frequencys = ObjectMapper.Map<List<GetDynamicValueDto>>(frequency);
                    }
                    return frequencys;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return frequencys;

        }
        public async Task<List<GetDynamicValueDto>> GetProcessPriority ()
            {
                var frequencys = new List<GetDynamicValueDto>();
                try
                {
                    var getcheckId = _dynamicParameterManager.FirstOrDefault(x => x.ParameterName.ToLower().Trim() == "process priority");
                    if (getcheckId != null)
                    {

                        var frequency = await _DynamicParameterValueRepository.GetAll().Where(l => l.DynamicParameterId == getcheckId.Id).ToListAsync();
                        if (frequency.Count() != 0)
                        {
                            frequencys = ObjectMapper.Map<List<GetDynamicValueDto>>(frequency);
                        }
                        return frequencys;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                return frequencys;
            }
        public async Task<List<GetDynamicValueDto>> GetMeeetingType ()
        {
            var meetingtype  = new List<GetDynamicValueDto>();
            try
            {
                var getcheckId = _dynamicParameterManager.FirstOrDefault(x => x.ParameterName.ToLower().Trim() == ("Meeting Type").ToLower().Trim());
                if (getcheckId != null)
                {

                    var meetingTypes  = await _DynamicParameterValueRepository.GetAll().Where(l => l.DynamicParameterId == getcheckId.Id).ToListAsync();
                    if (meetingTypes.Count() != 0)
                    {
                        meetingtype = ObjectMapper.Map<List<GetDynamicValueDto>>(meetingTypes);
                    }
                    return meetingtype;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return meetingtype;
        }
        public async Task<List<GetDynamicValueDto>> GetMeetingClassification ()
        {
            var meetingClassifications  = new List<GetDynamicValueDto>();
            try
            {
                var getcheckId = _dynamicParameterManager.FirstOrDefault(x => x.ParameterName.ToLower().Trim() == ("Meeting Classification").ToLower().Trim());
                if (getcheckId != null)
                {

                    var meetingClassification = await _DynamicParameterValueRepository.GetAll().Where(l => l.DynamicParameterId == getcheckId.Id).ToListAsync();
                    if (meetingClassification.Count() != 0)
                    {
                        meetingClassifications = ObjectMapper.Map<List<GetDynamicValueDto>>(meetingClassification);
                    }
                    return meetingClassifications;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return meetingClassifications;
        }
        public async Task<List<GetDynamicValueDto>> GetRiskLevel()
        {
            var meetingClassifications = new List<GetDynamicValueDto>();
            try
            {
                var getcheckId = _dynamicParameterManager.FirstOrDefault(x => x.ParameterName.ToLower().Trim() == ("Risk Level").ToLower().Trim());
                if (getcheckId != null)
                {

                    var meetingClassification = await _DynamicParameterValueRepository.GetAll().Where(l => l.DynamicParameterId == getcheckId.Id).ToListAsync();
                    if (meetingClassification.Count() != 0)
                    {
                        meetingClassifications = ObjectMapper.Map<List<GetDynamicValueDto>>(meetingClassification);
                    }
                    return meetingClassifications;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return meetingClassifications;
        }
        public async Task<List<GetDynamicValueDto>> GetTaskLinked()
        {
            var meetingClassifications = new List<GetDynamicValueDto>();
            try
            {
                var getcheckId = _dynamicParameterManager.FirstOrDefault(x => x.ParameterName.ToLower().Trim() == ("Task Link To").ToLower().Trim());
                if (getcheckId != null)
                {

                    var meetingClassification = await _DynamicParameterValueRepository.GetAll().Where(l => l.DynamicParameterId == getcheckId.Id).ToListAsync();
                    if (meetingClassification.Count() != 0)
                    {
                        meetingClassifications = ObjectMapper.Map<List<GetDynamicValueDto>>(meetingClassification);
                    }
                    return meetingClassifications;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return meetingClassifications;
        }
        public async Task<List<GetDynamicValueDto>> GetTaskType ()
        {
            var meetingClassifications = new List<GetDynamicValueDto>();
            try
            {
                var getcheckId = _dynamicParameterManager.FirstOrDefault(x => x.ParameterName.ToLower().Trim() == ("Task Type").ToLower().Trim());
                if (getcheckId != null)
                {

                    var meetingClassification = await _DynamicParameterValueRepository.GetAll().Where(l => l.DynamicParameterId == getcheckId.Id).ToListAsync();
                    if (meetingClassification.Count() != 0)
                    {
                        meetingClassifications = ObjectMapper.Map<List<GetDynamicValueDto>>(meetingClassification);
                    }
                    return meetingClassifications;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return meetingClassifications;
        }
        public async Task<List<GetDynamicValueDto>> GetFacilityType()
        {
            var meetingClassifications = new List<GetDynamicValueDto>();
            try
            {
                var getcheckId = _dynamicParameterManager.FirstOrDefault(x => x.ParameterName.ToLower().Trim() == ("Facility Type").ToLower().Trim());
                if (getcheckId != null)
                {

                    var meetingClassification = await _DynamicParameterValueRepository.GetAll().Where(l => l.DynamicParameterId == getcheckId.Id).ToListAsync();
                    if (meetingClassification.Count() != 0)
                    {
                        meetingClassifications = ObjectMapper.Map<List<GetDynamicValueDto>>(meetingClassification);
                    }
                    return meetingClassifications;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return meetingClassifications;
        }
        public async Task<List<GetDynamicValueDto>> GetAssetType()
        {
            var meetingClassifications = new List<GetDynamicValueDto>();
            try
            {
                var getcheckId = _dynamicParameterManager.FirstOrDefault(x => x.ParameterName.ToLower().Trim() == ("Asset Type").ToLower().Trim());
                if (getcheckId != null)
                {

                    var meetingClassification = await _DynamicParameterValueRepository.GetAll().Where(l => l.DynamicParameterId == getcheckId.Id).ToListAsync();
                    if (meetingClassification.Count() != 0)
                    {
                        meetingClassifications = ObjectMapper.Map<List<GetDynamicValueDto>>(meetingClassification);
                    }
                    return meetingClassifications;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return meetingClassifications;
        }
        public async Task<List<GetDynamicValueDto>> GetAssetCategorys() 
        {
            var meetingClassifications = new List<GetDynamicValueDto>();
            try
            {
                var getcheckId = _dynamicParameterManager.FirstOrDefault(x => x.ParameterName.ToLower().Trim() == ("Asset Category").ToLower().Trim());
                if (getcheckId != null)
                {

                    var meetingClassification = await _DynamicParameterValueRepository.GetAll().Where(l => l.DynamicParameterId == getcheckId.Id).ToListAsync();
                    if (meetingClassification.Count() != 0)
                    {
                        meetingClassifications = ObjectMapper.Map<List<GetDynamicValueDto>>(meetingClassification);
                    }
                    return meetingClassifications;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return meetingClassifications;
        }
        public async Task<List<GetDynamicValueDto>> GetAssetLabels() 
        {
            var meetingClassifications = new List<GetDynamicValueDto>();
            try
            {
                var getcheckId = _dynamicParameterManager.FirstOrDefault(x => x.ParameterName.ToLower().Trim() == ("Asset Label").ToLower().Trim());
                if (getcheckId != null)
                {
                    var meetingClassification = await _DynamicParameterValueRepository.GetAll().Where(l => l.DynamicParameterId == getcheckId.Id).ToListAsync();
                    if (meetingClassification.Count() != 0)
                    {
                        meetingClassifications = ObjectMapper.Map<List<GetDynamicValueDto>>(meetingClassification);
                    }
                    return meetingClassifications;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return meetingClassifications;
        }
        public async Task<List<GetDynamicValueDto>> GetAuditYear()
        {
            var meetingClassifications = new List<GetDynamicValueDto>();
            try
            {
                var getcheckId = _dynamicParameterManager.FirstOrDefault(x => x.ParameterName.ToLower().Trim() == ("Fiscal Year").ToLower().Trim());
                if (getcheckId != null)
                {
                    var meetingClassification = await _DynamicParameterValueRepository.GetAll().Where(l => l.DynamicParameterId == getcheckId.Id).ToListAsync();
                    if (meetingClassification.Count() != 0)
                    {
                        meetingClassifications = ObjectMapper.Map<List<GetDynamicValueDto>>(meetingClassification);
                    }
                    return meetingClassifications;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return meetingClassifications;
        }
        public async Task<List<GetDynamicValueDto>> GetAuditArea()
        {
            var meetingClassifications = new List<GetDynamicValueDto>();
            try
            {
                var getcheckId = _dynamicParameterManager.FirstOrDefault(x => x.ParameterName.ToLower().Trim() == ("Audit Area").ToLower().Trim());
                if (getcheckId != null)
                {
                    var meetingClassification = await _DynamicParameterValueRepository.GetAll().Where(l => l.DynamicParameterId == getcheckId.Id).ToListAsync();
                    if (meetingClassification.Count() != 0)
                    {
                        meetingClassifications = ObjectMapper.Map<List<GetDynamicValueDto>>(meetingClassification);
                    }
                    return meetingClassifications;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return meetingClassifications;
        }
        public async Task<List<GetDynamicValueDto>> GetExceptionType ()
        {
            var meetingClassifications = new List<GetDynamicValueDto>();
            try
            {
                var getcheckId = _dynamicParameterManager.FirstOrDefault(x => x.ParameterName.ToLower().Trim() == ("Type").ToLower().Trim());
                if (getcheckId != null)
                {
                    var meetingClassification = await _DynamicParameterValueRepository.GetAll().Where(l => l.DynamicParameterId == getcheckId.Id).ToListAsync();
                    if (meetingClassification.Count() != 0)
                    {
                        meetingClassifications = ObjectMapper.Map<List<GetDynamicValueDto>>(meetingClassification);
                    }
                    return meetingClassifications;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return meetingClassifications;
        }
        public async Task<List<GetDynamicValueDto>> GetExceptionReviewStatus ()
        {
            var meetingClassifications = new List<GetDynamicValueDto>();
            try
            {
                var getcheckId = _dynamicParameterManager.FirstOrDefault(x => x.ParameterName.ToLower().Trim() == ("Review Status").ToLower().Trim());
                if (getcheckId != null)
                {
                    var meetingClassification = await _DynamicParameterValueRepository.GetAll().Where(l => l.DynamicParameterId == getcheckId.Id).ToListAsync();
                    if (meetingClassification.Count() != 0)
                    {
                        meetingClassifications = ObjectMapper.Map<List<GetDynamicValueDto>>(meetingClassification);
                    }
                    return meetingClassifications;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return meetingClassifications;
        }
        public async Task<List<FacilitieIdDto>> GetFacilitieId ()
        {
            var getid = new List<FacilitieIdDto>();
            try
            {
                  getid = await _DynamicParameterValueRepository.GetAll().Where(l => l.Value.ToLower().Trim() == ("Meeting and Board Room").ToLower().Trim() || ( l.Value.ToLower().Trim() == ("Offices").ToLower().Trim())).Select (x=> new FacilitieIdDto {Id=x.Id } ).ToListAsync();                                    
                  return getid;               
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<GetDynamicValueDto>> GetVendorType()
        {
            var vendorTypes = new List<GetDynamicValueDto>();
            try
            {
                var getcheckId = _dynamicParameterManager.FirstOrDefault(x => x.ParameterName.ToLower().Trim() == ("Vendor Type").ToLower().Trim());
                if (getcheckId != null)
                {
                    var vendorType  = await _DynamicParameterValueRepository.GetAll().Where(l => l.DynamicParameterId == getcheckId.Id).ToListAsync();
                    if (vendorType.Count() != 0)
                    {
                        vendorTypes = ObjectMapper.Map<List<GetDynamicValueDto>>(vendorType);
                    }
                    return vendorTypes;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return vendorTypes;
        }

        public async Task<List<GetDynamicValueDto>> GetIndustroy()
        {
            var vendorTypes = new List<GetDynamicValueDto>();
            try
            {
                var getcheckId = _dynamicParameterManager.FirstOrDefault(x => x.ParameterName.ToLower().Trim() == ("Industry").ToLower().Trim());
                if (getcheckId != null)
                {
                    var vendorType = await _DynamicParameterValueRepository.GetAll().Where(l => l.DynamicParameterId == getcheckId.Id).ToListAsync();
                    if (vendorType.Count() != 0)
                    {
                        vendorTypes = ObjectMapper.Map<List<GetDynamicValueDto>>(vendorType);
                    }
                    return vendorTypes;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return vendorTypes;
        }

        public async Task<List<GetDynamicValueDto>> GetVendorProductType()
        {
            var ProductTypes  = new List<GetDynamicValueDto>();
            try
            {
                var getcheckId = _dynamicParameterManager.FirstOrDefault(x => x.ParameterName.ToLower().Trim() == ("Product Type").ToLower().Trim());
                if (getcheckId != null)
                {
                    var ProductType  = await _DynamicParameterValueRepository.GetAll().Where(l => l.DynamicParameterId == getcheckId.Id).ToListAsync();
                    if (ProductType.Count() != 0)
                    {
                        ProductTypes = ObjectMapper.Map<List<GetDynamicValueDto>>(ProductType);
                    }
                    return ProductTypes;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return ProductTypes;
        }

        public async Task<List<GetDynamicValueDto>> GetContactType()
        {
            var ProductTypes = new List<GetDynamicValueDto>();
            try
            {
                var getcheckId = _dynamicParameterManager.FirstOrDefault(x => x.ParameterName.ToLower().Trim() == ("Contact Type").ToLower().Trim());
                if (getcheckId != null)
                {
                    var ProductType = await _DynamicParameterValueRepository.GetAll().Where(l => l.DynamicParameterId == getcheckId.Id).ToListAsync();
                    if (ProductType.Count() != 0)
                    {
                        ProductTypes = ObjectMapper.Map<List<GetDynamicValueDto>>(ProductType);
                    }
                    return ProductTypes;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return ProductTypes;
        }

        public async Task<List<GetDynamicValueDto>> GetContractType()
        {
            var ProductTypes = new List<GetDynamicValueDto>();
            try
            {
                var getcheckId = _dynamicParameterManager.FirstOrDefault(x => x.ParameterName.ToLower().Trim() == ("Contract Type").ToLower().Trim());
                if (getcheckId != null)
                {
                    var ProductType = await _DynamicParameterValueRepository.GetAll().Where(l => l.DynamicParameterId == getcheckId.Id).ToListAsync();
                    if (ProductType.Count() != 0)
                    {
                        ProductTypes = ObjectMapper.Map<List<GetDynamicValueDto>>(ProductType);
                    }
                    return ProductTypes;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return ProductTypes;
        }
        public async Task<List<GetDynamicValueDto>> GetContractCategory()
        { 
            var ProductTypes = new List<GetDynamicValueDto>();
            try
            {
                var getcheckId = _dynamicParameterManager.FirstOrDefault(x => x.ParameterName.ToLower().Trim() == ("Contract Category").ToLower().Trim());
                if (getcheckId != null)
                {
                    var ProductType = await _DynamicParameterValueRepository.GetAll().Where(l => l.DynamicParameterId == getcheckId.Id).ToListAsync();
                    if (ProductType.Count() != 0)
                    {
                        ProductTypes = ObjectMapper.Map<List<GetDynamicValueDto>>(ProductType);
                    }
                    return ProductTypes;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return ProductTypes;
        }

    }

}
