using Abp.Domain.Entities.Auditing;
using Lockthreat.BusinessServices.Dto;
using Lockthreat.DynamicEntityParameters.Dto;
using Lockthreat.GRCPrograms.Dto;
using Lockthreat.OrganizationSetup.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.KeyPerformanceIndicator.Dto
{
public  class KeyPerformanceDto : FullAuditedEntity<long>
    {

         public int? TenantId { get; set; }

         public string KeyPerformanceIndicatorId { get; set; }
       
         public string KeyPerformanceIndicatorTitle { get; set; }

         public int? StatusId { get; set; }
         public List<GetDynamicValueDto> Statuses  { get; set; }

         public int? FrequencyId { get; set; }
         public List<GetDynamicValueDto> Frequencys  { get; set; }

         public string Description { get; set; }

         public long? EmployeeId { get; set; }


          public List<BusinessUnitPrimaryDto> BusinessUnits { get; set; }

          public List<ProgramUser> ProgramUser { get; set; }
         public long? LockThreatOrganizationId { get; set; }
         public List<GetOrganizationDto> CompanyLists { get; set; }

         public List<KPIAdminisratorDto> SelectedAdministrators  { get; set; }

         public List<long> RemoveAdministrators { get; set; }

         public List<KPIBusinessUnitDto> SelectedBusinessUnits  { get; set; }

         public List<long> RemoveBusinessUnits { get; set; } 

    }

    public class KPIAdminisratorDto
    {
        public long Id { get; set; }
        public long? KeyPerformanceIndicatorId { get; set; }

        public long? EmployeeId { get; set; }

    }

    public class KPIBusinessUnitDto
    {
        public long Id { get; set; } 
        public long? KeyPerformanceIndicatorId { get; set; }
        public long? BusinessUnitId { get; set; }
    }

}
