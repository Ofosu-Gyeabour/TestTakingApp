using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using System.Security.Cryptography;
using PETAS.Data.Data;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PANTrainerAPI.Controllers
{
    //using PANTrainerAPI.Models;

    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        [HttpGet("gethashedpassword")]
        public async Task<string> HashPassword(string password)
        {
            string _hashedPwd = string.Empty;
            using (MD5 md5Hash = MD5.Create())
            {
                _hashedPwd = await GetMd5Hash(md5Hash, password);
            }

            return _hashedPwd;
        }

        private Task<string> GetMd5Hash(MD5 md5hash, string input)
        {
            //convert input string to a byte array and compute the hash
            byte[] data = md5hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("x2"));
            }

            return Task.FromResult(sb.ToString());
        }

    }
}
