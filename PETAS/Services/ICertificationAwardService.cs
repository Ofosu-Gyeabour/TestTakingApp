using PETAS.Models.Domain;
using System.Net.Http.Json;
namespace PETAS.Services
{
    public interface ICertificationAwardService
    {
        Task<IEnumerable<CertificationAwarder>> GetCertificationAwarders();

        Task<CertificationAwarder> SaveCertificationAwarder(CertificationAwarder objAwarder);
    }

    public class CertificationAwardService : ICertificationAwardService
    {

        private readonly HttpClient http;

        public CertificationAwardService(HttpClient _httpClient)
        {
            http = _httpClient;
        }

        public async Task<IEnumerable<CertificationAwarder>> GetCertificationAwarders()
        {
            var _dat = await http.GetFromJsonAsync<CertificationAwarder[]>("api/CertificationAwarders");
            return _dat;
        }

        public async Task<CertificationAwarder> SaveCertificationAwarder(CertificationAwarder objAwarder)
        {
            //method perist object via API call
            var response = await http.PostAsJsonAsync<CertificationAwarder>("api/CertificationAwarders", objAwarder);
            return await response.Content.ReadFromJsonAsync<CertificationAwarder>();
        }

    }

}
