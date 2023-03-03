using PETAS.Models.Domain;
using System.Net.Http;
using System.Net.Http.Json;

namespace PETAS.Services
{
    public interface ITrainingDomainService
    {
        Task<IEnumerable<TrainingDomain>> GetTrainingDomains();

        Task<TrainingDomain> PostTrainingDomain(TrainingDomain objTd);

        Task<int> getDomainID(string strDomainName);
    }

    public class TrainingDomainService : ITrainingDomainService
    {
        private readonly HttpClient _httpclient;

        public TrainingDomainService(HttpClient http)
        {
            _httpclient = http;
        }

        public async Task<IEnumerable<TrainingDomain>> GetTrainingDomains()
        {
            var lst = await _httpclient.GetFromJsonAsync<TrainingDomain[]>("api/TrainingDomains");
            return lst;
        }

        public async Task<TrainingDomain> PostTrainingDomain(TrainingDomain objTd)
        {
            var response = await _httpclient.PostAsJsonAsync<TrainingDomain>("api/TrainingDomains", objTd);
            return await response.Content.ReadFromJsonAsync<TrainingDomain>();
        }

        public async Task<int> getDomainID(string strDomainName)
        {
            return 2;
        }

    }

}
