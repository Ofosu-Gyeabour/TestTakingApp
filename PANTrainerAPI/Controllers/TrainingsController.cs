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
using PETAS.Models.Domain.HRMS;

namespace PANTrainerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingsController : ControllerBase
    {
        private readonly PantrainerContext _context;

        public TrainingsController(PantrainerContext context)
        {
            _context = context;
        }

        // GET: api/Trainings
        [HttpGet]
        public async Task<ActionResult<List<Training>>> GetTraining()
        {
            var results = await _context.Training.Include(t => t.TrainingTypeNavigation)
                                                        .Include(t => t.TrainingStatus)
                                                        .Include(t => t.TrainingGroup)
                                                        .Include(t => t.TrainingCertification).ToListAsync();
            return Ok(results);
        }

        // GET: api/Trainings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Training>> GetTraining(int id)
        {
            var training = await _context.Training.Where(x => x.Id == id)
                                                       .Include(t => t.TrainingStatus)
                                                        .Include(t => t.TrainingGroup)
                                                        .Include(t => t.TrainingCertification).FirstOrDefaultAsync();

            if (training == null)
            {
                return NotFound();
            }

            return training;
        }

        // PUT: api/Trainings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTraining(int id, Training training)
        {
            if (id != training.Id)
            {
                return BadRequest();
            }

            _context.Entry(training).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingExists(id))
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

        // POST: api/Trainings
        [HttpPost]
        public async Task<ActionResult<Training>> PostTraining(Training training)
        {
            _context.Training.Add(training);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTraining", new { id = training.Id }, training);
        }

        [HttpPost("PostTrainingRecord")]
        public async Task<bool> PostTrainingRecord(JObject data)
        {
            if (data == null)
            {
                return false;
            }

            var trainingType = data["ttype"].ToObject<TrainingType>();
            var trainingGroup = data["tgroup"].ToObject<TrainingGrouping>();
            var trainingCert = data["tcert"].ToObject<TrainingCertification>();
            var obj = data["obj"].ToObject<Training>();

            _context.Training.Add(obj);
            await _context.SaveChangesAsync();

            return true;
        }

        // DELETE: api/Trainings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTraining(int id)
        {
            var training = await _context.Training.FindAsync(id);
            if (training == null)
            {
                return NotFound();
            }

            _context.Training.Remove(training);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrainingExists(int id)
        {
            return _context.Training.Any(e => e.Id == id);
        }
    
        [HttpPost("AssignTrainingToEmployee")]
        public async Task<bool> AssignTraining(JObject data)
        {
            if (data == null)
            {
                return false;
            }

            var objTraining = data["training"].ToObject<Training>();
            var objEmployee = data["emp"].ToObject<Employee>();
            var strUser = data["user"].ToString();

            var obj = new AssignedTraining() {
                EmployeeId = (int?)objEmployee.EmployeeId,
                FirstName = objEmployee.FirstName,
                LastName = objEmployee.LastName,
                EmailAddress = objEmployee.EmailAddress,
                TrainingId = (int?)objTraining.Id,
                TrainingStatusID = 1,   //PENDING
                AssignedBy = strUser,
                AssignedDate = DateTime.Now,
                ApprovedBy = strUser,
                ApprovedDate = DateTime.Now
            };

            await _context.AssignedTrainings.AddAsync(obj);
            await _context.SaveChangesAsync();

            return true;
        }

        [HttpGet("Administrator/{username}")]
        public async Task<bool> isAdmin(string username)
        {
            //endpoint determines if user is on the administrator list in the database
            if (username == string.Empty)
            {
                return false;
            }

            var list = await _context.AdmLists.Where(x => x.IsActive == 1).ToListAsync();
            var bln = list.Exists(x => x.UserName.Contains(username));
            return bln;
        }

    }
}
