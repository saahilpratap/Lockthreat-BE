using Abp.Application.Editions;
using Abp.Application.Features;
using Abp.Auditing;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.DynamicEntityParameters;
using Abp.EntityHistory;
using Abp.Localization;
using Abp.Notifications;
using Abp.Organizations;
using Abp.UI.Inputs;
using Abp.Webhooks;
using AutoMapper;
using Lockthreat.AddTasks;
using Lockthreat.AssetInformations;
using Lockthreat.AssetInformations.Dto;
using Lockthreat.Auditing.Dto;
using Lockthreat.Audits;
using Lockthreat.Audits.Dto;
using Lockthreat.Authorization.Accounts.Dto;
using Lockthreat.Authorization.Delegation;
using Lockthreat.Authorization.Permissions.Dto;
using Lockthreat.Authorization.Roles;
using Lockthreat.Authorization.Roles.Dto;
using Lockthreat.Authorization.Users;
using Lockthreat.Authorization.Users.Delegation.Dto;
using Lockthreat.Authorization.Users.Dto;
using Lockthreat.Authorization.Users.Importing.Dto;
using Lockthreat.Authorization.Users.Profile.Dto;
using Lockthreat.Business.Dto;
using Lockthreat.BusinessEntities;
using Lockthreat.BusinessProcesses;
using Lockthreat.BusinessProcesses.Dto;
using Lockthreat.BusinessServices;
using Lockthreat.BusinessServices.Dto;
using Lockthreat.Chat;
using Lockthreat.Chat.Dto;
using Lockthreat.Citations;
using Lockthreat.Contacts;
using Lockthreat.Contacts.Dto;
using Lockthreat.Contracts;
using Lockthreat.Contracts.Dto;
using Lockthreat.ControlDesigns;
using Lockthreat.ControlOperatingTests;
using Lockthreat.Countries;
using Lockthreat.Countries.Dto;
using Lockthreat.DynamicEntityParameters.Dto;
using Lockthreat.Editions;
using Lockthreat.Editions.Dto;
using Lockthreat.Employee.Dto;
using Lockthreat.Exceptions;
using Lockthreat.Exceptions.Dto;
using Lockthreat.FacilitieDatacenters;
using Lockthreat.FacilitieDatacenters.Dto;
using Lockthreat.FacilitiesDatacenters;
using Lockthreat.Findings;
using Lockthreat.Findings.Dto;
using Lockthreat.FindingsInformation;
using Lockthreat.Friendships;
using Lockthreat.Friendships.Cache;
using Lockthreat.Friendships.Dto;
using Lockthreat.GrcPrograms;
using Lockthreat.GRCPrograms;
using Lockthreat.GRCPrograms.Dto;
using Lockthreat.HardwareAssets;
using Lockthreat.HardwareAssets.Dto;
using Lockthreat.IndustrySectors;
using Lockthreat.IndustrySectors.Dto;
using Lockthreat.ITservices;
using Lockthreat.ITservices.Dto;
using Lockthreat.ITServices;
using Lockthreat.KeyPerformanceIndicator.Dto;
using Lockthreat.KeyRiskIndicator.Dto;
using Lockthreat.KeyRiskIndicators;
using Lockthreat.Localization.Dto;
using Lockthreat.Meetings;
using Lockthreat.Meetings.Dto;
using Lockthreat.MultiTenancy;
using Lockthreat.MultiTenancy.Dto;
using Lockthreat.MultiTenancy.HostDashboard.Dto;
using Lockthreat.MultiTenancy.Payments;
using Lockthreat.MultiTenancy.Payments.Dto;
using Lockthreat.Notifications.Dto;
using Lockthreat.Organizations.Dto;
using Lockthreat.OrganizationSetup;
using Lockthreat.OrganizationSetup.Dto;
using Lockthreat.OrganizationSetups;
using Lockthreat.PolicyManagers;
using Lockthreat.Projects;
using Lockthreat.ProjectsInfo;
using Lockthreat.ProjectsInfo.Dto;
using Lockthreat.Remediations;
using Lockthreat.Sessions.Dto;
using Lockthreat.StrategicObjectives;
using Lockthreat.StrategicObjectives.Dto;
using Lockthreat.SystemApplications;
using Lockthreat.SystemApplications.Dto;
using Lockthreat.Tasks.Dto;
using Lockthreat.Vendors;
using Lockthreat.Vendors.Dto;
using Lockthreat.VirtualAssets;
using Lockthreat.VirtualAssets.Dto;
using Lockthreat.WebHooks.Dto;


