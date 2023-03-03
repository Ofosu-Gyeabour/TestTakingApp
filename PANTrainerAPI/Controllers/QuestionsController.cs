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
    public class QuestionsController : ControllerBase
    {
        private readonly PantrainerContext config;

        public QuestionsController(PantrainerContext _context)
        {
            config = _context;
        }

        //GET api/Questions/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<AssessmentQuestionPool>> GetQuestion(int id)
        {
            var obj = await config.AssessmentQuestionPools.FindAsync(id);

            return Ok(obj);
        }

    }
}
