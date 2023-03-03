using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;

namespace PETAS.Services
{
    public class SecureAccessClient
    {
        public HttpClient http { get; }

        public SecureAccessClient(HttpClient _httpClient)
        {
            http = _httpClient;
        }
    }
}
