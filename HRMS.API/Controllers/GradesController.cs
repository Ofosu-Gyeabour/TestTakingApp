using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PETAS.Data.Data;
using PETAS.Models.Domain.HRMS;

namespace HRMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly HRMSContext config;

        public GradesController(HRMSContext _context)
        {
            config = _context;
        }

        //GET api/Grades
        [HttpGet]
        public async Task<ActionResult<List<Grade>>> GetGrades()
        {
            return await config.Grades.ToListAsync();
        }
    }
}
