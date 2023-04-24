using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using Lockthreat.Audits;
using Lockthreat.Employees;
using Lockthreat.InternalControls;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.ControlOperatingTests 
{
 public   class ControlOperatingTest : FullAuditedEntity<long>, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public string COTId { get; set; }

        public int? TestStatusId  { get; set; }
        public DynamicParameterValue TestStatus  { get; set; }
        
        public string Title { get; set; }

        public string TestDetails { get; set; }

        public string ExpectedResult { get; set; }

        public DateTime? TestEffectiveDate { get; set; }

        public int? SampleSize { get; set; }

        public long? InternalControlId { get; set; }
        public InternalControl InternalControl { get; set; }

        public long? PerformedbyId { get; set; }
        public Employee Performedby { get; set; }

        public int? DataCollectionPurposeId  { get; set; }
        public DynamicParameterValue DataCollectionPurpose { get; set; }
        
        public string ActualResult  { get; set; }

        public string TestNotes { get; set; }

        public int? CollectionSampleSize { get; set; }

        public string DataCollectionDetails { get; set; }

        public long? AuditId  { get; set; }
        public Audit Audit  { get; set; }

    }
}
