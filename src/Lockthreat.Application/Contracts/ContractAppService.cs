using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Lockthreat.BusinessEntities;
using Lockthreat.BusinessProcesses;
using Lockthreat.BusinessProcesses.Dto;
using Lockthreat.BusinessServices;
using Lockthreat.BusinessServices.Dto;
using Lockthreat.Common;
using Lockthreat.Contacts.Dto;
using Lockthreat.Contracts.Dto;
using Lockthreat.Countries;
using Lockthreat.FacilitieDatacenters;
using Lockthreat.ITServices;
using Lockthreat.OrganizationSetup.Dto;
using Lockthreat.OrganizationSetups;
using Lockthreat.Vendors;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Linq.Extensions;
using System.Linq.Dynamic.Core;
using Abp.Extensions;
using Lockthreat.Dto;
using Lockthreat.Contracts.ExportExcel;

namespace Lockthreat.Contracts
{
   public class ContractAppService : LockthreatAppServiceBase, IContractAppService
    {
        private readonly IRepository<ITService, long> _itservicesRepository;
        private readonly IRepository<BusinessUnit, long> _businessUnitRepository;
        private readonly IRepository<BusinessProcess, long> _businessProcessRepository;
        private readonly IRepository<BusinessService, long> _businessServicesRepository;
        private readonly ICountriesAppservice _countriesAppservice;
        private readonly IRepository<LockThreatOrganization, long> _organizationSetupRepository;
        private readonly ICodeGeneratorCommonAppservice _codegeneratorRepository;
        private readonly IRepository<Employees.Employee, long> _employessRepository;
        private readonly IRepository<Contract, long> _contractRepository;
        private readonly IRepository<ContractBusinessProcess, long> _contractBusinessProcessRepository;
        private readonly IRepository<ContractBusinessService, long> _contractBusinessServiceRepository;
        private readonly IRepository<ContractEmployee, long> _contractEmployeeRepository;
        private readonly IRepository<ContractEmployeeNotification, long> _contractEmployeeNotificationRepository;
        private readonly IRepository<ContractITService, long> _contractITServiceRepository;
        private readonly IRepository<ContractRiskTreatment,long> _contractRiskTreatmentRepository;
        private readonly IRepository<Vendor, long> _vendorRepository;
        private readonly IContractExcelExporter _iContractExcelExporterRepository;

        public ContractAppService(
           IContractExcelExporter iContractExcelExporterRepository,
           IRepository<Vendor, long> vendorRepository,
           IRepository<Contract, long> contractRepository,
           IRepository<ContractBusinessProcess, long> contractBusinessProcessRepository,
           IRepository<ContractBusinessService, long> contractBusinessServiceRepository,
           IRepository<ContractEmployee, long> contractEmployeeRepository,
           IRepository<ContractEmployeeNotification, long> contractEmployeeNotificationRepository,
           IRepository<ContractITService, long> contractITServiceRepository,
           IRepository<ContractRiskTreatment, long> contractRiskTreatmentRepository,
           IRepository<BusinessProcess, long> businessProcessRepository,
           IRepository<Employees.Employee, long> employessRepository,
           ICodeGeneratorCommonAppservice codegeneratorRepository,
           IRepository<BusinessUnit, long> businessUnitRepository,
           ICountriesAppservice countriesAppservice,
           IRepository<BusinessService, long> businessServicesRepository,
           IRepository<LockThreatOrganization, long> organizationSetupRepository,           
           IRepository<ITService, long> itservicesRepository           
           )
        {
            _iContractExcelExporterRepository = iContractExcelExporterRepository;
            _vendorRepository = vendorRepository;
            _contractRiskTreatmentRepository = contractRiskTreatmentRepository;
            _contractITServiceRepository = contractITServiceRepository;
            _contractEmployeeNotificationRepository = contractEmployeeNotificationRepository;
            _contractEmployeeRepository = contractEmployeeRepository;
            _contractRepository = contractRepository;
            _contractBusinessProcessRepository = contractBusinessProcessRepository;
            _contractBusinessServiceRepository = contractBusinessServiceRepository;
            _employessRepository = employessRepository;
            _businessProcessRepository = businessProcessRepository;
            _codegeneratorRepository = codegeneratorRepository;
            _businessUnitRepository = businessUnitRepository;
            _organizationSetupRepository = organizationSetupRepository;
            _countriesAppservice = countriesAppservice;
            _businessServicesRepository = businessServicesRepository;          
            _itservicesRepository = itservicesRepository;
        }

