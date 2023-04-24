using Abp.Application.Services;
using Lockthreat.Countries.Dto;
using Lockthreat.DynamicEntityParameters.Dto;
using Lockthreat.Meetings.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lockthreat.Countries
{
    public interface ICountriesAppservice : IApplicationService
    {
        Task<List<GetDynamicValueDto>> GetContractCategory();
        Task<List<GetDynamicValueDto>> GetContractType();
        Task<List<GetDynamicValueDto>> GetContactType();
        Task<List<CountryDto>> GetAll();

        Task<List<GetDynamicValueDto>> GetAllConfidentiality();

        Task<List<GetDynamicValueDto>> GetAllServiceType();

        Task<List<GetDynamicValueDto>> GetAllIntergrity();

        Task<List<GetDynamicValueDto>> GetAllOthers();
        Task<List<GetDynamicValueDto>> GetAvailibility();
        Task<List<DynamicNameValueDto>> GetIndustrySectors();
        Task<List<DynamicNameValueDto>> GetComponents();
        Task<List<GetDynamicValueDto>> GetAllGrade();
        Task<List<GetDynamicValueDto>> GetAllUserType();
        Task<List<GetDynamicValueDto>> GetAllStrategicGoal();

        Task<List<GetDynamicValueDto>> GetAllStrategicType();

        Task<List<GetDynamicValueDto>> GetAllStrategicStatus();

        Task<List<GetDynamicValueDto>> GetKeyRiskStatus();
        Task<List<GetDynamicValueDto>> GetFrequency();
        Task<List<GetDynamicValueDto>> GetProcessType();
        Task<List<GetDynamicValueDto>> GetSLA();
        Task<List<GetDynamicValueDto>> GetRiviewperiod();
        Task<List<GetDynamicValueDto>> GetProcessStatus();
        Task<List<GetDynamicValueDto>> GetActivity();
        Task<List<GetDynamicValueDto>> GetProcessPriority();
        Task<List<GetDynamicValueDto>> GetMeeetingType();
        Task<List<GetDynamicValueDto>> GetMeetingClassification();

        Task<List<GetDynamicValueDto>> GetRiskLevel();

        Task<List<GetDynamicValueDto>> GetTaskLinked();

        Task<List<GetDynamicValueDto>> GetTaskType();
        Task<List<GetDynamicValueDto>> GetFacilityType();
        Task<List<GetDynamicValueDto>> GetAssetType();
        Task<List<GetDynamicValueDto>> GetAssetLabels();
        Task<List<GetDynamicValueDto>> GetAssetCategorys();
        Task<List<GetDynamicValueDto>> GetAuditYear();
        Task<List<GetDynamicValueDto>> GetAuditArea();
        Task<List<FacilitieIdDto>> GetFacilitieId();
        Task<List<GetDynamicValueDto>> GetExceptionType();
        Task<List<GetDynamicValueDto>> GetExceptionReviewStatus();
        Task<List<GetDynamicValueDto>> GetVendorType();
        Task<List<GetDynamicValueDto>> GetIndustroy();
        Task<List<GetDynamicValueDto>> GetVendorProductType();
    }
}
