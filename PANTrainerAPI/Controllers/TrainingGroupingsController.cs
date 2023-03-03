using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PETAS.Data.Data;
using Microsoft.EntityFrameworkCore;
using PETAS.Models.Domain;

namespace PANTrainerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingGroupingsController : ControllerBase
    {
        private PantrainerContext _context;

        public TrainingGroupingsController(PantrainerContext context)
        {
            _context = context;
        }

        //GET: /api/TrainingGroupings
        [HttpGet(Name = "GetTrainingGroupings")]
        public async Task<ActionResult<IEnumerable<TrainingGrouping>>> GetTrainingGroupings()
        {
            //var list = await _context.TrainingGroupings.ToListAsync();
            var list = await _context.TrainingGroupings.Include(t => t.Domain).ToListAsync();
            return Ok(list);
        }

        

        [HttpGet("{id}")]
        public async Task<ActionResult<TrainingGrouping>> GetTrainingGrouping(int id)
        {
            try
            {
                if (id != 0)
                {
                    var obj = await _context.TrainingGroupings.FindAsync(id);
                    if (obj == null)
                    {
                        return NotFound();
                    }

                    return Ok(obj);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        //POST: /api/TrainingGroupings
        [HttpPost]
        public async Task<ActionResult<TrainingGrouping>> PostTrainingGrouping(TrainingGrouping trainingGrouping)
        {
            //endpoint saves the data into the data store
            try
            {
                //validation
                if (trainingGrouping != null)
                {
                    _context.TrainingGroupings.Add(trainingGrouping);
                    await _context.SaveChangesAsync();

                    return CreatedAtAction(nameof(GetTrainingGrouping), new { id = trainingGrouping.Id }, trainingGrouping);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


    }
}
