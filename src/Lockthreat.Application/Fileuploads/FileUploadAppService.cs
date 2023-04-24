using Lockthreat.Fileupload;
using Lockthreat.UploadFiles.Dto;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Lockthreat.Fileuploads
{
 public class FileUploadAppService : LockthreatAppServiceBase, IFileUploadAppService
    {
        private readonly IOptions<AzureStorageDto> _options;

        public FileUploadAppService(IOptions<AzureStorageDto> options)
        {
            _options = options;
        }

        public CloudStorageAccount GetConnectionString()
        {
            _options.Value.AccountName = "ltdevelopment";
            _options.Value.AccountKey = "RLO78anBSlPwvFT42albTAyqBCwaG82Y43pC3dBdzjsCxX41M606cefYceQ8e8AYMjZhlEHwdq2s5j1rhtE3ng==";
            string connectionString = string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}", _options.Value.AccountName, _options.Value.AccountKey);
            return CloudStorageAccount.Parse(connectionString);
        }

        public async Task<CloudBlobContainer> GetCloudBlobContainer()
        {
            try
            {
                string containerName = null;
                CloudBlobContainer container = null;
                var storageAccount = GetConnectionString();
                var blobClient = storageAccount.CreateCloudBlobClient();

                if (AbpSession.TenantId == null)
                    containerName = "host";
                else
                    containerName = GetCurrentTenantAsync().Result.Name.ToLower();

                container = blobClient.GetContainerReference(containerName);
                await container.CreateIfNotExistsAsync();

                await container.SetPermissionsAsync(new BlobContainerPermissions
                {
                    PublicAccess = BlobContainerPublicAccessType.Off
                });

                BlobContainerPermissions permissions = new BlobContainerPermissions();
                permissions.SharedAccessPolicies.Add("DACPolicy", new SharedAccessBlobPolicy()
                {
                    Permissions = SharedAccessBlobPermissions.Read,
                    SharedAccessExpiryTime = DateTime.MaxValue
                });

                await container.SetPermissionsAsync(permissions);
                return container;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

     
        public async Task<List<string>> UploadFiles(List<UploadFileDto> input)
        {

            try
            {
                List<string> result = new List<string>();
                var blobContainer = await GetCloudBlobContainer();
                foreach (var item in input)
                {
                    string[] str = item.Base64.Split(',');
                    int i = str.Length;
                    item.Base64 = str[1];
                    string sasToken = blobContainer.GetSharedAccessSignature(new SharedAccessBlobPolicy(), "DACPolicy");
                    item.FileName = Path.GetFileNameWithoutExtension(item.FileName) + "-" + Guid.NewGuid().ToString() + Path.GetExtension(item.FileName);
                    var blockBlob = blobContainer.GetBlockBlobReference(item.FileName);

                    byte[] bytes = Convert.FromBase64String(item.Base64);
                    await blockBlob.UploadFromByteArrayAsync(bytes, 0, bytes.Length);

                    result.Add(string.Format(System.Globalization.CultureInfo.InvariantCulture, "https://{0}.blob.core.windows.net/{1}/{2}{3}", _options.Value.AccountName, blobContainer.Name, item.FileName, sasToken));
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public async Task RenameImage(string fileName, string newFileName, string credentia)
        {
            var blobContainer = await GetCloudBlobContainer();
            var blob = blobContainer.GetBlockBlobReference(newFileName);

            if (!await blob.ExistsAsync())
            {
                var oldblob = blobContainer.GetBlockBlobReference(fileName);

                if (await oldblob.ExistsAsync())
                {
                    await blob.StartCopyAsync(oldblob);
                    await oldblob.DeleteIfExistsAsync();
                }
            }
        }

        public async Task<Tuple<MemoryStream, string>> DownloadFileFromBlob(string imageName, string credentia)
        {
            try
            {
                // Get Blob Container
                var blobContainer = await GetCloudBlobContainer();
                // Get reference to blob (binary content)
                var blockBlob = blobContainer.GetBlockBlobReference(imageName);
                // get content type
                await blockBlob.FetchAttributesAsync();
                var contentType = blockBlob.Properties.ContentType;

                // Read content            
                var stream = new MemoryStream();
                await blockBlob.DownloadToStreamAsync(stream);
                return new Tuple<MemoryStream, string>(stream, contentType);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<string> DeleteFiles(List<string> fileNames)
        {
            try
            {
                //var blobs = container.ListBlobs();
                var blobContainer = await GetCloudBlobContainer();
                fileNames.ForEach(async fileName =>
                {
                    var blockBlob = blobContainer.GetBlockBlobReference(fileName);
                    await blockBlob.DeleteIfExistsAsync();
                });
                return "Files are deleted.";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #region Functions

        public async Task<string> DeleteAllBlobs(string credentia)
        {

            CloudBlobContainer blobContainer = await GetCloudBlobContainer();
            try
            {
                //Fetches attributes of container
                await blobContainer.FetchAttributesAsync();
                Console.WriteLine("Container exists..");
                await blobContainer.DeleteIfExistsAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return "deleted";
        }
        #endregion
    }
}
