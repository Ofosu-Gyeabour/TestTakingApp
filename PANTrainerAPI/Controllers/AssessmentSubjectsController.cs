#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PETAS.Data.Data;
//using PANTrainerAPI.Models;

using PETAS.Models.Domain;

namespace PANTrainerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssessmentSubjectsController : ControllerBase
    {
        private readonly PantrainerContext _context;

        public AssessmentSubjectsController(PantrainerContext context)
        {
            _context = context;
        }

        // GET: api/AssessmentSubjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssessmentSubject>>> GetAssessmentSubjects()
        {
            return await _context.AssessmentSubjects.ToListAsync();
        }

        // GET: api/AssessmentSubjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AssessmentSubject>> GetAssessmentSubject(int id)
        {
            var assessmentSubject = await _context.AssessmentSubjects.FindAsync(id);

            if (assessmentSubject == null)
            {
                return NotFound();
            }

            return assessmentSubject;
        }

        // PUT: api/AssessmentSubjects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssessmentSubject(int id, AssessmentSubject assessmentSubject)
        {
            if (id != assessmentSubject.Id)
            {
                return BadRequest();
            }

            _context.Entry(assessmentSubject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssessmentSubjectExists(id))
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

        // POST: api/AssessmentSubjects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AssessmentSubject>> PostAssessmentSubject(AssessmentSubject assessmentSubject)
        {
            if (assessmentSubject == null)
            {
                return BadRequest();
            }

            _context.AssessmentSubjects.Add(assessmentSubject);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AssessmentSubjectExists(assessmentSubject.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAssessmentSubject", new { id = assessmentSubject.Id }, assessmentSubject);
        }

        // DELETE: api/AssessmentSubjects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssessmentSubject(int id)
        {
            var assessmentSubject = await _context.AssessmentSubjects.FindAsync(id);
            if (assessmentSubject == null)
            {
                return NotFound();
            }

            _context.AssessmentSubjects.Remove(assessmentSubject);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AssessmentSubjectExists(int id)
        {
            return _context.AssessmentSubjects.Any(e => e.Id == id);
        }
    }
}
