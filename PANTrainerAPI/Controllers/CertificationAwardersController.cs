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
    public class CertificationAwardersController : ControllerBase
    {
        private readonly PantrainerContext _context;

        public CertificationAwardersController(PantrainerContext context)
        {
            _context = context;
        }

        // GET: api/CertificationAwarders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CertificationAwarder>>> GetCertificationAwarders()
        {
            return await _context.CertificationAwarders.ToListAsync();
        }

        // GET: api/CertificationAwarders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CertificationAwarder>> GetCertificationAwarder(int id)
        {
            var certificationAwarder = await _context.CertificationAwarders.FindAsync(id);

            if (certificationAwarder == null)
            {
                return NotFound();
            }

            return certificationAwarder;
        }

        // PUT: api/CertificationAwarders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCertificationAwarder(int id, CertificationAwarder certificationAwarder)
        {
            if (id != certificationAwarder.Id)
            {
                return BadRequest();
            }

            _context.Entry(certificationAwarder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CertificationAwarderExists(id))
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

        // POST: api/CertificationAwarders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CertificationAwarder>> PostCertificationAwarder(CertificationAwarder certificationAwarder)
        {
            if (certificationAwarder == null)
            {
                return BadRequest();
            }

            _context.CertificationAwarders.Add(certificationAwarder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCertificationAwarder", new { id = certificationAwarder.Id }, certificationAwarder);
        }

        // DELETE: api/CertificationAwarders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCertificationAwarder(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var certificationAwarder = await _context.CertificationAwarders.FindAsync(id);
            if (certificationAwarder == null)
            {
                return NotFound();
            }

            _context.CertificationAwarders.Remove(certificationAwarder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CertificationAwarderExists(int id)
        {
            return _context.CertificationAwarders.Any(e => e.Id == id);
        }
    }
}
