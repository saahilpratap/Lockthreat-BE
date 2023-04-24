using System.ComponentModel.DataAnnotations;
using Abp.Organizations;

namespace Lockthreat.Organizations.Dto
{
    public class UpdateOrganizationUnitInput
    {
        [Range(1, long.MaxValue)]
        public long Id { get; set; }

        [Required]
        [StringLength(OrganizationUnit.MaxDisplayNameLength)]
        public string DisplayName { get; set; }

        public virtual long? ParentId { get; set; }

    }

    public class GetLockThreatOrganizationDto 
    {
        public long Id { get; set; }
        public string CompanyName { get; set; }
        public virtual long? OrganizationUnitId { get; set; }
    }
}