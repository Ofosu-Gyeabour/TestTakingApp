namespace PETAS.Services
{
    public class MailClient
    {
        public HttpClient http { get; }

        public MailClient(HttpClient _httpClient)
        {
            http = _httpClient;
        }
    }
}
