using Abp.IdentityServer4;
using Abp.Zero.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Lockthreat.Authorization.Delegation;
using Lockthreat.Authorization.Roles;
using Lockthreat.Authorization.Users;
using Lockthreat.Chat;
using Lockthreat.Editions;
using Lockthreat.Friendships;
using Lockthreat.MultiTenancy;
using Lockthreat.MultiTenancy.Accounting;
using Lockthreat.MultiTenancy.Payments;
using Lockthreat.Storage;
using Lockthreat.OrganizationSetups;
using Lockthreat.BusinessEntities;
using Lockthreat.Employees;
using Lockthreat.BusinessServices;
using Lockthreat.BusinessProcesses;
using Lockthreat.AddTasks;
using Lockthreat.ApplicationConfigurations;
using Lockthreat.AssetInformations;
using Lockthreat.Audits;
using Lockthreat.AuthoratativeDocuments;
using Lockthreat.Vendors;
using Lockthreat.Contracts;
using Lockthreat.ITServices;
using Lockthreat.Findings;
using Lockthreat.FindingsInformation;
using Lockthreat.InternalControls;
using Lockthreat.GrcPrograms;
using Lockthreat.FacilitieDatacenters;
using Lockthreat.HardwareAssets;
using Lockthreat.Incidents;
using Lockthreat.FacilitiesDatacenters;
using Lockthreat.SystemApplications;
using Lockthreat.CyberAwarenessScores;
using Lockthreat.Questions;
using Lockthreat.PolicyManagers;
using Lockthreat.ControlStandards;
using Lockthreat.Citations;
using Lockthreat.Contacts;
using Lockthreat.KeyPerformanceIndicators;
using Lockthreat.KeyRiskIndicators;
using Lockthreat.RiskManagements;
using Lockthreat.ReviewAssessments;
using Lockthreat.ReviewsAssessments;
using Lockthreat.ReviewDatas;
using Lockthreat.Remediations;
using Lockthreat.RiskTreatments;
using Lockthreat.Exceptions;
using Lockthreat.Meetings;
using Lockthreat.IssueManagements;
using Lockthreat.Projects;
using Lockthreat.StrategicObjectives;
using Lockthreat.ControlDesigns;
using Lockthreat.ControlOperatingTests;
using Lockthreat.ControlProcedures;
using Lockthreat.VirtualAssets;
using Lockthreat.CAPA;
using Lockthreat.BusinessImpactAnalysis_BIA_;
using Lockthreat.CodeGenerators;
using Lockthreat.Activitys;
using Lockthreat.Pages;
using Lockthreat.Templates;

namespace Lockthreat.EntityFrameworkCore
{
    public class LockthreatDbContext : AbpZeroDbContext<Tenant, Role, User, LockthreatDbContext>, IAbpPersistedGrantDbContext
    {

        public virtual DbSet<Template> Templates { get; set; }
        public virtual DbSet<StateAction> StateActions { get; set; }
         public virtual DbSet<State> States { get; set; }
        public virtual DbSet<PageField> PageFields { get; set; }
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<ActivityStep> ActivitySteps { get; set; }
        public virtual DbSet<ActivityAction> ActivityActions { get; set; }
        public virtual DbSet<Activity> Activitys { get; set; }

