using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PETAS.Data.Data;
using PETAS.Models.Domain;

namespace PANTrainerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingAssessmentsController : ControllerBase
    {
        private readonly PantrainerContext config;

        public TrainingAssessmentsController(PantrainerContext _context)
        {
            config = _context;
        }

        //GET: api/TrainingAssessments

        //GET: api/TrainingAssessments/id
        [HttpGet("{id}")]
        public async Task<ActionResult<TrainingAssessment>> GetTrainingAssessment(int id)
        {
            var obj = await config.TrainingAssessments.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }
        //POST: api/TrainingAssessments
        [HttpPost]
        public async Task<ActionResult> PostTrainingAssessments(TrainingAssessment obj)
        {
            //post a training assessment
            config.TrainingAssessments.Add(obj);
            await config.SaveChangesAsync();

            return CreatedAtAction("GetTrainingAssessment", new { id = obj.Id }, obj);
        }
    }
}
