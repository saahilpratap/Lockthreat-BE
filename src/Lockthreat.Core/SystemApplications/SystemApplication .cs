using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using Lockthreat.BusinessEntities;
using Lockthreat.Employees;
using Lockthreat.OrganizationSetups;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.SystemApplications
{
  public  class SystemApplication : FullAuditedEntity<long>, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public string SystemId { get; set; }

        public string SystemApplicationName { get; set; }

        public string AddressOne { get; set; }

        public string AddressTwo { get; set; }

        public string State { get; set; }
        public string City { get; set; }

        public string PostalCode { get; set; }

        public int? CountryId { get; set; }
        public DynamicParameterValue Country { get; set; }

         public long? LockThreatOrganizationId  { get; set; }
        public LockThreatOrganization LockThreatOrganization { get; set; }

        public long? BusinessUnitId { get; set; }
        public BusinessUnit BusinessUnit { get; set; }

        public long? BusinessUnitGaurdianId { get; set; }
        public BusinessUnit BusinessUnitGaurdian { get; set; }


        public long? BusinessOwnerId  { get; set; }
        public Employee BusinessOwner { get; set; }

        public int? ConfidentialityId  { get; set; }
        public DynamicParameterValue Confidentiality { get; set; }
        public int? AvailibilityId  { get; set; }
        public DynamicParameterValue Availibility  { get; set; }
        public int? IntegrityId  { get; set; }
        public DynamicParameterValue Integrity { get; set; }
        public int? OthersId  { get; set; }
        public DynamicParameterValue Others  { get; set; }
        
        public ICollection<SysteamApplicationITservice> SelectedSysteamApplicationITservices  { get; set; }
        public ICollection<SysteamApplicationBusinessProcess> SelectedSysteamApplicationBusinessProcess { get; set; }
        public ICollection<SystemApplicationService> SelectedSystemApplicationServices  { get; set; }
    }
}
