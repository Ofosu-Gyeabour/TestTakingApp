#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PETAS.Data.Data;
using PETAS.Models.Domain;

namespace PANTrainerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingResourceTypesController : ControllerBase
    {
        private readonly PantrainerContext _context;

        public TrainingResourceTypesController(PantrainerContext context)
        {
            _context = context;
        }

        // GET: api/TrainingResourceTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainingResourceType>>> GetTrainingResourceTypes()
        {
            return await _context.TrainingResourceTypes.ToListAsync();
        }

        // GET: api/TrainingResourceTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrainingResourceType>> GetTrainingResourceType(int id)
        {
            var trainingResourceType = await _context.TrainingResourceTypes.FindAsync(id);

            if (trainingResourceType == null)
            {
                return NotFound();
            }

            return trainingResourceType;
        }

        // PUT: api/TrainingResourceTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainingResourceType(int id, TrainingResourceType trainingResourceType)
        {
            if (id != trainingResourceType.Id)
            {
                return BadRequest();
            }

            _context.Entry(trainingResourceType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingResourceTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TrainingResourceTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TrainingResourceType>> PostTrainingResourceType(TrainingResourceType trainingResourceType)
        {
            _context.TrainingResourceTypes.Add(trainingResourceType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrainingResourceType", new { id = trainingResourceType.Id }, trainingResourceType);
        }

        // DELETE: api/TrainingResourceTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainingResourceType(int id)
        {
            var trainingResourceType = await _context.TrainingResourceTypes.FindAsync(id);
            if (trainingResourceType == null)
            {
                return NotFound();
            }

            _context.TrainingResourceTypes.Remove(trainingResourceType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrainingResourceTypeExists(int id)
        {
            return _context.TrainingResourceTypes.Any(e => e.Id == id);
        }
    }
}