        public virtual DbSet<ContractBusinessProcess> ContractBusinessProcess { get; set; }
        public virtual DbSet<ExceptionRiskManagement> ExceptionRiskManagements { get; set; }
        public virtual DbSet<AuditSystemApplication> AuditSystemApplications { get; set; }
        public virtual DbSet<AuditBusinessProcess> AuditBusinessProcess { get; set; }
        public virtual DbSet<AuditFinding> AuditFindings { get; set; }
        public virtual DbSet<FindingControlDesign> FindingControlDesigns { get; set; }
        public virtual DbSet<SysteamApplicationBusinessProcess> SysteamApplicationBusinessProcess { get; set; }
        public virtual DbSet<VirtualAssetBusinessService> VirtualAssetBusinessServices { get; set; }
        public virtual DbSet<VirtualAssetBusinessprocess> VirtualAssetBusinessprocess { get; set; }
        public virtual DbSet<VirtualAssetITservice> VirtualAssetITservices { get; set; }
        public virtual DbSet<AssetInformationBusinessService> AssetInformationBusinessServices { get; set; }
        public virtual DbSet<AssetInformationBusinessprocess> AssetInformationBusinessprocess { get; set; }
        public virtual DbSet<AssetInformationITservice> AssetInformationITservices  { get; set; }
        public virtual DbSet<HardwareAssetBusinessService> HardwareAssetBusinessServices { get; set; }
        public virtual DbSet<HardwareAssetITservice> HardwareAssetITservices { get; set; }
        public virtual DbSet<HardwareAssetBusinessprocess> HardwareAssetBusinessProcess { get;set; }
        public virtual DbSet<TaskRelatedMember> TaskRelatedMembers { get; set; }
        public virtual DbSet<TaskAssociatedProject> TaskAssociatedProjects { get; set; }
        public virtual DbSet<BusinessITService> BusinessITServices { get; set; }
        public virtual DbSet<CodeGenerator> CodeGenerators { get; set; }
        public virtual DbSet<BIAStrategicObjective> BIAStrategicObjectives { get; set; }
        public virtual DbSet<BIAInternalControl> BIAInternalControls  { get; set; }
        public virtual DbSet<BIAInformationAsset> BIAInformationAssets { get; set; }
        public virtual DbSet<BIAFinding> BIAFindings { get; set; }
        public virtual DbSet<BIAException> BIAExceptions { get; set; }
        public virtual DbSet<BIABusinessProcess> BIABusinessProcesses { get; set; }
        public virtual DbSet<BusinessImpactAnalysis> BusinessImpactAnalysises { get; set; }
        public virtual DbSet<CapaDetail> CapaDetails { get; set; }
        public virtual DbSet<RiskManagementException> RiskManagementExceptions { get; set; }
        public virtual DbSet<AuthoratativeDocumentQuestion> AuthoratativeDocumentQuestions { get; set; }
        public virtual DbSet<AuthoratativeDocumentProject> AuthoratativeDocumentProjects { get; set; }
        public virtual DbSet<AuthoratativeDocumentProgram> AuthoratativeDocumentPrograms { get; set; }
        public virtual DbSet<AuthoratativeDocumentITService> AuthoratativeDocumentITServices { get; set; }

