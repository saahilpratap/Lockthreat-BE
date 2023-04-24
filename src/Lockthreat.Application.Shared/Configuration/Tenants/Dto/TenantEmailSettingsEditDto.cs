using Abp.Auditing;
using Lockthreat.Configuration.Dto;

namespace Lockthreat.Configuration.Tenants.Dto
{
    public class TenantEmailSettingsEditDto : EmailSettingsEditDto
    {
        public bool UseHostDefaultEmailSettings { get; set; }
    }
}