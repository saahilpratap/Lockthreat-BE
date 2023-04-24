using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.UploadFiles.Dto
{
  public  class UploadFileDto
    {
        public string Base64 { get; set; }
        public string FileName { get; set; }
    }


    public class AzureStorageDto
    {
        public string AccountName { get; set; }
        public string AccountKey { get; set; }
        public string AccountConnString { get; set; }
        public string StaticFilesContainerName { get; set; }
    }
}