namespace Lockthreat
{
    internal static class CustomDtoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            //Inputs
            configuration.CreateMap<CheckboxInputType, FeatureInputTypeDto>();
            configuration.CreateMap<SingleLineStringInputType, FeatureInputTypeDto>();
            configuration.CreateMap<ComboboxInputType, FeatureInputTypeDto>();
            configuration.CreateMap<IInputType, FeatureInputTypeDto>()
                .Include<CheckboxInputType, FeatureInputTypeDto>()
                .Include<SingleLineStringInputType, FeatureInputTypeDto>()
                .Include<ComboboxInputType, FeatureInputTypeDto>();
            configuration.CreateMap<StaticLocalizableComboboxItemSource, LocalizableComboboxItemSourceDto>();
            configuration.CreateMap<ILocalizableComboboxItemSource, LocalizableComboboxItemSourceDto>()
                .Include<StaticLocalizableComboboxItemSource, LocalizableComboboxItemSourceDto>();
            configuration.CreateMap<LocalizableComboboxItem, LocalizableComboboxItemDto>();
            configuration.CreateMap<ILocalizableComboboxItem, LocalizableComboboxItemDto>()
                .Include<LocalizableComboboxItem, LocalizableComboboxItemDto>();

            //Dynamic 
            configuration.CreateMap<DynamicParameterValue, GetDynamicValueDto>().ReverseMap();
            //Chat
            configuration.CreateMap<ChatMessage, ChatMessageDto>();
            configuration.CreateMap<ChatMessage, ChatMessageExportDto>();

            //Feature
            configuration.CreateMap<FlatFeatureSelectDto, Feature>().ReverseMap();
            configuration.CreateMap<Feature, FlatFeatureDto>();

            //Role
            configuration.CreateMap<RoleEditDto, Role>().ReverseMap();
            configuration.CreateMap<Role, RoleListDto>();
            configuration.CreateMap<UserRole, UserListRoleDto>();

            //Edition
            configuration.CreateMap<EditionEditDto, SubscribableEdition>().ReverseMap();
            configuration.CreateMap<EditionCreateDto, SubscribableEdition>();
            configuration.CreateMap<EditionSelectDto, SubscribableEdition>().ReverseMap();
            configuration.CreateMap<SubscribableEdition, EditionInfoDto>();

            configuration.CreateMap<Edition, EditionInfoDto>().Include<SubscribableEdition, EditionInfoDto>();

            configuration.CreateMap<SubscribableEdition, EditionListDto>();
            configuration.CreateMap<Edition, EditionEditDto>();
            configuration.CreateMap<Edition, SubscribableEdition>();
            configuration.CreateMap<Edition, EditionSelectDto>();


            //Payment
            configuration.CreateMap<SubscriptionPaymentDto, SubscriptionPayment>().ReverseMap();
            configuration.CreateMap<SubscriptionPaymentListDto, SubscriptionPayment>().ReverseMap();
            configuration.CreateMap<SubscriptionPayment, SubscriptionPaymentInfoDto>();

            //Permission
            configuration.CreateMap<Permission, FlatPermissionDto>();
            configuration.CreateMap<Permission, FlatPermissionWithLevelDto>();

            //Language
            configuration.CreateMap<ApplicationLanguage, ApplicationLanguageEditDto>();
            configuration.CreateMap<ApplicationLanguage, ApplicationLanguageListDto>();
            configuration.CreateMap<NotificationDefinition, NotificationSubscriptionWithDisplayNameDto>();
            configuration.CreateMap<ApplicationLanguage, ApplicationLanguageEditDto>()
                .ForMember(ldto => ldto.IsEnabled, options => options.MapFrom(l => !l.IsDisabled));

            //Tenant
            configuration.CreateMap<Tenant, RecentTenant>();
            configuration.CreateMap<Tenant, TenantLoginInfoDto>();
            configuration.CreateMap<Tenant, TenantListDto>();
            configuration.CreateMap<TenantEditDto, Tenant>().ReverseMap();
            configuration.CreateMap<CurrentTenantInfoDto, Tenant>().ReverseMap();

