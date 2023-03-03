using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using PETAS.Classes;
using System.Text;
using Newtonsoft.Json;

namespace PETAS.Services
{
    public interface ISecureAccessService
    {
        Task<User> Login(User model);
    }

    public class SecureAccessService: ISecureAccessService
    {
        private readonly HttpClient http;
        private readonly SecureAccessClient secureAccessClient;
        public SecureAccessService(SecureAccessClient _secureAccessClient)
        {
            secureAccessClient = _secureAccessClient;
            http = secureAccessClient.http;
        }

        
        public async Task<User> Login(User model)
        {
            try
            {
                var posted = await http.PostAsJsonAsync("api/User", new string[] { model.username, model.pass });
                var result = await posted.Content.ReadFromJsonAsync<bool>();

                if (result)
                {
                    return model;
                }
                else 
                {
                    //return new user with Id=0
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
