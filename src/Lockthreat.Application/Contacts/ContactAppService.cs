
using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Lockthreat.Countries;
using Lockthreat.OrganizationSetups;
using Lockthreat.OrganizationSetup.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using Lockthreat.Common;
using Lockthreat.Vendors;
using Lockthreat.Contacts.ExportExcel;
using Lockthreat.Contacts.Dto;
using Lockthreat.Dto;
using Lockthreat.BusinessServices.Dto;

namespace Lockthreat.Contacts
{
  public  class ContactAppService : LockthreatAppServiceBase,IContactAppService
    {
        private readonly ICountriesAppservice _countriesAppservice;
        private readonly IRepository<LockThreatOrganization, long> _organizationSetupRepository;
        private readonly ICodeGeneratorCommonAppservice _codegeneratorRepository;
        private readonly IRepository<Employees.Employee, long> _employessRepository;
        private readonly IRepository<Contact, long> _contactRepository;
        private readonly IRepository<Vendor, long> _vendorRepository;
        private readonly IContactExcelExporter _contactExcelExporter;
        public ContactAppService (
            IRepository<Vendor, long> vendorRepository,
            IRepository<Contact, long> contactRepository,
           IRepository<Employees.Employee, long> employessRepository,
           ICodeGeneratorCommonAppservice codegeneratorRepository,
           ICountriesAppservice countriesAppservice,
           IContactExcelExporter contactExcelExporter,
           IRepository<LockThreatOrganization, long> organizationSetupRepository           
           )
        {
            _contactExcelExporter = contactExcelExporter;
            _vendorRepository = vendorRepository;
            _contactRepository = contactRepository;
            _employessRepository = employessRepository;
            _codegeneratorRepository = codegeneratorRepository;
            _organizationSetupRepository = organizationSetupRepository;
            _countriesAppservice = countriesAppservice;            
        }

