using System.Net.Http.Json;
using System.Net.Http;
using PETAS.Models.Domain;

namespace PETAS.Services
{
    public interface ITrainingResourceTypeService
    {

        public Task<IEnumerable<TrainingResourceType>> GetTrainingResourceTypes();

        public Task<TrainingResourceType> SaveTrainingResource(TrainingResourceType obj);
    }

    public class TrainingResourceTypeService: ITrainingResourceTypeService
    {

        private readonly HttpClient http;

        public TrainingResourceTypeService(HttpClient htclient)
        {
            http = htclient;
        }

        public async Task<IEnumerable<TrainingResourceType>> GetTrainingResourceTypes()
        {
            //method is used to get the training resource types for the WASM...asynchronously
            return await http.GetFromJsonAsync<TrainingResourceType[]>("api/TrainingResourceTypes");
        }

        public async Task<TrainingResourceType> SaveTrainingResource(TrainingResourceType obj)
        {
            //providing additional data for obj object
            obj.CreatedDate = DateTime.Now;
            obj.CreatedById = 1; //to be provided by local storage 
            var response = await http.PostAsJsonAsync<TrainingResourceType>("api/TrainingResourceTypes", obj);
            return await response.Content.ReadFromJsonAsync<TrainingResourceType>();
        }

    }

}
