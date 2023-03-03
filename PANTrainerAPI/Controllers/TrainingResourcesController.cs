#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using PETAS.Data.Data;
using PETAS.Models.Domain;

namespace PANTrainerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingResourcesController : ControllerBase
    {
        private readonly PantrainerContext _context;

        public TrainingResourcesController(PantrainerContext context)
        {
            _context = context;
        }

        // GET: api/TrainingResources
        [HttpGet]
        public async Task<ActionResult<List<TrainingResource>>> GetTrainingResources()
        {
            //return await _context.TrainingResources.ToListAsync();
            return await _context.TrainingResources.Include(t => t.TrainingResourceNavigation).ToListAsync();
        }

        // GET: api/TrainingResources/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrainingResource>> GetTrainingResource(int id)
        {
            var trainingResource = await _context.TrainingResources.FindAsync(id);

            if (trainingResource == null)
            {
                return NotFound();
            }

            return trainingResource;
        }

        [HttpPut("UpdateTrainingResource/{id}")]
        public async Task<bool> UpdateTrainingResource(JObject data)
        {
            if (data == null)
            {
                return false;
            }

            var obj = data["obj"].ToObject<TrainingResource>();
            try
            {
                _context.Entry(obj).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return true;
            }
            catch(Exception x)
            {
                if (!TrainingResourceExists(obj.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainingResource(int id, TrainingResource trainingResource)
        {
            if (id != trainingResource.Id)
            {
                return BadRequest();
            }

            _context.Entry(trainingResource).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingResourceExists(id))
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

        
        [HttpPost]
        public async Task<ActionResult<TrainingResource>> PostTrainingResource(TrainingResource trainingResource)
        {
            _context.TrainingResources.Add(trainingResource);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrainingResource", new { id = trainingResource.Id }, trainingResource);
        }

        [HttpPost("CreateTrainingResourceWithTraining")]
        public async Task<bool> CreateTrainingResource(JObject data)
        {
            if (data == null)
            {
                return false;
            }

            try
            {
                var obj = data["obj"].ToObject<TrainingResource>();
                if (obj == null) { return false; }

                await _context.TrainingResources.AddAsync(obj);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception x)
            {
                return false;
            }
        }

        // DELETE: api/TrainingResources/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainingResource(int id)
        {
            var trainingResource = await _context.TrainingResources.FindAsync(id);
            if (trainingResource == null)
            {
                return NotFound();
            }

            _context.TrainingResources.Remove(trainingResource);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrainingResourceExists(int id)
        {
            return _context.TrainingResources.Any(e => e.Id == id);
        }
    }
}
