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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PANTrainerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssessmentQuestionPoolsController : ControllerBase
    {
        private readonly PantrainerContext _context;

        public AssessmentQuestionPoolsController(PantrainerContext context)
        {
            _context = context;
        }

        // GET: api/AssessmentQuestionPools
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssessmentQuestionPool>>> GetAssessmentQuestionPools()
        {
            return await _context.AssessmentQuestionPools.ToListAsync();
        }

        //GET: api/UnApprovedAssessmentQuestionPools
        [HttpGet("UnApproved/{id}")]
        public async Task<ActionResult<IEnumerable<AssessmentQuestionPool>>> GetUnapprovedQuestionPools(int id)
        {
            var dict = await _context.AssessmentQuestionPools.Where(x => x.SubjectId == id).Where(x => x.AuthorizedDate == null).ToListAsync();
            return dict;
        }

        // GET: api/AssessmentQuestionPools/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<AssessmentQuestionPool>> GetAssessmentQuestionPool(int id)
        {
            var assessmentQuestionPool = await _context.AssessmentQuestionPools.Where(x => x.SubjectId == id).ToListAsync();

            return assessmentQuestionPool;
        }

        

        // PUT: api/AssessmentQuestionPools/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssessmentQuestionPool(int id, AssessmentQuestionPool assessmentQuestionPool)
        {
            if (id != assessmentQuestionPool.Id)
            {
                return BadRequest();
            }

            _context.Entry(assessmentQuestionPool).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssessmentQuestionPoolExists(id))
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

        // POST: api/AssessmentQuestionPools
        [HttpPost]
        public async Task<ActionResult<AssessmentQuestionPool>> PostAssessmentQuestionPool(AssessmentQuestionPool assessmentQuestionPool)
        {
            _context.AssessmentQuestionPools.Add(assessmentQuestionPool);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssessmentQuestionPool", new { id = assessmentQuestionPool.Id }, assessmentQuestionPool);
        }

        // DELETE: api/AssessmentQuestionPools/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssessmentQuestionPool(int id)
        {
            var assessmentQuestionPool = await _context.AssessmentQuestionPools.FindAsync(id);
            if (assessmentQuestionPool == null)
            {
                return NotFound();
            }

            _context.AssessmentQuestionPools.Remove(assessmentQuestionPool);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AssessmentQuestionPoolExists(int id)
        {
            return _context.AssessmentQuestionPools.Any(e => e.Id == id);
        }
    
        [HttpPost("ApproveSelectedQuestion")]
        public async Task<bool> ApproveSelectedQuestion(JObject data)
        {
            //end point is responsible for approving selected question
            try
            {
                var q = data["question"].ToObject<AssessmentQuestionPool>();
                var u = data["usrName"].ToString();

                var obj = await _context.AssessmentQuestionPools.FindAsync(q.Id);
                if (obj != null)
                {
                    obj.AuthorizedBy = u;
                    obj.AuthorizedDate = DateTime.Now;

                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception x)
            {
                return false;
            }
        }

        [HttpPost("ApproveAllQuestions")]
        public async Task<string> ApproveAllSelectedQuestions(JObject data)
        {
            //endpoint is responsible for approving all selected questions
            int success = 0;
            int failed = 0;
            
            try
            {
                //getting values
                List<AssessmentQuestionPool> lst = data["questionPools"].ToObject<List<AssessmentQuestionPool>>();
                string u = data["usrName"].ToString();

                if (lst.Count() > 0)
                {
                    foreach(var item in lst)
                    {
                        try
                        {
                            var obj = await _context.AssessmentQuestionPools.FindAsync(item.Id);
                            obj.AuthorizedBy = u;
                            obj.AuthorizedDate = DateTime.Now;

                            await _context.SaveChangesAsync();
                            success += 1;
                        }
                        catch (Exception x)
                        {
                            failed += 1;
                        }
                    }

                    //return final results
                    return $"Total records: {(success + failed).ToString()}, Success: {success.ToString()}, failed: {failed.ToString()}";

                }
                else { return $"No data"; }
            }
            catch(Exception exc)
            {
                System.Diagnostics.Debug.Print($"error {exc.Message}");
                return $"Total records: {(success + failed).ToString()}, Success: {success.ToString()}, failed: {failed.ToString()}";
            }
        }

    }
}
