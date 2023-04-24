using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Audits 
{
  public  enum  AuditType
    {
        InternalAudit=1,
        ExternalAudit,
        CertificationAudit,
        RegulatoryAudit,
        CustomerAudit,
        SupplierAudit,
        Investigation,
        ComplianceAudit,
        SpecialReviews,
        OperationalAudit,
        FinancialAudit,
        PerformanceAudit,
        Other
    }
}
