using Abp.Application.Services;
using Lockthreat.UploadFiles.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Lockthreat.Fileupload
{
   public interface IFileUploadAppService : IApplicationService
    {
        Task<List<string>> UploadFiles(List<UploadFileDto> input);
        Task RenameImage(string fileName, string newFileName, string credentia);
      
        Task<string> DeleteFiles(List<string> fileNames);
        Task<Tuple<MemoryStream, string>> DownloadFileFromBlob(string imageName, string credentia);
    }
}