            //User
            configuration.CreateMap<User, UserEditDto>()
                .ForMember(dto => dto.Password, options => options.Ignore())
                .ReverseMap()
                .ForMember(user => user.Password, options => options.Ignore());
            configuration.CreateMap<User, UserLoginInfoDto>();
            configuration.CreateMap<User, UserListDto>();
            configuration.CreateMap<User, ChatUserDto>();
            configuration.CreateMap<User, OrganizationUnitUserListDto>();
            configuration.CreateMap<Role, OrganizationUnitRoleListDto>();
            configuration.CreateMap<CurrentUserProfileEditDto, User>().ReverseMap();
            configuration.CreateMap<UserLoginAttemptDto, UserLoginAttempt>().ReverseMap();
            configuration.CreateMap<ImportUserDto, User>();

            //AuditLog
            configuration.CreateMap<AuditLog, AuditLogListDto>();
            configuration.CreateMap<EntityChange, EntityChangeListDto>();
            configuration.CreateMap<EntityPropertyChange, EntityPropertyChangeDto>();

            //Friendship
            configuration.CreateMap<Friendship, FriendDto>();
            configuration.CreateMap<FriendCacheItem, FriendDto>();

            //OrganizationUnit
            configuration.CreateMap<OrganizationUnit, OrganizationUnitDto>();
            configuration.CreateMap<OrganizationUnit, UpdateOrganizationUnitInput>().ReverseMap();

            //Webhooks
            configuration.CreateMap<WebhookSubscription, GetAllSubscriptionsOutput>();
            configuration.CreateMap<WebhookSendAttempt, GetAllSendAttemptsOutput>()
                .ForMember(webhookSendAttemptListDto => webhookSendAttemptListDto.WebhookName,
                    options => options.MapFrom(l => l.WebhookEvent.WebhookName))
                .ForMember(webhookSendAttemptListDto => webhookSendAttemptListDto.Data,
                    options => options.MapFrom(l => l.WebhookEvent.Data));

            configuration.CreateMap<WebhookSendAttempt, GetAllSendAttemptsOfWebhookEventOutput>();

            configuration.CreateMap<DynamicParameter, DynamicParameterDto>().ReverseMap();
            configuration.CreateMap<DynamicParameterValue, DynamicParameterValueDto>().ReverseMap();
            configuration.CreateMap<EntityDynamicParameter, EntityDynamicParameterDto>()
                .ForMember(dto => dto.DynamicParameterName,
                    options => options.MapFrom(entity => entity.DynamicParameter.ParameterName));
            configuration.CreateMap<EntityDynamicParameterDto, EntityDynamicParameter>();

            configuration.CreateMap<EntityDynamicParameterValue, EntityDynamicParameterValueDto>().ReverseMap();
            //User Delegations
            configuration.CreateMap<CreateUserDelegationDto, UserDelegation>();


            /* ADD YOUR OWN CUSTOM AUTOMAPPER MAPPINGS HERE */


            //OrganizationSetup
            configuration.CreateMap<LockThreatOrganization, CreateOrUpdateOrganizationSetupInput>().ReverseMap();
            configuration.CreateMap<LockThreatOrganization, OrganizationSetupListDto>().ReverseMap();
            configuration.CreateMap<LockThreatOrganization, GetOrganizationForEditDto>().ReverseMap();
            configuration.CreateMap<LockThreatOrganization, GetLockThreatOrganizationDto>().ReverseMap();

            configuration.CreateMap<LockThreatOrganization, GetOrganizationDto>().ReverseMap();

            //BusinessUnit
            configuration.CreateMap<BusinessUnit, CreateOrUpdateBusinessUnitInput>().ReverseMap();
            configuration.CreateMap<BusinessUnit, BusinessUnitListDto>().ReverseMap();
            configuration.CreateMap<BusinessUnit, GetBusinessUnitForEditDto>().ReverseMap();
          
            configuration.CreateMap<BusinessUnit, BusinessUnitDto>().ReverseMap();
            configuration.CreateMap<BusinessUnit, BusinessUnitPrimaryDto>().ReverseMap();

            //IndustrySector
            configuration.CreateMap<IndustrySector, IndustrySectorDto>().ReverseMap();

