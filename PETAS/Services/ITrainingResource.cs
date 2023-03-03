using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Diagnostics;
using System.Collections;
using PETAS.Models.Domain;

namespace PETAS.Services
{
    public interface ITrainingResourceService
    {
        public Task<List<TrainingResource>> GetTrainingResourcesAsync();
        public Task<bool> SaveTrainingResourceAsync(TrainingResource trainingResource, Training training, string usrName);
        public Task<bool> UpdateTrainingResourceAsync(TrainingResource obj);
    }

    public class TrainingResourceService: ITrainingResourceService
    {
        private readonly HttpClient http;

        public TrainingResourceService(HttpClient _httpClient)
        {
            http = _httpClient;
        }

        public async Task<List<TrainingResource>> GetTrainingResourcesAsync()
        {
            return await http.GetFromJsonAsync<List<TrainingResource>>("api/TrainingResources");
        }

        public async Task<bool> SaveTrainingResourceAsync(TrainingResource trainingResource, Training training, string usrName)
        {
            try
            {
                trainingResource.Id = 0;   //turning identity insert off
                
                trainingResource.TrainingId = training.Id;
                trainingResource.CreatedDate = DateTime.Now;
                trainingResource.CreatedBy = usrName;

                var obj = new TrainingResource() { 
                    TrainingId = trainingResource.TrainingId,
                    ResourceName = trainingResource.ResourceName,
                    TrainingResourceId = trainingResource.TrainingResourceId,
                    IsEmbedded = trainingResource.IsEmbedded,
                    ResourcePath = trainingResource.ResourcePath,
                    EmbeddedResource = trainingResource.EmbeddedResource,
                    CreatedDate = trainingResource.CreatedDate,
                    CreatedBy = usrName
                };

                var postBody = new { obj, training };
                var results = await http.PostAsJsonAsync("api/TrainingResources/CreateTrainingResourceWithTraining", postBody);
                return await results.Content.ReadFromJsonAsync<bool>();
            }
            catch(Exception x)
            {
                return false;
            }
        }

        public async Task<bool> UpdateTrainingResourceAsync(TrainingResource obj)
        {
            //api/TrainingResources/5
            var postBody = new { obj };
            var results = await http.PutAsJsonAsync("api/TrainingResources/UpdateTrainingResource" + "/" + obj.Id, postBody);
            return await results.Content.ReadFromJsonAsync<bool>();
        }

    }
}
