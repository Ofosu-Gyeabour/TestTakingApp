using Microsoft.Extensions.Http;
namespace PETAS.Services
{
    public class HRMSClient
    {
        public HttpClient http { get; }

        public HRMSClient(HttpClient _httpClient)
        {
            http = _httpClient;
        }

       
    }

}
