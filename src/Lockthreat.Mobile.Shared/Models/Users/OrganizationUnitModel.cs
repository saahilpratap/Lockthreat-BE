using Abp.AutoMapper;
using Lockthreat.Organizations.Dto;

namespace Lockthreat.Models.Users
{
    [AutoMapFrom(typeof(OrganizationUnitDto))]
    public class OrganizationUnitModel : OrganizationUnitDto
    {
        public bool IsAssigned { get; set; }
    }
}