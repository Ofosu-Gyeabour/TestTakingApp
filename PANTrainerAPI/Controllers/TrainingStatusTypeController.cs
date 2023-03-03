using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PETAS.Data.Data;
using PETAS.Models.Domain;

namespace PANTrainerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingStatusTypeController : ControllerBase
    {
        //instantiating a db context variable
        private PantrainerContext config;

        public TrainingStatusTypeController(PantrainerContext _context)
        {
            config = _context;
        }

        [HttpGet(Name = "GetTrainingStatusType")]
        public async Task<ActionResult<IEnumerable<TrainingStatusType>>> GetTrainingStatusType()
        {
            //end point fetches all training status types from the data store
            var trainingStatusList = await config.TrainingStatusTypes.ToListAsync();
            return Ok(trainingStatusList);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<TrainingStatusType>> GetTrainingStatusType(int Id)
        {
            //end point fetches a single object/record from the data store
            var o = await config.TrainingStatusTypes.FindAsync(Id);

            if (o == null)
            {
                return NotFound();
            }

            return Ok(o);
        }

    }
}
