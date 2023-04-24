using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Lockthreat.Common;
using Lockthreat.Countries;
using Lockthreat.Vendors.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Linq.Extensions;
using System.Linq.Dynamic.Core;
using Abp.Extensions;
using Lockthreat.Dto;
using Lockthreat.Vendors.ExportExcel;

namespace Lockthreat.Vendors
{
  public   class VendorAppService : LockthreatAppServiceBase, IVendorAppService
    {
        private readonly IRepository<Vendor, long> _vendorRepository;
        private readonly ICountriesAppservice _countriesAppservice;
        private readonly ICodeGeneratorCommonAppservice _codegeneratorRepository;
        private readonly IRepository<VendorProductService, long> _vendorProductServiceRepository;
        private readonly IVendorExcelExporter _iVendorExcelExporterRepository;
        public VendorAppService (
           IRepository<Vendor, long> vendorRepository,
           ICountriesAppservice countriesAppservice,
           IVendorExcelExporter iVendorExcelExporterRepository,
           ICodeGeneratorCommonAppservice codegeneratorRepository,
           IRepository<VendorProductService, long> vendorProductServiceRepository
           )
        {
            _vendorRepository = vendorRepository;
            _codegeneratorRepository = codegeneratorRepository;
            _countriesAppservice = countriesAppservice;
            _iVendorExcelExporterRepository = iVendorExcelExporterRepository;
            _vendorProductServiceRepository = vendorProductServiceRepository;
        }

