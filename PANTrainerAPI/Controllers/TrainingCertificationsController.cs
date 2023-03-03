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
    public class TrainingCertificationsController : ControllerBase
    {
        private readonly PantrainerContext _context;

        public TrainingCertificationsController(PantrainerContext context)
        {
            _context = context;
        }

        // GET: api/TrainingCertifications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainingCertification>>> GetTrainingCertifications()
        {
            return await _context.TrainingCertifications
                                    .Include(c => c.CertificationAwarded).ToListAsync();
        }

        //GET: api/TrainingCertifications/id
        [HttpGet("{id}")]
        public async Task<ActionResult<TrainingCertification>> GetTrainingCertification(int id)
        {
            //gets a training certification object using its id
            var obj = await _context.TrainingCertifications.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }
            
            return obj;
        }

        //POST: api/PostTrainingCertification
        [HttpPost(Name ="PostTrainingCertification")]
        public async Task<ActionResult>PostTrainingCertification(TrainingCertification obj)
        {
            //posts a training certification
            _context.TrainingCertifications.Add(obj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrainingCertification", new { id = obj.Id }, obj);
        }

    }
}