            //Country
            configuration.CreateMap<Country, CountryDto>().ReverseMap();

            //Employee
            configuration.CreateMap<Employees.Employee, CreateOrUpdateEmployeesInput>().ReverseMap();
            configuration.CreateMap<Employees.Employee, GetEmployeeForEditDto>().ReverseMap();
            configuration.CreateMap<CreateOrUpdateEmployeesInput, UserEditDto>().ReverseMap();
            configuration.CreateMap<Employees.Employee, EmployeeListDto>().ReverseMap();
            configuration.CreateMap<Employees.Employee, GetEmployeeUnderOraganizationDto>().ReverseMap();
            configuration.CreateMap<Employees.Employee, EmployeeDto>().ReverseMap();

            //Task
            configuration.CreateMap<AddTask, TaskinfoDto>().ReverseMap();
            configuration.CreateMap<AddTask, GetTasksForEditDto>().ReverseMap();
            configuration.CreateMap<AddTask, TaskListDto>().ReverseMap();
            configuration.CreateMap<TaskAssociatedProject, TaskAssociatedProjectDto>().ReverseMap();
            configuration.CreateMap<TaskAttachment, TaskAttachmentDto>().ReverseMap();
            configuration.CreateMap<TaskNotification, TaskNotificationDto>().ReverseMap();
            configuration.CreateMap<TaskRelatedMember, TaskRelatedMemberDto>().ReverseMap();
            configuration.CreateMap<MeetingTask, MeetingTaskDto>().ReverseMap();

            //Business Services
            configuration.CreateMap<BusinessService, CreateOrUpdateBusinessServicesInput>().ReverseMap();
            configuration.CreateMap<BusinessService, GetBusinessServicesForEditDto>().ReverseMap();
            configuration.CreateMap<BusinessService, BusinessServicesListDto>().ReverseMap();
            configuration.CreateMap<BusinessITService, ItServicesDto>().ReverseMap();
            configuration.CreateMap<BusinessServiceUnit, ServiceBusinessUnitDto>().ReverseMap();
            configuration.CreateMap<BusinessService, BusinessServices.Dto.BusinessServiceDto>().ReverseMap();
            configuration.CreateMap<BusinessService, BusinessServiceSDto >().ReverseMap();
            

            //Business Process
            configuration.CreateMap<BusinessProcess, CreateOrUpdateBusinessProcessInput>().ReverseMap();
            configuration.CreateMap<BusinessProcess, GetBusinessProcessForEditDto>().ReverseMap();
            configuration.CreateMap<BusinessProcess, BusinessProcessListDto>().ReverseMap();
            configuration.CreateMap<BusinessProcess, BusinessProcessDto>().ReverseMap();

            configuration.CreateMap<BusinessProcessService, BusinessProcessServiceDto>().ReverseMap();
            configuration.CreateMap<BusinessProcessUnit,BusinessProcessUnitDto > ().ReverseMap();
            configuration.CreateMap<BusinessProcessAuthoratativeDocument, BusinessProcessAuthorativeDocumentDto>().ReverseMap();
            //Key Risk Indicators
            configuration.CreateMap<KeyRiskIndicators.KeyRiskIndicator, CreateOrUpdateKeyRiskIndicatorsInput>().ReverseMap();
            configuration.CreateMap<KeyRiskIndicators.KeyRiskIndicator, GetKRIForEditDto>().ReverseMap();
            configuration.CreateMap<KeyRiskIndicators.KeyRiskIndicator, KeyRiskIndicatorListDto>().ReverseMap();
            configuration.CreateMap<KeyRiskIndicators.KeyRiskIndicator, KeyRiskIndicatorDto>().ReverseMap();
            configuration.CreateMap<KeyRiskIndicatorBusinessUnit, BusinessUnitKeyRiskDto>().ReverseMap();

