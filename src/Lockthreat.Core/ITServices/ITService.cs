using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using Lockthreat.BusinessEntities;
using Lockthreat.Employees;
using Lockthreat.OrganizationSetups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.ITServices
{
    [Table("ITServices")]
    public class ITService : FullAuditedEntity<long>, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public string ITServicesId { get; set; }

        [Required]
        public string  ITServiceName { get; set; }
     
        public int? ServiceTypeId { get; set; }
        public DynamicParameterValue ServiceType { get; set; }
        public int? ServiceClassificationId  { get; set; }
        public DynamicParameterValue ServiceClassification { get; set; }

        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        
        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode  { get; set; }

        public int? CountryId { get; set; }
        public DynamicParameterValue Country { get; set; }
        public long? LockThreatOrganizationId  { get; set; }
        public LockThreatOrganization LockThreatOrganization  { get; set; }        
        public long? ITServiceOwnerId { get; set; }
        public Employee ITServiceOwner { get; set; }
        public long? ITServiceManagerId { get; set; }
        public Employee ITServiceManager { get; set; }

        public long? BusinessUnitId  { get; set; }
        public BusinessUnit BusinessUnit { get; set; }

        public int? RegulatoryMandateId  { get; set; }
        public DynamicParameterValue RegulatoryMandate { get; set; }
        public int? ConfidentialityId { get; set; }
        public DynamicParameterValue Confidentiality  { get; set; }
        public int? IntegrityId { get; set; }
        public DynamicParameterValue Integrity  { get; set; }

        public int? OthersId  { get; set; }
        public DynamicParameterValue Others { get; set; }

        public int? AvailibilityId { get; set; }
        public DynamicParameterValue Availibility { get; set; }

        public ICollection<ITServiceBusinessService> SelectedITserviceBusinessServices  { get; set; }
        public ICollection<ITServiceBusinessUnit> SelectedITserviceBusinessUnit  { get; set; }
        


    }
}