        public async Task<ContractDto> GetAllContractInfo (long? contractId  )
        {
            try
            {
                var contract = new ContractDto();
                var contractById = new Contract();

                if (contractId > 0)
                {
                    contractById = await _contractRepository.GetAll().FirstOrDefaultAsync(p => p.Id == contractId);
                }

                if (contractById.Id > 0)
                {
                    contract = ObjectMapper.Map<ContractDto>(contractById);
                    contract.SelectedContractBusinessProcess = ObjectMapper.Map<List<ContractBusinessProcessDto>>(await _contractBusinessProcessRepository.GetAll().Where(p => p.ContractId == contractById.Id).ToListAsync());
                    contract.SelectedContractBusinessService = ObjectMapper.Map<List<ContractBusinessServiceDto>>(await _contractBusinessServiceRepository.GetAll().Where(p => p.ContractId == contractById.Id).ToListAsync());
                    contract.SelectedContractEmployee = ObjectMapper.Map<List<ContractEmployeeDto>>(await _contractEmployeeRepository.GetAll().Where(p => p.ContractId == contractById.Id).ToListAsync());
                    contract.SelectedContractEmployeeNotification = ObjectMapper.Map<List<ContractEmployeeNotificationDto>>(await _contractEmployeeNotificationRepository.GetAll().Where(p => p.ContractId == contractById.Id).ToListAsync());
                    contract.SelectedContractRiskTreatment = ObjectMapper.Map<List<ContractRiskTreatmentDto>>(await _contractRiskTreatmentRepository.GetAll().Where(p => p.ContractsId == contractById.Id).ToListAsync());
                    contract.SelectedContractITService = ObjectMapper.Map<List<ContractITServiceDto>>(await _contractITServiceRepository.GetAll().Where(p => p.ContractId == contractById.Id).ToListAsync());
                }
                var employees = await _employessRepository.GetAll().Include(e => e.LockThreatOrganization).ToListAsync();
                contract.EmployeesList = ObjectMapper.Map<List<BusinessServiceOwner>>(employees);
                contract.CompanyLists = ObjectMapper.Map<List<GetOrganizationDto>>(await _organizationSetupRepository.GetAll().ToListAsync());
                contract.Vendors = ObjectMapper.Map<List<VendorsDto>>(await _vendorRepository.GetAll().ToListAsync());
                contract.ITserviceLists = ObjectMapper.Map<List<ITserviceListDto>>(await _itservicesRepository.GetAll().ToListAsync());
                contract.ContractCategorys = await _countriesAppservice.GetContractCategory();
                contract.ContractTypes = await _countriesAppservice.GetContractType();
                contract.BusinessProcess = ObjectMapper.Map<List<BusinessProcessDetailDto>>(await _businessProcessRepository.GetAll().ToListAsync());
                contract.BusinessServices = ObjectMapper.Map<List<BusinessServiceSDto>>(await _businessServicesRepository.GetAll().ToListAsync());
                return contract;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task CreateOrUpdateContract (ContractDto input)
        {
            try
            {
                if (string.IsNullOrEmpty(input.ContractId))
                {
                    input.ContractId = _codegeneratorRepository.GetNextId(LockthreatConsts.CNT, "CNT");
                }
                input.TenantId = AbpSession.TenantId;      
                if(input.Id > 0)
                {
                    var contract  = await _contractRepository.
                        GetAll().
                        Include(x => x.SelectedContractBusinessProcess).
                        Include(x=>x.SelectedContractBusinessService).
                        Include(x=>x.SelectedContractEmployee).
                        Include(x=>x.SelectedContractEmployeeNotification).
                        Include(x=>x.SelectedContractITService).
                        Include(x=>x.SelectedContractRiskTreatment).
                        FirstOrDefaultAsync(x => x.Id == input.Id);
                    await _contractBusinessProcessRepository.HardDeleteAsync(r => r.ContractId == input.Id);
                    await _contractBusinessServiceRepository.HardDeleteAsync(r => r.ContractId == input.Id);
                    await _contractEmployeeNotificationRepository.HardDeleteAsync(r => r.ContractId == input.Id);                  
                    await _contractITServiceRepository.HardDeleteAsync(r => r.ContractId == input.Id);
                    await _contractRiskTreatmentRepository.HardDeleteAsync(r => r.ContractsId == input.Id);                   
                    ObjectMapper.Map(input, contract);
                }

                if (input.Id == 0)
                {
                    await _contractRepository.InsertOrUpdateAsync(ObjectMapper.Map<Contract>(input));
                    await _codegeneratorRepository.CodeCreate(LockthreatConsts.CNT, "CNT");
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<PagedResultDto<ContractListDto>> GetAllContractList (ContractInputDto input)
        {
            IQueryable<Contract> querys;
            try
            {
                querys = _contractRepository.GetAll()
                    .Include(p => p.LockThreatOrganization)
                    .Include(p => p.ContractCategory)
                    .Include(p => p.Vendor).
                     Include(p => p.ContractType).
                     Include(x => x.Employee)
                    .WhereIf(!input.Filter.IsNullOrWhiteSpace(), u => u.ContractId.Contains(input.Filter.Trim()) || u.ContractTitle.Contains(input.Filter.Trim()) || 
                        u.LockThreatOrganization.CompanyName.Contains(input.Filter.Trim()) ||
                        u.ContractType.Value.Contains(input.Filter.Trim()) ||
                        u.ContractReference.Contains(input.Filter.Trim()) ||
                        u.ContractCategory.Value.Contains(input.Filter.Trim()) ||
                        u.Vendor.VendorName.Contains(input.Filter.Trim()))         
                    .WhereIf(!input.ContractId.IsNullOrWhiteSpace(), u => u.ContractId.Contains(input.ContractId.Trim()))
                      .WhereIf(!input.Description.IsNullOrWhiteSpace(), u => u.Description.Contains(input.Description.Trim()))
                    .WhereIf(!input.ContractCategory.IsNullOrWhiteSpace(), u => u.ContractCategory.Value.Contains(input.ContractCategory.Trim()))
                    .WhereIf(!input.ContractReference.IsNullOrWhiteSpace(), u => u.ContractReference.Contains(input.ContractReference.Trim()))
                    .WhereIf(!input.ContractTitle.IsNullOrWhiteSpace(), u => u.ContractTitle.Contains(input.ContractTitle.Trim()))
                    .WhereIf(!input.ContractType.IsNullOrWhiteSpace(), u => u.ContractType.Value.Contains(input.ContractType.Trim()))
                    .WhereIf(!input.Vendor.IsNullOrWhiteSpace(), u => u.Vendor.VendorName.Contains(input.Vendor.Trim()))
                    .WhereIf(!input.LockThreatOrganization.IsNullOrWhiteSpace(), u => u.LockThreatOrganization.CompanyName.Contains(input.LockThreatOrganization.Trim()));

                var query = await (from o in querys
                                   select new ContractListDto()
                                   {
                                       ContractId = o.ContractId,
                                       ContractTitle = o.ContractTitle,
                                       ContractReference = o.ContractReference,
                                       ContractCategory = o.ContractCategory == null ? "" : o.ContractCategory.Value.ToString(),
                                       ContractType = o.ContractType == null ? "" : o.ContractType.Value.ToString(),
                                       ContractValue= o.ContractValue,
                                       Description = o.Description,
                                       Id = o.Id,
                                       Employee = o.Employee == null ? "" : o.Employee.Name.ToString(),
                                       EndDate = o.EndDate,
                                       StartDate = o.StartDate,
                                       TenantId = o.TenantId,
                                       Vendor = o.Vendor == null ? "" : o.Vendor.VendorName.ToString(),                                      
                                       LockThreatOrganization = o.LockThreatOrganization == null ? "" : o.LockThreatOrganization.CompanyName.ToString()
                                   }).OrderBy(input.Sorting).PageBy(input).ToListAsync();

                var contractCount  = await querys.CountAsync();

                return new PagedResultDto<ContractListDto>(
                      contractCount,
                     query
                    ); 
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<FileDto> GetContractToExcel(ContractExcelInputDto input)
        {
            try
            {
                var querys = _contractRepository.GetAll() 
                    .Include(p => p.LockThreatOrganization)
                    .Include(p => p.ContractCategory)
                    .Include(p => p.Vendor).
                     Include(p => p.ContractType).
                     Include(x => x.Employee)
                    .WhereIf(!input.Filter.IsNullOrWhiteSpace(), u => u.ContractId.Contains(input.Filter.Trim()) || u.ContractTitle.Contains(input.Filter.Trim()) ||
                        u.LockThreatOrganization.CompanyName.Contains(input.Filter.Trim()) ||
                        u.ContractType.Value.Contains(input.Filter.Trim()) ||
                        u.ContractReference.Contains(input.Filter.Trim()) ||
                        u.ContractCategory.Value.Contains(input.Filter.Trim()) ||
                        u.Vendor.VendorName.Contains(input.Filter.Trim()))
                    .WhereIf(!input.ContractId.IsNullOrWhiteSpace(), u => u.ContractId.Contains(input.ContractId.Trim()))
                      .WhereIf(!input.Description.IsNullOrWhiteSpace(), u => u.Description.Contains(input.Description.Trim()))
                    .WhereIf(!input.ContractCategory.IsNullOrWhiteSpace(), u => u.ContractCategory.Value.Contains(input.ContractCategory.Trim()))
                    .WhereIf(!input.ContractReference.IsNullOrWhiteSpace(), u => u.ContractReference.Contains(input.ContractReference.Trim()))
                    .WhereIf(!input.ContractTitle.IsNullOrWhiteSpace(), u => u.ContractTitle.Contains(input.ContractTitle.Trim()))
                    .WhereIf(!input.ContractType.IsNullOrWhiteSpace(), u => u.ContractType.Value.Contains(input.ContractType.Trim()))
                    .WhereIf(!input.Vendor.IsNullOrWhiteSpace(), u => u.Vendor.VendorName.Contains(input.Vendor.Trim()))
                    .WhereIf(!input.LockThreatOrganization.IsNullOrWhiteSpace(), u => u.LockThreatOrganization.CompanyName.Contains(input.LockThreatOrganization.Trim()));

                var query = await (from o in querys
                                   select new ContractListDto()
                                   {
                                       ContractId = o.ContractId,
                                       ContractTitle = o.ContractTitle,
                                       ContractReference = o.ContractReference,
                                       ContractCategory = o.ContractCategory == null ? "" : o.ContractCategory.Value.ToString(),
                                       ContractType = o.ContractType == null ? "" : o.ContractType.Value.ToString(),
                                       ContractValue = o.ContractValue,
                                       Description = o.Description,
                                       Id = o.Id,
                                       Employee = o.Employee == null ? "" : o.Employee.Name.ToString(),
                                       EndDate = o.EndDate,
                                       StartDate = o.StartDate,
                                       TenantId = o.TenantId,
                                       Vendor = o.Vendor == null ? "" : o.Vendor.VendorName.ToString(),
                                       LockThreatOrganization = o.LockThreatOrganization == null ? "" : o.LockThreatOrganization.CompanyName.ToString()
                                   }).ToListAsync();

                var contractlistDtos = query.ToList();

                return _iContractExcelExporterRepository.ExportToFile(contractlistDtos, "Contract");
            }
            catch (Exception ex)
            { 
                throw;
            }

        }

        public async Task RemoveContract (long ContractId )
        {
            try
            {
                var contact = await _contractRepository.GetAll().Where(p => p.Id == ContractId).Include(x=>x.SelectedContractBusinessProcess).Include(x=>x.SelectedContractBusinessService).
                     Include(x=>x.SelectedContractEmployee).Include(x=>x.SelectedContractEmployeeNotification).Include(x=>x.SelectedContractITService).
                    FirstOrDefaultAsync();

                await _contractRepository.DeleteAsync(contact);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
