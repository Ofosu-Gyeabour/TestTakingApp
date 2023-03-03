using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PETAS.Data.Data;
using PETAS.Models.Domain;
using Microsoft.EntityFrameworkCore;

using System.Diagnostics;


namespace PANTrainerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignedTrainingController : ControllerBase
    {
        private readonly PantrainerContext config;

        public AssignedTrainingController(PantrainerContext _context)
        {
            config = _context;
        }

        [HttpGet("{eID}")]
        public async Task<List<AssignedTraining>> GetAssignedTrainings(int eID)
        {
            //end point gets assigned trainings...using the employee ID
            var aList = await config.AssignedTrainings.Where(a => a.EmployeeId == eID).ToListAsync();

            return aList;
        }

    }
}
