using PETAS.Models.Domain.HRMS;
using PETAS.Data.Data;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using PETAS.Models.Domain;

namespace PETAS.Classes
{
    public class DragHelper
    {
        public string Source { get; set; }
        public Training Target { get; set; }
        public object Data { get; set; }

        private readonly HRMSContext config;

        public DragHelper(HRMSContext _context)
        {
            config = _context;
        }

        public async Task<List<Employee>> GetTraineeList()
        {
            //gets the name and email address for the object in question
            var type = this.Data.GetType().Name;
            if (type == @"Department")
            {
                return await ByDepartment((Department)Data);
            }
            else if(type== @"Group")
            {
                return await ByGroup((Group)Data);
            }else if(type == @"Grade")
            {
                return await ByGrade((Grade)Data);
            }
            else
            {
                //JobTitle
                return await ByJobTitle((JobTitle)Data);
            }
        }

        private async Task<List<Employee>> ByDepartment(Department obj)
        {
            //gets the list of employees, especially their email addresses
            var results = new List<Employee>();
            try
            {
                using (config)
                {
                    try
                    {
                        var res = await config.Employees.Where(x => x.DepartmentId == obj.DepartmentId)
                                                    .Where(x => x.StatusId == 1).ToListAsync();

                        if (res.Count() > 0)
                        {
                            foreach(var item in res)
                            {
                                results.Add(item);
                            }
                        }

                        return results;
                    }
                    catch(Exception x)
                    {
                        Debug.Print(x.Message);
                        return results;
                    }
                }
            }
            catch(Exception ex)
            {
                Debug.Print(ex.Message);
                throw ex;
            }
        }

        private async Task<List<Employee>> ByGrade(Grade obj)
        {
            //gets the list of employees, especially their email addresses
            var results = new List<Employee>();
            try
            {
                using (config)
                {
                    try
                    {
                        var res = await config.Employees.Where(x => x.GradeId == obj.GradeId).ToListAsync();
                        if (res.Count() > 0)
                        {
                            foreach(var item in res)
                            {
                                results.Add(item);
                            }
                        }

                        return results;
                    }
                    catch(Exception xx) {
                        Debug.Print(xx.Message);
                        return results;
                    }
                }
            }
            catch(Exception x)
            {
                Debug.Print(x.Message);
                throw x;
            }
        }

        private async Task<List<Employee>> ByGroup(Group obj)
        {
            var results = new List<Employee>();
            try
            {
                using (config)
                {
                    try
                    {
                        var res = await config.Employees.Where(x => x.GroupId == obj.GroupId).ToListAsync();

                        if (res.Count() > 0)
                        {
                            foreach (var item in res)
                            {
                                results.Add(item);
                            }
                        }

                        return results;
                    }
                    catch(Exception xx)
                    {
                        Debug.Print(xx.Message);
                        return results;
                    } 
                }
            }
            catch(Exception x)
            {
                Debug.Print(x.Message);
                throw x;
            }
        }
    
        private async Task<List<Employee>> ByJobTitle(JobTitle obj)
        {
            var results = new List<Employee>();
            try
            {
                using (config)
                {
                    try
                    {
                        var res = await config.Employees.Where(x => x.JobTitleId == obj.JobTitleId).ToListAsync();
                        
                        if (res.Count() > 0)
                        {
                            foreach(var item in res)
                            {
                                results.Add(item);
                            }
                        }

                        return results;
                    }
                    catch(Exception xx)
                    {
                        Debug.Print(xx.Message);
                        return results;
                    }
                }
            }
            catch(Exception x)
            {
                Debug.Print(x.Message);
                throw x;
            }
        }
    
    }
}
