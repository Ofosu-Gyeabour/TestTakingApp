using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PETAS.Data.Data;
using PETAS.Models.Domain.HRMS;

namespace HRMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly HRMSContext config;

        public EmployeesController(HRMSContext _context)
        {
            config = _context;
        }

        //GET api/Employees
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            return await config.Employees.Where(x => x.StatusId == 1).ToListAsync();
        }

        [HttpGet("ByDepartment/{id}")]
        public async Task<ActionResult<List<Employee>>> GetEmployeesByDepartment(int id)
        {
            //endpoint fetches employees...using department ID
            return await config.Employees.Where(x=>x.DepartmentId == id)
                                            .Where(x => x.StatusId == 1).ToListAsync();
        }

        [HttpGet("ByGrade/{Gid}")]
        public async Task<ActionResult<List<Employee>>> GetEmployeesByGrade(int Gid)
        {
            //endpoint fetches employee data, using gradeID
            return await config.Employees.Where(x => x.GradeId == Gid)
                                          .Where(x => x.StatusId == 1).ToListAsync();
        }

        [HttpGet("ByGroup/{Gid}")]
        public async Task<ActionResult<List<Employee>>> GetEmployeesByGroup(int Gid)
        {
            //endpoint fetches employee data, using gradeID
            return await config.Employees.Where(x => x.GroupId == Gid)
                                          .Where(x => x.StatusId == 1).ToListAsync();
        }

        [HttpGet("ByJobTitle/{Tid}")]
        public async Task<ActionResult<List<Employee>>> GetEmployeesByJobTitle(int Tid)
        {
            //endpoint fetches employee data, using gradeID
            return await config.Employees.Where(x => x.JobTitleId == Tid)
                                          .Where(x => x.StatusId == 1).ToListAsync();
        }
    
        //GET api/Employees/5
        [HttpGet("{username}")]
        public async Task<ActionResult<Employee>> GetEmployee(string username)
        {
            if (username == string.Empty)
            {
                return NotFound();
            }

            //username = string.Format("{0}@{1}", username, @"panafricansl.com");

            var obj = await config.Employees.Where(e => e.EmailAddress.Contains(username)).FirstOrDefaultAsync();
            return Ok(obj);
        }

    }
}
