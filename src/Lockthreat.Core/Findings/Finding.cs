using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using Lockthreat.Employees;
using Lockthreat.FindingsInformation;
using Lockthreat.OrganizationSetups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.Findings 
{
    [Table("Findings")]
    public class Finding : FullAuditedEntity<long>, IMayHaveTenant
    {
        public int? TenantId { get; set; }
        public string FindingId  { get; set; }
        public string FindingTitle { get; set; }
        public string FindingDetails { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? CategoryId  { get; set; }
        public DynamicParameterValue Category { get; set; }
        public string CategoryOther  { get; set; }
        public int?  FindingStatusId { get; set; }
        public DynamicParameterValue FindingStatus { get; set; }
        public int? RankingId { get; set; }
        public DynamicParameterValue Ranking { get; set; }
        public int? ClassificationId  { get; set; }
        public DynamicParameterValue Classification { get; set; }
        public long? FindingManagerId { get; set; }
        public Employee FindingManager  { get; set; }
        public long? FindingCoordinatorId { get; set; }
        public Employee FindingCoordinator  { get; set; }
        public long? FindingOwnerId  { get; set; }
        public Employee FindingOwner { get; set; }
        public string Criteria { get; set; }
        public string Cause { get; set; }
        public string Condition { get; set; }
        public string Consequence { get; set; }
        public int? ActionId { get; set; }
        public DynamicParameterValue Action { get; set; }
        public long? ReviewedId  { get; set; }
        public Employee Reviewed  { get; set; }
        public int? ResponseId  { get; set; }
        public DynamicParameterValue Response { get; set; }       
        public int? PotentialCost { get; set; }     
        public long? AssignedId  { get; set; }
        public Employee Assigned { get; set; }

        public ICollection<FindingAssetInformation> SelectedFindingAssetInformations   { get; set; }
        public ICollection<FindingAuthoratativeSource> SelectedFindingAuthoratativeSources  { get; set; }
        public ICollection<FindingBusinessUnit> SelectedFindingBusinessUnits  { get; set; }
        public ICollection<FindingControlDesign> SelectedFindingControlDesigns  { get; set; }
        public ICollection<FindingControlOperating> SelectedFindingControlOperatings  { get; set; }
        public ICollection<FindingFacilitieDatacenter> SelectedFindingFacilitieDatacenters  { get; set; }
        public ICollection<FindingHardwareAsset> SelectedFindingHardwareAssets  { get; set; }
        public ICollection<FindingIncident> SelectedFindingIncidents  { get; set; }
        public ICollection<FindingInternalControl> SelectedFindingInternalControls  { get; set; }
        public ICollection<FindingOrganization> SelectedFindingOrganizations  { get; set; }
        public ICollection<FindingRiskRegister> SelectedFindingRiskRegisters  { get; set; }
        public ICollection<FindingStrategicObjective> SelectedFindingStrategicObjectives  { get; set; }
        public ICollection<FindingSystemsApplication> SelectedFindingSystemsApplications { get; set; }
        public ICollection<FindingVendor> SelectedFindingVendors  { get; set; }
        public ICollection<FindingVirtualHost> SelectedFindingVirtualHosts  { get; set; }
        public ICollection<FindingVirtualMachine> SelectedFindingVirtualMachines  { get; set; }
       
    }
}
