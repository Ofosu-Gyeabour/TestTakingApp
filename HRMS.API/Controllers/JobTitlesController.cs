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
    public class JobTitlesController : ControllerBase
    {
        private readonly HRMSContext config;

        public JobTitlesController(HRMSContext _context)
        {
            config = _context;
        }

        //GET: api/jobtitles
        [HttpGet]
        public async Task<ActionResult<List<JobTitle>>> GetJobTitles()
        {
            return await config.JobTitles.ToListAsync();
        }

        //GET api/jobtitle/id
        [HttpGet("{jID}")]
        public async Task<ActionResult<JobTitle>> GetJobTitle(int jID)
        {
            //gets the job title for a supplied employee ID
            var obj = await config.JobTitles.Where(jt => jt.JobTitleId == jID).FirstOrDefaultAsync();
            return obj;
        }

    }
}
