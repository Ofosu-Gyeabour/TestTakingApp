using Microsoft.AspNetCore.Components;
using PETAS.Classes;
using System.Net;
using System.Net.Http.Json;

using Blazored.LocalStorage;

namespace PETAS.Services
{
    public interface IUserAccountService
    {
        Task<bool> Login(User LoginInformation, string connString);
        Task<bool> Logout();
        Task Initialize();
    }

    public class UserAccountService
        : IUserAccountService
    {
        private readonly HttpClient http;
        private ILocalStorageService localStore;

        public UserAccountService(HttpClient _httpclient, ILocalStorageService _localS)
        {
            http = _httpclient;
            localStore = _localS;
        }

        public async Task<bool> Login(User LoginInformation, string connString)
        {
            //encrypt provided password
            if (LoginInformation == null)
            {
                return false;
            }

            if (connString == null)
            {
                return false;
            }

            try
            {
                var res = await http.GetAsync("api/security/gethashedpassword?password=" + LoginInformation.pass);
                var str = await res.Content.ReadAsStringAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }  
        }

        public async Task<bool> Logout()
        {
            //task handling the logging out of a user. remove all local storage
            await localStore.ClearAsync();
            return true;
        }

        public Task Initialize()
        {
            return Task.CompletedTask;
        }
    }
}