            //Key Performance Indicators
            configuration.CreateMap<KeyPerformanceIndicators.KeyPerformanceIndicator, CreateOrUpdateKeyPerformanceIndicatorsInput>().ReverseMap();
            configuration.CreateMap<KeyPerformanceIndicators.KeyPerformanceIndicator, GetKRIForEditDto>().ReverseMap();
            configuration.CreateMap<KeyPerformanceIndicators.KeyPerformanceIndicator, KeyPerformanceIndicatorListDto>().ReverseMap();
            configuration.CreateMap<KeyPerformanceIndicators.KeyPerformanceIndicatorAdministrator, KPIAdminisratorDto>().ReverseMap();
            configuration.CreateMap<KeyPerformanceIndicators.KeyPerformanceIndicatorBusinessUnit, KPIBusinessUnitDto>().ReverseMap();
            configuration.CreateMap<KeyPerformanceIndicators.KeyPerformanceIndicator, KeyPerformanceDto>().ReverseMap();


            //IT Services
            configuration.CreateMap<ITService, GetITserviceForBusinessServiceDto>().ReverseMap();
            configuration.CreateMap<ITService, ITserviceDto>().ReverseMap();
            configuration.CreateMap<ITServiceBusinessService, ITserviceBusinessServiceDto>().ReverseMap();
            configuration.CreateMap<ITServiceBusinessUnit, ITserviceBusinessUnitDto>().ReverseMap();
            configuration.CreateMap<ITService, GetITserviceListDto>().ReverseMap();
            //Programs and Projects
            //configuration.CreateMap<GRCProgram, ProgramListDto>()
            //    .ForMember(x => x.SponserName, y => y.MapFrom(z => z.ProgramSponsor.Name + "-" + z.ProgramSponsor.EmployeePosition + "-" + z.ProgramSponsor.Organization.CompanyName))
            //    .ForMember(x => x.DirectorName, y => y.MapFrom(z => z.ProgramDirector.Name + "-" + z.ProgramDirector.EmployeePosition + "-" + z.ProgramDirector.Organization.CompanyName))
            //    .ForMember(x => x.CompanyName, y => y.MapFrom(z => z.CompanyName.CompanyName))
            //.ReverseMap();

            configuration.CreateMap<GrcProgram, ProgramDto>().ReverseMap();

            configuration.CreateMap<ProgramTeamDto, ProgramTeam>().ReverseMap();
            configuration.CreateMap<ProgramCoordinatorDto, ProgramCoordinator>().ReverseMap();
            configuration.CreateMap<ProgramAuthoritativeDocumentsDto, ProgramAuthoritativeDocument>().ReverseMap();
            configuration.CreateMap<ProgramCountriesDto, ProgramCountry>().ReverseMap();

            configuration.CreateMap<Employees.Employee, ProgramUser>()
                                            .ForMember(x => x.EmployeeName, y => y.MapFrom(z => z.Name + "-" + z.EmployeePosition + "-" + z.LockThreatOrganization.CompanyName))
                                            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                                            .ForMember(x => x.OrganizationId, y => y.MapFrom(z => z.LockThreatOrganizationId));

            configuration.CreateMap<Employees.Employee, BusinessServiceOwner>()
                 .ForMember(x => x.EmployeeName, y => y.MapFrom(z => z.Name + "-" + z.EmployeePosition + "-" + z.LockThreatOrganization.CompanyName))
                 .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                 .ForMember(x => x.OrganizationId, y => y.MapFrom(z => z.LockThreatOrganizationId));

            configuration.CreateMap<BusinessUnit,BusinessUnitGaurdianDto>()
                  .ForMember(x => x.BusinessUnitTitle, y => y.MapFrom(z => z.BusinessUnitTitle + "-" + z.LockThreatOrganization.CompanyName))
                  .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                  .ForMember(x => x.LockThreatOrganizationId, y => y.MapFrom(z => z.LockThreatOrganizationId));
            //Programs and Projects
            //configuration.CreateMap<ProjectsDetails, ProjectListDto>()
            //   .ForMember(x => x.SponserName, y => y.MapFrom(z => z.ProjectSponsor.Name + "-" + z.ProjectSponsor.EmployeePosition + "-" + z.ProjectSponsor.Organization.CompanyName))
            //   .ForMember(x => x.DirectorName, y => y.MapFrom(z => z.ProjectDirector.Name + "-" + z.ProjectDirector.EmployeePosition + "-" + z.ProjectDirector.Organization.CompanyName))
            //   .ForMember(x => x.CompanyName, y => y.MapFrom(z => z.CompanyName.CompanyName))
            //   .ForMember(x => x.ParentProgramName, y => y.MapFrom(z => z.ParentProgram.ProgramTitle))
            //    .ReverseMap();