        public virtual DbSet<AuthoratativeDocumentFinding> AuthoratativeDocumentFindings { get; set; }
        public virtual DbSet<AuthoratativeDocumentCitation> AuthoratativeDocumentCitations { get; set; }
        public virtual DbSet<SysteamApplicationITservice> SysteamApplicationITservices { get; set; }
        public virtual DbSet<RemediationException> RemediationExceptions { get; set; }
        public virtual DbSet<FindingControlOperating> FindingControlOperatings { get; set; }
        public virtual DbSet<FindingVirtualMachine> FindingVirtualMachines { get; set; }
        public virtual DbSet<FindingVirtualHost> FindingVirtualHosts { get; set; }
        public virtual DbSet<VirtualAsset> VirtualAssets { get; set; }
        public virtual DbSet<FindingFacilitieDatacenter> FindingFacilitieDatacenters { get; set; }
        public virtual DbSet<FindingVendor> FindingVendors { get; set; }
        public virtual DbSet<FindingSystemsApplication> FindingSystemsApplications { get; set; }
        public virtual DbSet<FindingStrategicObjective> FindingStrategicObjectives { get; set; }
        public virtual DbSet<FindingInternalControl> FindingInternalControls { get; set; }
        public virtual DbSet<FindingIncident> FindingIncidents { get; set; }
        public virtual DbSet<FindingHardwareAsset> FindingHardwareAssets { get; set; }
        public virtual DbSet<FindingRiskRegister> FindingRiskRegisters { get; set; }
        public virtual DbSet<CyberAwarenessScoreEmployee> CyberAwarenessScoreEmployees { get; set; }
        public virtual DbSet<CyberAwarenessScoreQuestion> CyberAwarenessScoreQuestions { get; set; }
        public virtual DbSet<ControlStandardCitation> ControlStandardCitations  { get; set; }
        public virtual DbSet<ControlProcedureControlStandard> ControlProcedureControlStandards { get; set; }
        public virtual DbSet<ControlProcedureBusinessProcess> ControlProcedureBusinessProcess { get; set; }
        public virtual DbSet<ControlProcedure> ControlProcedures { get; set; }
        public virtual DbSet<ControlTestBusinessProcess> ControlTestBusinessProcess { get; set; }
        public virtual DbSet<ControlOperatingTestFinding> ControlOperatingTestFindings { get; set; }
        public virtual DbSet<ControlOperatingTestControlStandard> ControlOperatingTestControlStandards { get; set; }
        public virtual DbSet<ControlOperatingTest> ControlOperatingTests { get; set; }
        public virtual DbSet<ControlDesignFinding> ControlDesignFindings { get; set; }
        public virtual DbSet<ControlDesign> ControlDesigns { get; set; }
        public virtual DbSet<RiskTreatmentException> RiskTreatmentExceptions { get; set; }
        public virtual DbSet<StrategicObjective> StrategicObjectives  { get; set; }
        public virtual DbSet<ProjectTeamMemberProject> ProjectTeamMemberProjects { get; set; }
        public virtual DbSet<ProjectTeamMemberExternal> ProjectTeamMemberExternals { get; set; }
        public virtual DbSet<ProjectTeamMember> ProjectTeamMembers { get; set; }
        public virtual DbSet<ProjectCountries> ProjectCountries { get; set; }
        public virtual DbSet<ProjectComponent> ProjectComponents { get; set; }
        public virtual DbSet<ProjectAuthoratativeDocument> ProjectAuthoratativeDocuments { get; set; }
        public virtual DbSet<IssueManageMentProject> IssueManageMentProjects { get; set; }
        public virtual DbSet<ProjectAudit> ProjectAudits  { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<QuestionReviewAssessment> QuestionReviewAssessments { get; set; }
        public virtual DbSet<QuestionReviewData> QuestionReviewData { get; set; }
        public virtual DbSet<QuestionTarget> QuestionTargets { get; set; }
        public virtual DbSet<MeetingIssueIdentified> MeetingIssueIdentifieds { get; set; }
        public virtual DbSet<IssueManagement> IssueManagements { get; set; }
        public virtual DbSet<MeetingTask> MeetingTasks  { get; set; }
        public virtual DbSet<MeetingFinding> MeetingFindings { get; set; }
        public virtual DbSet<MeetingAttendUser> MeetingAttendUsers  { get; set; }
        public virtual DbSet<MeetingAbsenteeUser> MeetingAbsenteeUsers  { get; set; }
        public virtual DbSet<Meeting> Meetings { get; set; }
        public virtual DbSet<InternalControlSystemApplication> InternalControlSystemApplications { get; set; }
        public virtual DbSet<InternalControlRiskManagementTitle> InternalControlRiskManagementTitles { get; set; }
        public virtual DbSet<InternalControlRiskManagement> InternalControlRiskManagements { get; set; }
        public virtual DbSet<InternalControlPolicyManager> InternalControlPolicyManagers  { get; set; }
        public virtual DbSet<InternalControlAssignedTester> InternalControlAssignedTesters { get; set; }
        public virtual DbSet<InternalControlCitation> InternalControlCitations { get; set; }
        public virtual DbSet<InternalControlFacilitieDatacenter> InternalControlFacilitieDatacenters { get; set; }
        public virtual DbSet<EmployeeService> EmployeeServices { get; set; }
        public virtual DbSet<EmployeeReviewData> EmployeeReviewDatas { get; set; }
        public virtual DbSet<EmployeeCyberAwarenessScore> EmployeeCyberAwarenessScores { get; set; }
        public virtual DbSet<EmployeeContract> EmployeeContracts { get; set; }
       public virtual DbSet<EmployeeException> EmployeeExceptions { get; set; }
        public virtual DbSet<PolicyRelatedControl> PolicyRelatedControls  { get; set; }
        public virtual DbSet<ITServiceRemediation> ITServiceRemediations { get; set; }
        public virtual DbSet<ExceptionRemediation> ExceptionRemediations { get; set; }
        public virtual DbSet<ExceptionOrganization> ExceptionOrganizations { get; set; }
        public virtual DbSet<ExceptionDocument> ExceptionDocuments { get; set; }
        public virtual DbSet<ExceptionCitationLibrary> ExceptionCitationLibrarys  { get; set; }
        public virtual DbSet<ExceptionCitation> ExceptionCitations { get; set; }
        public virtual DbSet<ExceptionBusinessUnit> ExceptionBusinessUnits { get; set; }
        public virtual DbSet<ExceptionAuthoratativeDocument> ExceptionAuthoratativeDocuments { get; set; }
        public virtual DbSet<ExceptionAuditingControl> ExceptionAuditingControls { get; set; }
        public virtual DbSet<Exception> Exceptions { get; set; }
        public virtual DbSet<RiskTreatmentVendor> RiskTreatmentVendors { get; set; }
        public virtual DbSet<ContractRiskTreatment> ContractRiskTreatments { get; set; }
        public virtual DbSet<RiskTreatmentContract> RiskTreatmentContracts { get; set; }
        public virtual DbSet<RiskTreatmentAttachment> RiskTreatmentAttachments { get; set; }
        public virtual DbSet<RiskTreatment> RiskTreatments { get; set; }
        public virtual DbSet<RemediationRiskManagement> RemediationRiskManagements { get; set; }
        public virtual DbSet<RemediationAttachment> RemediationAttachments { get; set; }
        public virtual DbSet<Remediation> Remediations { get; set; }
        public virtual DbSet<ReviewData> ReviewDatas { get; set; }
        public virtual DbSet<ReviewAssessmentOraganization> ReviewAssessmentOraganizations { get; set; }
        public virtual DbSet<ReviewAssessmentAuthoratativeDocument> ReviewAssessmentAuthoratativeDocuments { get; set; }
        public virtual DbSet<ReviewAssessmentVendor> ReviewAssessmentVendors { get; set; }
        public virtual DbSet<ReviewAssessmentQuestion> ReviewAssessmentQuestions { get; set; }
        public virtual DbSet<ReviewAssessmentBusinessUnit> ReviewAssessmentBusinessUnits { get; set; }
        public virtual DbSet<ReviewAssessment> ReviewAssessments { get; set; }
        public virtual DbSet<RiskManagementFinding> RiskManagementFindings  { get; set; }
        public virtual DbSet<RiskManagementBusinessProcess> RiskManagementBusinessProcess { get; set; }
        public virtual DbSet<RiskManagementAssetInformation> RiskManagementAssetInformations { get; set; }
        public virtual DbSet<RiskManagement> RiskManagements { get; set; }
        public virtual DbSet<KeyRiskIndicatorBusinessUnit> KeyRiskIndicatorBusinessUnits { get; set; }
        public virtual DbSet<KeyRiskIndicator> KeyRiskIndicators { get; set; }
        public virtual DbSet<KeyPerformanceIndicatorBusinessUnit> KeyPerformanceIndicatorBusinessUnits { get; set; }
        public virtual DbSet<KeyPerformanceIndicatorAdministrator> KeyPerformanceIndicatorAdministrators { get; set; }
        public virtual DbSet<KeyPerformanceIndicator> KeyPerformanceIndicators { get; set; }
        public virtual DbSet<ContractITService> ContractITServices { get; set; } 
        public virtual DbSet<ContractEmployeeNotification> ContractEmployeeNotifications  { get; set; }
        public virtual DbSet<ContractEmployee> ContractEmployees  { get; set; }
        public virtual DbSet<ContractBusinessService> ContractBusinessServices { get; set; } 
        public virtual DbSet<ContractAttachment> ContractAttachments  { get; set; }
        public virtual DbSet<ContactCyberAwarenessScore> ContactCyberAwarenessScores  { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<CitationControlStandard> CitationControlStandards { get; set; }
        public virtual DbSet<CitationQuestion> CitationQuestions { get; set; }
        public virtual DbSet<Citation> Citations { get; set; }
        public virtual DbSet<ControlStandard> ControlStandards { get; set; }
        public virtual DbSet<PolicyDistribution> PolicyDistributions { get; set; }
        public virtual DbSet<PolicyImpactedOranization> PolicyImpactedOranizations { get; set; }
        public virtual DbSet<PolicyAuthoratativeDocument> PolicyAuthoratativeDocuments { get; set; }
        public virtual DbSet<PolicyReviewer> PolicyReviewers { get; set; }
        public virtual DbSet<PolicyManager> PolicyManagers { get; set; }
        public virtual DbSet<QuestionAuthoratativeDocument> QuestionAuthoratativeDocuments { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<CyberAwarenessScoreOrganization> CyberAwarenessScoreOrganizations  { get; set; }
        public virtual DbSet<CyberAwarenessScoreBusinessUnit> CyberAwarenessScoreBusinessUnits  { get; set; }
        public virtual DbSet<CyberAwarenessScoreAuthoratativeDocument> CyberAwarenessScoreAuthoratativeDocuments { get; set; }
        public virtual DbSet<CyberAwarenessScore> CyberAwarenessScores { get; set; }
        public virtual DbSet<AuditFacilitieDatacenter> AuditFacilitieDatacenters { get; set; }
        public virtual DbSet<SystemApplicationService> SystemApplicationServices { get; set; }
        public virtual DbSet<SystemApplication> SystemApplications { get; set; }
        public virtual DbSet<FacilitieDatacenterITService> FacilitieDatacenterITServices { get; set; }
        public virtual DbSet<FacilitieDatacenterService> FacilitieDatacenterServices { get; set; }
        public virtual DbSet<FacilitieDatacenterProcess> FacilitieDatacenterProcess { get; set; }
        public virtual DbSet<IncidentFinding> IncidentFindings { get; set; }
        public virtual DbSet<IncidentReviewer> IncidentReviewers { get; set; }
        public virtual DbSet<IncidentAttachment> IncidentAttachments { get; set; }
        public virtual DbSet<Incident> Incidents { get; set; }
        public virtual DbSet<HardwareAsset> HardwareAssets { get; set; }
        public virtual DbSet<FacilitieDatacenter> FacilitieDatacenters { get; set; }
        public virtual DbSet<ProgramTeam> ProgramTeams { get; set; }
        public virtual DbSet<ProgramCountry> ProgramCountrys  { get; set; }
        public virtual DbSet<ProgramCoordinator> ProgramCoordinators { get; set; }
        public virtual DbSet<ProgramAuthoritativeDocument> ProgramAuthoritativeDocuments { get; set; }
        public virtual DbSet<GrcProgram> GrcPrograms  { get; set; }
        public virtual DbSet<InternalControlFinding> InternalControlFindings { get; set; }
        public virtual DbSet<InternalControl> InternalControls  { get; set; }
        public virtual DbSet<FindingBusinessUnit> FindingBusinessUnits  { get; set; }
        public virtual DbSet<FindingAssetInformation> FindingAssetInformations { get; set; }

      public virtual DbSet<FindingOrganization> FindingOrganizations  { get; set; }
        public virtual DbSet<FindingAuthoratativeSource> FindingAuthoratativeSources { get; set; }
        public virtual DbSet<Finding> Findings { get; set; }
        public virtual DbSet<ITServiceContract> ITServiceContracts { get; set; }
        public DbSet<ITServiceBusinessUnit> ITServiceBusinessUnits { get; set; }
        public DbSet<ITServiceBusinessService> ITServiceBusinessServices  { get; set; }
        public virtual DbSet<ITServiceAuthoratativeDocument> ITServiceAuthoratativeDocuments { get; set; }
        public virtual DbSet<ITService> ITServices { get; set; }
        public virtual DbSet<VendorProductService> VendorProductServices { get; set; }
        public virtual DbSet<Contract> Contracts  { get; set; }
        public virtual DbSet<EmployeeBusinessService> EmployeeBusinessServices { get; set; }
        public virtual DbSet<EmployeeAttachment> EmployeeAttachments { get; set; }
        public virtual DbSet<AuditVendor> AuditVendors  { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<AuthoratativeDocumentOrganization> AuthoratativeDocumentOrganizations { get; set; }
        public virtual DbSet<AuthoratativeDocumentBusinessUnit> AuthoratativeDocumentBusinessUnits { get; set; }
        public virtual DbSet<AuthoratativeDocument> AuthoratativeDocuments { get; set; }
        public virtual DbSet<AuditWorkpaperReviewer> AuditWorkpaperReviewers  { get; set; }
        public virtual DbSet<AuditBusinessService> AuditBusinessServices  { get; set; }
        public virtual DbSet<AuditWorkpaperEvidence> AuditWorkpaperEvidences  { get; set; }
        public virtual DbSet<AuditWorkpaper> AuditWorkpapers  { get; set; }
        public virtual DbSet<AuditTeam> AuditTeams { get; set; }
        public virtual DbSet<AuditAuditor> AuditAuditors  { get; set; }
        public virtual DbSet<AuditAttachment> AuditAttachments  { get; set; }
        public virtual DbSet<Audit> Audits  { get; set; }
        public virtual DbSet<AssetInformation> AssetInformations { get; set; }
        public virtual DbSet<ApplicationConfiguration> ApplicationConfigurations { get; set; }
        public virtual DbSet<TaskAttachment> TaskAttachments { get; set; }
        public virtual DbSet<TaskNotification> TaskNotifications { get; set; }
        public virtual DbSet<AddTask> AddTasks { get; set; }
        public virtual DbSet<BusinessProcessUnit> BusinessProcessUnits { get; set; }
        public virtual DbSet<BusinessProcessService> BusinessProcessServices { get; set; }
        public virtual DbSet<BusinessProcessAuthoratativeDocument> BusinessProcessAuthoratativeDocuments { get; set; }
        public virtual DbSet<BusinessProcess> BusinessProcess { get; set; }
        public virtual DbSet<BusinessServiceUnit> BusinessServiceUnits { get; set; }
        public virtual DbSet<BusinessService> BusinessServices { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<BusinessUnit> BusinessUnits  { get; set; }
        public virtual DbSet<LockThreatOrganization> LockThreatOrganizations { get; set; }


          /*Create Table For LockThreatOrganizations*/

        /* Define an IDbSet for each entity of the application */


        public virtual DbSet<BinaryObject> BinaryObjects { get; set; }

        public virtual DbSet<Friendship> Friendships { get; set; }

        public virtual DbSet<ChatMessage> ChatMessages { get; set; }

        public virtual DbSet<SubscribableEdition> SubscribableEditions { get; set; }

        public virtual DbSet<SubscriptionPayment> SubscriptionPayments { get; set; }

        public virtual DbSet<Invoice> Invoices { get; set; }

        public virtual DbSet<PersistedGrantEntity> PersistedGrants { get; set; }

        public virtual DbSet<SubscriptionPaymentExtensionData> SubscriptionPaymentExtensionDatas { get; set; }

        public virtual DbSet<UserDelegation> UserDelegations { get; set; }

        public LockthreatDbContext(DbContextOptions<LockthreatDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BinaryObject>(b =>
            {
                b.HasIndex(e => new { e.TenantId });
            });

            modelBuilder.Entity<ChatMessage>(b =>
            {
                b.HasIndex(e => new { e.TenantId, e.UserId, e.ReadState });
                b.HasIndex(e => new { e.TenantId, e.TargetUserId, e.ReadState });
                b.HasIndex(e => new { e.TargetTenantId, e.TargetUserId, e.ReadState });
                b.HasIndex(e => new { e.TargetTenantId, e.UserId, e.ReadState });
            });

            modelBuilder.Entity<Friendship>(b =>
            {
                b.HasIndex(e => new { e.TenantId, e.UserId });
                b.HasIndex(e => new { e.TenantId, e.FriendUserId });
                b.HasIndex(e => new { e.FriendTenantId, e.UserId });
                b.HasIndex(e => new { e.FriendTenantId, e.FriendUserId });
            });

            modelBuilder.Entity<Tenant>(b =>
            {
                b.HasIndex(e => new { e.SubscriptionEndDateUtc });
                b.HasIndex(e => new { e.CreationTime });
            });

            modelBuilder.Entity<SubscriptionPayment>(b =>
            {
                b.HasIndex(e => new { e.Status, e.CreationTime });
                b.HasIndex(e => new { PaymentId = e.ExternalPaymentId, e.Gateway });
            });

            modelBuilder.Entity<SubscriptionPaymentExtensionData>(b =>
            {
                b.HasQueryFilter(m => !m.IsDeleted)
                    .HasIndex(e => new { e.SubscriptionPaymentId, e.Key, e.IsDeleted })
                    .IsUnique();
            });

            modelBuilder.Entity<UserDelegation>(b =>
            {
                b.HasIndex(e => new { e.TenantId, e.SourceUserId });
                b.HasIndex(e => new { e.TenantId, e.TargetUserId });
            });

            modelBuilder.ConfigurePersistedGrantEntity();
        }

    }
}
