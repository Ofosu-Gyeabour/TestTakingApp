#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PETAS.Data.Data;
using PETAS.Models.Domain;

namespace PANTrainerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingDomainsController : ControllerBase
    {
        private readonly PantrainerContext _context;

        public TrainingDomainsController(PantrainerContext context)
        {
            _context = context;
        }

        // GET: api/TrainingDomains
        //[DisableCors]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainingDomain>>> GetTrainingDomains()
        {
            return await _context.TrainingDomains.ToListAsync();
        }

        // GET: api/TrainingDomains/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrainingDomain>> GetTrainingDomain(int id)
        {
            var trainingDomain = await _context.TrainingDomains.FindAsync(id);

            if (trainingDomain == null)
            {
                return NotFound();
            }

            return trainingDomain;
        }

        // GET: api/TrainingDomains/{string}
        [HttpGet("{param}")]
        public async Task<ActionResult<TrainingDomain>> GetTrainingDomain(string param)
        {
            if (param == string.Empty)
            {
                return BadRequest();
            }

            var trainingDomain = await _context.TrainingDomains.Where(x => x.DomainName == param).FirstOrDefaultAsync<TrainingDomain>();

            if (trainingDomain == null)
            {
                return NotFound();
            }

            return trainingDomain;
        }

        // PUT: api/TrainingDomains/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainingDomain(int id, TrainingDomain trainingDomain)
        {
            if (id != trainingDomain.Id)
            {
                return BadRequest();
            }

            _context.Entry(trainingDomain).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingDomainExists(id))
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

        // POST: api/TrainingDomains
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TrainingDomain>> PostTrainingDomain(TrainingDomain trainingDomain)
        {
            try
            {
                if (trainingDomain != null)
                {
                    _context.TrainingDomains.Add(trainingDomain);
                    await _context.SaveChangesAsync();

                    return CreatedAtAction(nameof(GetTrainingDomain), new { id = trainingDomain.Id }, trainingDomain);
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

        // DELETE: api/TrainingDomains/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainingDomain(int id)
        {
            var trainingDomain = await _context.TrainingDomains.FindAsync(id);
            if (trainingDomain == null)
            {
                return NotFound();
            }

            _context.TrainingDomains.Remove(trainingDomain);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrainingDomainExists(int id)
        {
            return _context.TrainingDomains.Any(e => e.Id == id);
        }
    }
}
