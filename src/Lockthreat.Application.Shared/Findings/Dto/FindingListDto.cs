using Abp.Application.Services.Dto;
using Abp.DynamicEntityParameters;
using Lockthreat.BusinessServices.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Findings.Dto
{
  public  class FindingListDto : EntityDto<long>
    {
        public int? TenantId { get; set; }
        public string FindingId { get; set; }
        public string FindingTitle { get; set; }
        public string FindingDetails { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? CategoryId { get; set; }
        public DynamicParameterValue Category { get; set; }
        public string CategoryOther { get; set; }
        public int? FindingStatusId { get; set; }
        public DynamicParameterValue FindingStatus { get; set; }
        public int? RankingId { get; set; }
        public DynamicParameterValue Ranking { get; set; }
        public int? ClassificationId { get; set; }
        public DynamicParameterValue Classification { get; set; }
        public long? FindingManagerId { get; set; }
        public BusinessServiceOwner  FindingManager { get; set; }
        public long? FindingCoordinatorId { get; set; }
        public BusinessServiceOwner FindingCoordinator { get; set; }
        public long? FindingOwnerId { get; set; }
        public BusinessServiceOwner FindingOwner { get; set; }
        public string Criteria { get; set; }
        public string Cause { get; set; }
        public string Condition { get; set; }
        public string Consequence { get; set; }
        public int? ActionId { get; set; }
        public DynamicParameterValue Action { get; set; }
        public long? ReviewedId { get; set; }
        public BusinessServiceOwner Reviewed { get; set; }
        public int? ResponseId { get; set; }
        public DynamicParameterValue Response { get; set; }
        public int? PotentialCost { get; set; }
        public long? AssignedId { get; set; }
        public BusinessServiceOwner Assigned { get; set; }
    }
}
