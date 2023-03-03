using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PETAS.Models.Domain;
using PETAS.Data.Data;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace PANTrainerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly PantrainerContext config;

        public TestController(PantrainerContext _context)
        {
            config = _context;
        }

        [HttpGet("Administrator/{username}")]
        public async Task<bool> isAdmin(string username)
        {
            try
            {
                var list = await config.AdmLists.ToListAsync();
                var bln = list.Exists(x => x.UserName == username);
                return bln;
            }
            catch(Exception ex)
            {
                Debug.Print($"error: {ex.Message}");
                return false;
            }
        }

    }
}
