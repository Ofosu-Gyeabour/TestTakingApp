using PETAS.Models.Domain;
using System.Net.Http.Json;

namespace PETAS.Services
{
    public interface IObjectiveService
    {
        public Task<List<ObjectiveClass>> GetAllObjectiveClassAsync();

        public Task<ObjectiveClass> GetObjectiveClassAsync(int _questionID);
    }

    public class ObjectiveService: IObjectiveService
    {
        private readonly HttpClient http;

        public ObjectiveService(HttpClient _httpClient)
        {
            http = _httpClient;
        }

        public async Task<List<ObjectiveClass>> GetAllObjectiveClassAsync()
        {
            return await http.GetFromJsonAsync<List<ObjectiveClass>>("api/ObjectiveClasses");
        }

        public async Task<ObjectiveClass> GetObjectiveClassAsync(int _questionID)
        {
            return await http.GetFromJsonAsync<ObjectiveClass>("api/ObjectiveClasses" + "/" + _questionID.ToString());
        }

    }

}
