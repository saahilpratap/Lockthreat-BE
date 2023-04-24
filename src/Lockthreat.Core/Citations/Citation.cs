using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using Lockthreat.AuthoratativeDocuments;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Citations 
{
   public class Citation : FullAuditedEntity<long>, IMayHaveTenant
    {
        public int? TenantId { get; set; }
        public long? AuthoratativeDocumentId { get; set; }
        public AuthoratativeDocument AuthoratativeDocument { get; set; }

        public int? ParentCitationId { get; set; }
        public int? CitationTypeId  { get; set; }
        public DynamicParameterValue CitationType { get; set; }

        public string CitationId { get; set; }

        public string ControlRequirements { get; set; }
        public string CitationOriginId { get; set; }

        public int? FrameworkObjectivesId  { get; set; }
        public DynamicParameterValue FrameworkObjectives { get; set; }
        
        public string CitationTitle { get; set; }

        public int? CitationClassId  { get; set; }
        public DynamicParameterValue CitationClass { get; set; }

        public string CustomApplicability { get; set; }

        public string UCFCId { get; set; }

        public int? CITLV { get; set; }

        public string ControlObjective { get; set; }

        public string IconDocument { get; set; }

        public string RelatedContentImage { get; set; }

        public string CitationDescription { get; set; }

    }
}