        public async Task<ContactInfoDto> GetAllContactsInfo (long? ContactId )
        {
            try
            {
                var contactinfo  = new ContactInfoDto();
                var contactById  = new Contact();
                if (ContactId > 0)
                {
                    contactById = await _contactRepository.GetAll().FirstOrDefaultAsync(p => p.Id == ContactId);
                }
                if (contactById.Id > 0)
                {
                    contactinfo = ObjectMapper.Map<ContactInfoDto>(contactById);                    
                }

                var employees = await _employessRepository.GetAll().Include(e => e.LockThreatOrganization).ToListAsync();
                contactinfo.EmployeesList = ObjectMapper.Map<List<BusinessServiceOwner>>(employees);
                contactinfo.CompanyLists = ObjectMapper.Map<List<GetOrganizationDto>>(await _organizationSetupRepository.GetAll().ToListAsync());
                contactinfo.Vendors = ObjectMapper.Map<List<VendorsDto>>(await _vendorRepository.GetAll().ToListAsync());
                contactinfo.ContactTypes = await _countriesAppservice.GetContactType();
                contactinfo.Countries = await _countriesAppservice.GetAll();

                return contactinfo;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task CreateOrUpdateContact (ContactInfoDto input)
        {
            try
            {
                if (string.IsNullOrEmpty(input.ContactId))
                {
                    input.ContactId = _codegeneratorRepository.GetNextId(LockthreatConsts.CON, "CON");
                }
                input.TenantId = AbpSession.TenantId;             
                await _contactRepository.InsertOrUpdateAsync(ObjectMapper.Map<Contact>(input));
                if (input.Id == 0)
                {
                    await _codegeneratorRepository.CodeCreate(LockthreatConsts.CON, "CON");
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<PagedResultDto<ContactListViewDto>> GetAllContactList(ContactInputDto input)
        {
            IQueryable<Contact> querys ;
            try
            {
                querys = _contactRepository.GetAll().Include(p => p.LockThreatOrganization)
                    .Include(p => p.LoginUser)
                    .Include(p => p.Vendor).Include(p => p.ContactType).Include(x => x.Country)
                    .WhereIf(!input.Filter.IsNullOrWhiteSpace(), u => u.ContactId.Contains(input.Filter.Trim()) || u.MobileNo.Contains(input.Filter.Trim()) || u.MobileNo.Contains(input.Filter.Trim()) || u.LoginUser.Name.Contains(input.Filter.Trim()) ||
                        u.LockThreatOrganization.CompanyName.Contains(input.Filter.Trim()) ||
                        u.jobTitle.Contains(input.Filter.Trim()) ||
                        u.Email.Contains(input.Filter.Trim()) ||
                        u.FirstName.Contains(input.Filter.Trim()) ||
                        u.Vendor.VendorName.Contains(input.Filter.Trim()))
                    .WhereIf(!input.FirstName.IsNullOrWhiteSpace(), u => u.FirstName.Contains(input.FirstName.Trim()) || u.LastName.Contains(input.FirstName.Trim()))
                    .WhereIf(!input.ContactId.IsNullOrWhiteSpace(), u => u.ContactId.Contains(input.ContactId.Trim()))
                    .WhereIf(!input.jobTitle.IsNullOrWhiteSpace(), u => u.jobTitle.Contains(input.jobTitle.Trim()))
                    .WhereIf(!input.PhoneNumber.IsNullOrWhiteSpace(), u => u.PhoneNumber.Contains(input.PhoneNumber.Trim()))
                    .WhereIf(!input.Email.IsNullOrWhiteSpace(), u => u.Email.Contains(input.Email.Trim()))
                    .WhereIf(!input.MobileNo.IsNullOrWhiteSpace(), u => u.MobileNo.Contains(input.MobileNo.Trim()))
                    .WhereIf(!input.VendorFilter.IsNullOrWhiteSpace(), u => u.Vendor.VendorName.Contains(input.VendorFilter.Trim()))
                    .WhereIf(!input.LockThreatOrganizationFilter.IsNullOrWhiteSpace(), u => u.LockThreatOrganization.CompanyName.Contains(input.LockThreatOrganizationFilter.Trim()));

                var query = await (from o in querys
                                   select new ContactListViewDto()
                                   {
                                       ContactId = o.ContactId,
                                       FirstName = o.FirstName,
                                       LastName = o.LastName,
                                       AddressOne = o.AddressOne,
                                       City = o.City,
                                       State = o.State,
                                       jobTitle = o.jobTitle,
                                       Id = o.Id,
                                       Country = o.Country==null?"":o.Country.Value.ToString(),
                                       MobileNo=o.MobileNo,
                                       PhoneNumber=o.PhoneNumber,
                                       Email=o.Email,
                                       Vendor = o.Vendor == null ? "" : o.Vendor.VendorName.ToString(),
                                       LoginUser = o.LoginUser == null ? "" : o.LoginUser.Name.ToString(),
                                       LockThreatOrganization = o.LockThreatOrganization == null ? "" : o.LockThreatOrganization.CompanyName.ToString()
                                   }).OrderBy(input.Sorting).PageBy(input).ToListAsync();

                var contactCount = await querys.CountAsync();

                return new PagedResultDto<ContactListViewDto>(
                    contactCount,
                    query
                    );                
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task RemoveContact (long ContactId )
        {
            try
            {
                var contact = await _contactRepository.GetAll().Where(p => p.Id == ContactId).FirstOrDefaultAsync();              
                await _contactRepository.DeleteAsync(contact);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<FileDto> GetContactToExcel(ContactExcelInputDto input)
        {
            try
            {
              var  querys = _contactRepository.GetAll().Include(p => p.LockThreatOrganization)
                  .Include(p => p.LoginUser)
                  .Include(p => p.Vendor).Include(p => p.ContactType).Include(x => x.Country)
                  .WhereIf(!input.Filter.IsNullOrWhiteSpace(), u => u.ContactId.Contains(input.Filter.Trim()) || u.MobileNo.Contains(input.Filter.Trim()) || u.MobileNo.Contains(input.Filter.Trim()) || u.LoginUser.Name.Contains(input.Filter.Trim()) ||
                      u.LockThreatOrganization.CompanyName.Contains(input.Filter.Trim()) ||
                      u.jobTitle.Contains(input.Filter.Trim()) ||
                      u.Email.Contains(input.Filter.Trim()) ||
                      u.FirstName.Contains(input.Filter.Trim()) ||
                      u.Vendor.VendorName.Contains(input.Filter.Trim()))
                  .WhereIf(!input.FirstName.IsNullOrWhiteSpace(), u => u.FirstName.Contains(input.FirstName.Trim()) || u.LastName.Contains(input.FirstName.Trim()))
                  .WhereIf(!input.ContactId.IsNullOrWhiteSpace(), u => u.ContactId.Contains(input.ContactId.Trim()))
                  .WhereIf(!input.jobTitle.IsNullOrWhiteSpace(), u => u.jobTitle.Contains(input.jobTitle.Trim()))
                  .WhereIf(!input.PhoneNumber.IsNullOrWhiteSpace(), u => u.PhoneNumber.Contains(input.PhoneNumber.Trim()))
                  .WhereIf(!input.Email.IsNullOrWhiteSpace(), u => u.Email.Contains(input.Email.Trim()))
                  .WhereIf(!input.MobileNo.IsNullOrWhiteSpace(), u => u.MobileNo.Contains(input.MobileNo.Trim()))
                  .WhereIf(!input.VendorFilter.IsNullOrWhiteSpace(), u => u.Vendor.VendorName.Contains(input.VendorFilter.Trim()))
                  .WhereIf(!input.LockThreatOrganizationFilter.IsNullOrWhiteSpace(), u => u.LockThreatOrganization.CompanyName.Contains(input.LockThreatOrganizationFilter.Trim()));

                var query = await (from o in querys
                                   select new ContactListViewDto()
                                   {
                                       ContactId = o.ContactId,
                                       FirstName = o.FirstName,
                                       LastName = o.LastName,
                                       AddressOne = o.AddressOne,
                                       City = o.City,
                                       State = o.State,
                                       jobTitle = o.jobTitle,
                                       Id = o.Id,
                                       Country = o.Country == null ? "" : o.Country.Value.ToString(),
                                       MobileNo = o.MobileNo,
                                       PhoneNumber = o.PhoneNumber,
                                       Email = o.Email,
                                       Vendor = o.Vendor == null ? "" : o.Vendor.VendorName.ToString(),
                                       LoginUser = o.LoginUser == null ? "" : o.LoginUser.Name.ToString(),
                                       LockThreatOrganization = o.LockThreatOrganization == null ? "" : o.LockThreatOrganization.CompanyName.ToString()
                                   }).ToListAsync();

                var departmentListDtos =  query.ToList();

                return _contactExcelExporter.ExportToFile(departmentListDtos, "Contact");
            }
            catch(Exception ex)
            {
                throw;
            }
           
        }

    }
}
