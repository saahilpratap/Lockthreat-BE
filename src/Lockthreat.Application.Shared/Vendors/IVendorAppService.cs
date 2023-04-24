using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Lockthreat.Dto;
using Lockthreat.Vendors.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lockthreat.Vendors
{
  public  interface IVendorAppService : IApplicationService
    {
        Task<PagedResultDto<GetVendorListDto>> GetAllVendorList(VendorInputDto input);
        Task<VendorInfoDto> GetAllVendorInfo(long? VendorId);
        Task CreateOrUpdateVendor(VendorInfoDto input);
        Task RemovedVendor(long VendorId);
        Task<FileDto> GetVendorExcel(VendorExcelInputDto input);
    }
}