            configuration.CreateMap<Project, ProjectDto>().ReverseMap();
            configuration.CreateMap<Project, ProjectListsDto>().ReverseMap();
            configuration.CreateMap<ProjectTeamMemberInternalDto, ProjectTeamMember>().ReverseMap();
            configuration.CreateMap<ProjectTeamMemberExternalDto, ProjectTeamMemberExternal>().ReverseMap();
            configuration.CreateMap<ProjectTeamMemberDto, ProjectTeamMemberProject>().ReverseMap();
            configuration.CreateMap<ProjectCountriesDto, ProjectCountries>().ReverseMap();
            configuration.CreateMap<ProjectComponentsDto, ProjectComponent>().ReverseMap();
            configuration.CreateMap<ProjectAuthoratativeDocumentDto, ProjectAuthoratativeDocument>().ReverseMap();


            configuration.CreateMap<Employees.Employee, ProjectUser>()
                                            .ForMember(x => x.EmployeeName, y => y.MapFrom(z => z.Name + "-" + z.EmployeePosition + "-" + z.LockThreatOrganization.CompanyName))
                                            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                                            .ForMember(x => x.OrganizationId, y => y.MapFrom(z => z.LockThreatOrganization.Id));


            //   StrategicObjective
            configuration.CreateMap<StrategicObjective, StrategicObjectiveDto>().ReverseMap();
            configuration.CreateMap<StrategicObjective, StrategicObjectivesDto>().ReverseMap();
            configuration.CreateMap<StrategicObjective, CreateOrUpdateStrategicObjectiveDto>().ReverseMap();
            configuration.CreateMap<StrategicObjective, GetEditStrategicObjectiveDto>().ReverseMap();
            configuration.CreateMap<StrategicObjective, StrategicObjectiveListDto>().ReverseMap();
            configuration.CreateMap<StrategicObjective, OranizationGoalDto>().ReverseMap();
            //ITservice 
            configuration.CreateMap<ITService, ITserviceListDto>().ReverseMap();

            //Meeting
            configuration.CreateMap<Meeting, MeetingInfoDto>().ReverseMap();
            configuration.CreateMap<MeetingAbsenteeUser, MeetingAbsenteeUserDto>().ReverseMap();
            configuration.CreateMap<MeetingAttendUser, MeetingAttendUserDto>().ReverseMap();
            configuration.CreateMap<Meeting, MeetingListDto>().ReverseMap();
            configuration.CreateMap<Meeting, MeetingsDto>().ReverseMap();


            //Facilities-DataCenter
            configuration.CreateMap<BusinessProcess, BusinessProcessDetailDto>().ReverseMap();
            configuration.CreateMap<FacilitieDatacenter, BusinessProcessListDto>().ReverseMap();
            configuration.CreateMap<FacilitieDatacenter, FacilitieDatacenterListDto>().ReverseMap();
            configuration.CreateMap<FacilitieDatacenter, FacilitieDatacenterDto>().ReverseMap();
            configuration.CreateMap<FacilitieDatacenterITService, FacilitieDatacenterITServiceDto>().ReverseMap();
            configuration.CreateMap<FacilitieDatacenterProcess, FacilitieDatacenterProcessDto>().ReverseMap();
            configuration.CreateMap<FacilitieDatacenterService, FacilitieDatacenterServiceDto>().ReverseMap();
            configuration.CreateMap<FacilitieDatacenter, GetFacilitiesDatacenterListDto>().ReverseMap();

            //Hardware Asset

            configuration.CreateMap<HardwareAsset, HardwareAssetDto>().ReverseMap();
           
            configuration.CreateMap<HardwareAsset, HardwareAssetListDto>().ReverseMap();
            configuration.CreateMap<HardwareAssetITservice, HardwareAssetITserviceDto>().ReverseMap();
            configuration.CreateMap<HardwareAssetBusinessprocess, HardwareAssetBusinessprocessDto>().ReverseMap();
            configuration.CreateMap<HardwareAssetBusinessService, HardwareAssetBusinessServiceDto>().ReverseMap();
           
