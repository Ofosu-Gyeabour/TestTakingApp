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
    public class ObjectiveClassesController : ControllerBase
    {
        private readonly PantrainerContext _context;

        public ObjectiveClassesController(PantrainerContext context)
        {
            _context = context;
        }

        // GET: api/ObjectiveClasses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ObjectiveClass>>> GetObjectiveClasses()
        {
            return await _context.ObjectiveClasses.ToListAsync();
        }

        // GET: api/ObjectiveClasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ObjectiveClass>> GetObjectiveClass(int id)
        {
            //var objectiveClass = await _context.ObjectiveClasses.FindAsync(id);
            var objectiveClass = await _context.ObjectiveClasses.Where(x => x.QuestionId == id).FirstOrDefaultAsync();
            if (objectiveClass == null)
            {
                return NotFound();
            }

            return objectiveClass;
        }

        // PUT: api/ObjectiveClasses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutObjectiveClass(int id, ObjectiveClass objectiveClass)
        {
            if (id != objectiveClass.Id)
            {
                return BadRequest();
            }

            _context.Entry(objectiveClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObjectiveClassExists(id))
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

        // POST: api/ObjectiveClasses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ObjectiveClass>> PostObjectiveClass(ObjectiveClass objectiveClass)
        {
            _context.ObjectiveClasses.Add(objectiveClass);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetObjectiveClass", new { id = objectiveClass.Id }, objectiveClass);
        }

        // DELETE: api/ObjectiveClasses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteObjectiveClass(int id)
        {
            var objectiveClass = await _context.ObjectiveClasses.FindAsync(id);
            if (objectiveClass == null)
            {
                return NotFound();
            }

            _context.ObjectiveClasses.Remove(objectiveClass);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ObjectiveClassExists(int id)
        {
            return _context.ObjectiveClasses.Any(e => e.Id == id);
        }
    }
}
