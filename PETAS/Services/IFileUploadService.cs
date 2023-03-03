using PETAS.Models.Domain.Others;
using System.Net;
using System.Net.Http.Json;

using ExcelDataReader;
using ExcelDataReader.Core;
using System.Diagnostics;
using PETAS.Models.Domain;

namespace PETAS.Services
{
    public interface IFileUploadService
    {
        Task<string> UploadMCASFileContentDbAsync(UploadedFile uploadedFile);
        Task<bool> UploadFileAsync(UploadedFile _file);
        Task<string> UploadWRTANSFileContentDbAsync(UploadedFile uploadedFile);

        Task<bool> TrainingResourceUploadAsync(UploadedFile uploadedFile, TrainingResourceType ttype);

        
    }

    public class FileUploadService: IFileUploadService
    {
        private readonly HttpClient http;
        public FileUploadService(HttpClient httpClient) {
            http = httpClient;
        }

        public async Task<bool> UploadFileAsync(UploadedFile _file)
        {
            //uploads file to the server
            var results = await http.PostAsJsonAsync("api/FileUpload/uploadQuestionFile", _file);
            return await results.Content.ReadFromJsonAsync<bool>();
        }

        
        public async Task<bool> TrainingResourceUploadAsync(UploadedFile uploadedFile, TrainingResourceType ttype)
        {
            //method handles the upload of a training resource
            if (uploadedFile == null)
            {
                return false;
            }

            if (ttype == null)
            {
                return false;
            }
            
            var postBody = new { uploadedFile,ttype };
            var result = await http.PostAsJsonAsync("api/FileUpload/UploadNonVideoResourceToDb", postBody);
            return await result.Content.ReadFromJsonAsync<bool>();
        }

        private Task videoUpload(UploadedFile uploadedFile)
        {
            //converting byte[] to memorystream
            MemoryStream ms = new MemoryStream(uploadedFile.FileContent);
            using (var writer = new BinaryWriter(ms))
            {
                writer.Write(uploadedFile.FileContent);
            }

            using (ms)
            {
                byte[] buffer = new byte[1024];
                int bytesRead = 0;
                while ((bytesRead = ms.Read(buffer, 0, buffer.Length)) > 0)
                {
                    //upload buffer to database..code this in the service
                    //post initial buffer

                    //update subsequent ones

                }
            }

            return Task.CompletedTask;
        }

        public async Task<string> UploadMCASFileContentDbAsync(UploadedFile uploadedFile)
        {
            try
            {
                var results = await http.PostAsJsonAsync("api/FileUpload/uploadMCASFileToDatabase", uploadedFile.FileContent);
                return await results.Content.ReadFromJsonAsync<string>();
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                return $"Error message: {e.Message}";
            }
        }
        
        public async Task<string> UploadWRTANSFileContentDbAsync(UploadedFile uploadedFile)
        {
            try
            {
                var results = await http.PostAsJsonAsync("api/FileUpload/uploadWRTANSFileToDatabase",uploadedFile.FileContent);
                return await results.Content.ReadFromJsonAsync<string>();
            }
            catch(Exception x)
            {
                Debug.Print(x.Message);
                return $"error: {x.Message}";
            }
        }

    }

}