        public async Task<PagedResultDto<GetVendorListDto>> GetAllVendorList(VendorInputDto input)
        {
            try
            {
                var query = _vendorRepository.GetAllIncluding().
                    Include(x => x.VendorCriticalRating).
                    Include(c => c.Industry).
                    Include(y => y.VendorInitialRating).
                    Include(e => e.Country).
                    Include(f => f.VendorType)                   
                    .WhereIf(!input.ContactFirstName.IsNullOrWhiteSpace(), u => u.ContactFirstName.Contains(input.ContactFirstName.Trim()))
                    .WhereIf(!input.ContactLastName.IsNullOrWhiteSpace(), u => u.ContactLastName.Contains(input.ContactLastName.Trim()))
                    .WhereIf(!input.VendorId.IsNullOrWhiteSpace(), u => u.VendorId.Contains(input.VendorId.Trim()))
                    .WhereIf(!input.Email.IsNullOrWhiteSpace(), u => u.Email.Contains(input.Email.Trim()))
                    .WhereIf(!input.CellPhoneNumber.IsNullOrWhiteSpace(), u => u.CellPhoneNumber.Contains(input.CellPhoneNumber.Trim()))
                    .WhereIf(!input.Industry.IsNullOrWhiteSpace(), u => u.Industry.Value.Contains(input.Industry.Trim()))
                    .WhereIf(!input.VendorInitialRating.IsNullOrWhiteSpace(), u => u.VendorInitialRating.Value.Contains(input.VendorInitialRating.Trim()))
                    .WhereIf(!input.VendorCriticalRating.IsNullOrWhiteSpace(), u => u.VendorCriticalRating.Value.Contains(input.VendorCriticalRating.Trim()))
                    .WhereIf(!input.VendorType.IsNullOrWhiteSpace(), u => u.VendorType.Value.Contains(input.VendorType.Trim()))
                    .WhereIf(!input.Filter.IsNullOrWhiteSpace(), u => u.VendorId.Contains(input.Filter.Trim()) || u.VendorName.Contains(input.Filter.Trim()) ||
                        u.VendorCriticalRating.Value.Contains(input.Filter.Trim()) ||
                        u.VendorInitialRating.Value.Contains(input.Filter.Trim()) ||
                        u.VendorType.Value.Contains(input.Filter.Trim()) ||
                        u.PhoneNumber.Contains(input.Filter.Trim()) || u.Industry.Value.Contains(input.Filter.Trim()) ||
                        u.Country.Value.Contains(input.Filter.Trim()));

                var vendorCount  = await query.CountAsync();

                var vendorItems = await query
                    .OrderBy(input.Sorting)
                    .PageBy(input)
                    .ToListAsync();

                var vendorItemsDtos = ObjectMapper.Map<List<GetVendorListDto>>(vendorItems);

                return new PagedResultDto<GetVendorListDto>(
                   vendorCount,
                   vendorItemsDtos
                   );
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<VendorInfoDto> GetAllVendorInfo(long? VendorId )
        {
            try
            {
                var vendorInfo  = new VendorInfoDto();
                var VendorById = new Vendor();
                if (VendorId > 0)
                {
                    VendorById = await _vendorRepository.GetAll().FirstOrDefaultAsync(p => p.Id == VendorId);
                }
                if (VendorById.Id > 0)
                {
                    vendorInfo = ObjectMapper.Map<VendorInfoDto>(VendorById);
                    vendorInfo.SelectedVendorProductServices = ObjectMapper.Map<List<VendorProductServiceDto>>(await _vendorProductServiceRepository.GetAll().Where(p => p.VendorId == VendorById.Id).ToListAsync());
                }
                vendorInfo.VendorTypes = await _countriesAppservice.GetVendorType();
                vendorInfo.VendorInitialRatings = await _countriesAppservice.GetAvailibility();
                vendorInfo.VendorCriticalRatings = await _countriesAppservice.GetAvailibility();
                vendorInfo.Industrys = await _countriesAppservice.GetIndustroy ();
                vendorInfo.Countrys = await _countriesAppservice.GetAll();
                vendorInfo.VendorProductList = await _countriesAppservice.GetVendorProductType();
                return vendorInfo;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task CreateOrUpdateVendor (VendorInfoDto input)
        {
            try
            {
                if (string.IsNullOrEmpty(input.VendorId))
                {
                    input.VendorId = _codegeneratorRepository.GetNextId(LockthreatConsts.VEN, "VEN");
                }
                input.TenantId = AbpSession.TenantId;

                if (input.Id > 0)
                {

                    var vendors = await _vendorRepository.
                        GetAll().
                        Include(x => x.SelectedVendorProductServices).FirstOrDefaultAsync(x => x.Id == input.Id);
                    await _vendorProductServiceRepository.HardDeleteAsync(r => r.VendorId == input.Id);
                    ObjectMapper.Map(input, vendors);
                }

                if (input.Id == 0)
                {
                    await _vendorRepository.InsertOrUpdateAsync(ObjectMapper.Map<Vendor>(input));
                    await _codegeneratorRepository.CodeCreate(LockthreatConsts.VEN, "VEN");
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task RemoveVendorProdutType(long id)
        {
            try
            {
                var itservice = await _vendorProductServiceRepository.FirstOrDefaultAsync(e => e.Id == id);
                await _vendorProductServiceRepository.DeleteAsync(itservice);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task RemovedVendor(long VendorId )
        {
            try
            {
                var vendor  = await _vendorRepository.GetAll().Where(p => p.Id == VendorId).Include(p => p.SelectedVendorProductServices).FirstOrDefaultAsync();

                if (vendor.SelectedVendorProductServices.Count > 0)
                {
                    foreach (var item in vendor.SelectedVendorProductServices)
                    {
                        await RemoveVendorProdutType(item.Id);
                    }
                }


                await _vendorRepository.DeleteAsync(vendor);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<FileDto> GetVendorExcel (VendorExcelInputDto input)
        {
           
            try
            {
                var query = _vendorRepository.GetAllIncluding().
                     Include(x => x.VendorCriticalRating).
                     Include(c => c.Industry).
                     Include(y => y.VendorInitialRating).
                     Include(e => e.Country).
                     Include(f => f.VendorType)
                     .WhereIf(!input.ContactFirstName.IsNullOrWhiteSpace(), u => u.ContactFirstName.Contains(input.ContactFirstName.Trim()))
                     .WhereIf(!input.ContactLastName.IsNullOrWhiteSpace(), u => u.ContactLastName.Contains(input.ContactLastName.Trim()))
                     .WhereIf(!input.VendorId.IsNullOrWhiteSpace(), u => u.VendorId.Contains(input.VendorId.Trim()))
                     .WhereIf(!input.Email.IsNullOrWhiteSpace(), u => u.Email.Contains(input.Email.Trim()))
                     .WhereIf(!input.CellPhoneNumber.IsNullOrWhiteSpace(), u => u.CellPhoneNumber.Contains(input.CellPhoneNumber.Trim()))
                     .WhereIf(!input.Industry.IsNullOrWhiteSpace(), u => u.Industry.Value.Contains(input.Industry.Trim()))
                     .WhereIf(!input.VendorInitialRating.IsNullOrWhiteSpace(), u => u.VendorInitialRating.Value.Contains(input.VendorInitialRating.Trim()))
                     .WhereIf(!input.VendorCriticalRating.IsNullOrWhiteSpace(), u => u.VendorCriticalRating.Value.Contains(input.VendorCriticalRating.Trim()))
                     .WhereIf(!input.VendorType.IsNullOrWhiteSpace(), u => u.VendorType.Value.Contains(input.VendorType.Trim()))
                     .WhereIf(!input.Filter.IsNullOrWhiteSpace(), u => u.VendorId.Contains(input.Filter.Trim()) || u.VendorName.Contains(input.Filter.Trim()) ||
                         u.VendorCriticalRating.Value.Contains(input.Filter.Trim()) ||
                         u.VendorInitialRating.Value.Contains(input.Filter.Trim()) ||
                         u.VendorType.Value.Contains(input.Filter.Trim()) ||
                         u.PhoneNumber.Contains(input.Filter.Trim()) || u.Industry.Value.Contains(input.Filter.Trim()) ||
                         u.Country.Value.Contains(input.Filter.Trim()));

              //  var vendorDtos = query.ToList();

                var vendorlistDto  = ObjectMapper.Map<List<GetVendorListDto>>(query);
                return _iVendorExcelExporterRepository.ExportToFile(vendorlistDto, "vendorExcel");
            }
            catch (Exception ex)
            {
                throw;
            }

        }

    }
}
