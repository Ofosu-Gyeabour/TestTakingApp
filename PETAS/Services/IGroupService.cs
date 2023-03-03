using PETAS.Classes;
using System.Net;
using System.Net.Http.Json;
using PETAS.Models.Domain;

namespace PETAS.Services
{
    public interface IGroupService
    {
        public Task<TrainingGrouping> CreateGroup(TrainingGrouping _group);

        public Task<IEnumerable<TrainingGrouping>> GetAllGroups();
    }

    public class GroupService: IGroupService
    {

        public HttpClient _http;
        
        public GroupService(HttpClient http)
        {
            _http = http;
        }

        public async Task<TrainingGrouping> CreateGroup(TrainingGrouping _group)
        {
            //method calls the API endpoint that saves the data into the data store
            var result = await _http.PostAsJsonAsync("api/TrainingGroupings", _group);
            return await result.Content.ReadFromJsonAsync<TrainingGrouping>();
            
        }

        public async Task<IEnumerable<TrainingGrouping>> GetAllGroups()
        {
            return await _http.GetFromJsonAsync<IEnumerable<TrainingGrouping>>("api/TrainingGroupings");
        }

    }

}