            //Assetinformation
            configuration.CreateMap<AssetInformation,GetAssetInformationDto>().ReverseMap();
            configuration.CreateMap<AssetInformation, GetAssetInformationListDto>().ReverseMap();
            configuration.CreateMap<AssetInformationITservice, AssetInformationITserviceDto>().ReverseMap();
            configuration.CreateMap<AssetInformationBusinessprocess, AssetInformationBusinessprocessDto>().ReverseMap();
            configuration.CreateMap<AssetInformationBusinessService, AssetInformationBusinessServiceDto>().ReverseMap();
            configuration.CreateMap<AssetInformation, AssetInformationListDto>().ReverseMap();

            //Virtual Asset
            configuration.CreateMap<VirtualAsset, VirtualAssetDto>().ReverseMap();
            configuration.CreateMap<VirtualAsset, ParentVirtualHostListDto>().ReverseMap();
            configuration.CreateMap<VirtualAsset, VirtualAssetListDto>().ReverseMap();
            configuration.CreateMap<VirtualAssetITservice, VirtualAssetITserviceDto>().ReverseMap();
            configuration.CreateMap<VirtualAssetBusinessprocess,VirtualAssetBusinessprocessDto>().ReverseMap();
            configuration.CreateMap<VirtualAssetBusinessService,VirtualAssetBusinessServiceDto>().ReverseMap();
            // Systeam Application 
            configuration.CreateMap<SystemApplication, SystemApplicationDto>().ReverseMap();
            configuration.CreateMap<SystemApplication, SystemApplicationListDto>().ReverseMap();
            configuration.CreateMap<SysteamApplicationITservice, SysteamApplicationITserviceDto>().ReverseMap();
            configuration.CreateMap<SysteamApplicationBusinessProcess, SysteamApplicationBusinessProcessDto>().ReverseMap();
            configuration.CreateMap<SystemApplicationService,SystemApplicationServiceDto>().ReverseMap();
            configuration.CreateMap<SystemApplication, SytemApplicationDto>().ReverseMap();
            
            //Findings
            configuration.CreateMap<Finding, FindingInfoDto>().ReverseMap();
            configuration.CreateMap<Finding, FindingListDto>().ReverseMap();
            configuration.CreateMap<FindingAssetInformation, FindingAssetInformationDto>().ReverseMap();
            configuration.CreateMap<FindingAuthoratativeSource, FindingAuthoratativeSourceDto>().ReverseMap();
            configuration.CreateMap<FindingBusinessUnit, FindingBusinessUnitDto>().ReverseMap();
            configuration.CreateMap<FindingControlDesign, FindingControlDesignDto>().ReverseMap();
            configuration.CreateMap<FindingControlOperating, FindingControlOperatingDto>().ReverseMap();
            configuration.CreateMap<FindingFacilitieDatacenter, FindingFacilitieDatacenterDto>().ReverseMap();
            configuration.CreateMap<FindingHardwareAsset, FindingHardwareAssetDto>().ReverseMap();
            configuration.CreateMap<FindingIncident, FindingIncidentDto>().ReverseMap();
            configuration.CreateMap<FindingInternalControl, FindingInternalControlDto>().ReverseMap();
            configuration.CreateMap<FindingOrganization, FindingOrganizationDto>().ReverseMap();
            configuration.CreateMap<FindingRiskRegister, FindingRiskRegisterDto>().ReverseMap();
            configuration.CreateMap<FindingStrategicObjective, FindingStrategicObjectiveDto>().ReverseMap();
            configuration.CreateMap<FindingSystemsApplication, FindingSystemsApplicationDto>().ReverseMap();
            configuration.CreateMap<FindingVendor, FindingVendorDto>().ReverseMap();
            configuration.CreateMap<FindingVirtualHost, FindingVirtualHostDto>().ReverseMap();
            configuration.CreateMap<FindingVirtualMachine, FindingVirtualMachineDto>().ReverseMap();
            configuration.CreateMap<HardwareAsset, HardwareAsseDetailListDto>().ReverseMap();
            configuration.CreateMap<ControlDesign,ControlDesignListDto>().ReverseMap();
            configuration.CreateMap<ControlOperatingTest, ControlOperatingListDto>().ReverseMap();
            configuration.CreateMap<VirtualAsset, VirtualListDto>().ReverseMap();
            configuration.CreateMap<Vendor, VendorListDto>().ReverseMap();
            configuration.CreateMap<Finding, FindingDetailsDto>().ReverseMap();

