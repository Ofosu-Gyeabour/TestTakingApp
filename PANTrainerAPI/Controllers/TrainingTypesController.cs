﻿#nullable disable
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
    public class TrainingTypesController : ControllerBase
    {
        private readonly PantrainerContext _context;

        public TrainingTypesController(PantrainerContext context)
        {
            _context = context;
        }

        // GET: api/TrainingTypes
        [HttpGet]
        public async Task<ActionResult<List<TrainingType>>> GetTrainingTypes()
        {
            return await _context.TrainingTypes.ToListAsync();
        }

        // GET: api/TrainingTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrainingType>> GetTrainingType(int id)
        {
            var trainingType = await _context.TrainingTypes.FindAsync(id);

            if (trainingType == null)
            {
                return NotFound();
            }

            return trainingType;
        }

        // PUT: api/TrainingTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainingType(int id, TrainingType trainingType)
        {
            if (id != trainingType.Id)
            {
                return BadRequest();
            }

            _context.Entry(trainingType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingTypeExists(id))
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

        // POST: api/TrainingTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TrainingType>> PostTrainingType(TrainingType trainingType)
        {
            _context.TrainingTypes.Add(trainingType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrainingType", new { id = trainingType.Id }, trainingType);
        }

        // DELETE: api/TrainingTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainingType(int id)
        {
            var trainingType = await _context.TrainingTypes.FindAsync(id);
            if (trainingType == null)
            {
                return NotFound();
            }

            _context.TrainingTypes.Remove(trainingType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrainingTypeExists(int id)
        {
            return _context.TrainingTypes.Any(e => e.Id == id);
        }
    }
}