            //Audit
            configuration.CreateMap<Audit,AuditDto>().ReverseMap();
            configuration.CreateMap<Audit, GetAuditListDto>().ReverseMap();
            configuration.CreateMap<AuditAuditor, AuditAuditorDto>().ReverseMap();
            configuration.CreateMap<AuditBusinessProcess, AuditBusinessProcessDto>().ReverseMap();
            configuration.CreateMap<AuditBusinessService, AuditBusinessServiceDto>().ReverseMap();
            configuration.CreateMap<AuditFacilitieDatacenter, AuditFacilitieDatacenterDto>().ReverseMap();
            configuration.CreateMap<AuditTeam, AuditTeamDto>().ReverseMap();
            configuration.CreateMap<AuditVendor, AuditVendorDto>().ReverseMap();
            configuration.CreateMap<AuditAttachment, AuditAttachmentDto>().ReverseMap();
            configuration.CreateMap<AuditFinding, AuditFindingDto>().ReverseMap();
            configuration.CreateMap<AuditSystemApplication, AuditSystemApplicationDto>().ReverseMap();
            configuration.CreateMap<Project, ProjectListDetailsDto>().ReverseMap();
            configuration.CreateMap<AuditFinding, AuditFindingDto>().ReverseMap();


            //Exception 
            configuration.CreateMap<Exception, GetExceptionInfoDto>().ReverseMap();
            configuration.CreateMap<Exception, GetExceptionListDto>().ReverseMap();
            configuration.CreateMap<ExceptionAuditingControl, ExceptionAuditingControlDto>().ReverseMap();
            configuration.CreateMap<ExceptionAuthoratativeDocument, ExceptionAuthoratativeDocumentDto>().ReverseMap();
            configuration.CreateMap<ExceptionBusinessUnit, ExceptionBusinessUnitDto>().ReverseMap();
            configuration.CreateMap<ExceptionCitation, ExceptionCitationDto>().ReverseMap();
            configuration.CreateMap<ExceptionCitationLibrary, ExceptionCitationLibraryDto>().ReverseMap();
            configuration.CreateMap<ExceptionDocument, ExceptionDocumentDto>().ReverseMap();
            configuration.CreateMap<ExceptionOrganization, ExceptionOrganizationDto>().ReverseMap();
            configuration.CreateMap<ExceptionRiskManagement, ExceptionRiskManagementDto>().ReverseMap();
            configuration.CreateMap<ExceptionRemediation, ExceptionRemediationDto>().ReverseMap();
            configuration.CreateMap<PolicyManager, PolicyManagerDto>().ReverseMap();
            configuration.CreateMap<Citation, CitationDto>().ReverseMap();
            configuration.CreateMap<Remediation, RemediationDto>().ReverseMap();
            configuration.CreateMap<AuthoratativeDocuments.AuthoratativeDocument, AuthorativeDocumentDto>().ReverseMap();
            configuration.CreateMap<Vendor, VendorInfoDto>().ReverseMap();
            configuration.CreateMap<VendorProductService, VendorProductServiceDto>().ReverseMap();
            configuration.CreateMap<Vendor,GetVendorListDto>().ReverseMap();

            //contacts
            configuration.CreateMap<Contact, ContactInfoDto>().ReverseMap();
            configuration.CreateMap<Contact,ContactListDto>().ReverseMap();
            configuration.CreateMap<Vendor, VendorsDto>().ReverseMap();

            //contract
            configuration.CreateMap<Contract, ContractDto>().ReverseMap(); 
            configuration.CreateMap<Contract, ContractListDto>().ReverseMap();
            configuration.CreateMap<ContractBusinessProcess, ContractBusinessProcessDto>().ReverseMap();
            configuration.CreateMap<ContractBusinessService, ContractBusinessServiceDto>().ReverseMap();
            configuration.CreateMap<ContractEmployee, ContractEmployeeDto>().ReverseMap();
            configuration.CreateMap<ContractEmployeeNotification, ContractEmployeeNotificationDto>().ReverseMap();
            configuration.CreateMap<ContractITService, ContractITServiceDto>().ReverseMap();
            configuration.CreateMap<ContractRiskTreatment, ContractRiskTreatmentDto>().ReverseMap();
            
        }

    }
}
