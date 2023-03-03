using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Diagnostics;
using PETAS.Models.Domain;
using PETAS.Models.Domain.HRMS;
using PETAS.Data.Data;

namespace PETAS.Services
{
    public interface IDragService
    {
        public Task<List<Employee>> GetEmployeesForTrainingAsync(string source, Training t, object _Data);
       
    }

    public class DragService: IDragService, IHRMSService
    {
        private readonly HttpClient http;
        private readonly HRMSClient hrmsClient;
        public DragService(HRMSClient _hrmsclient)
        {
            http = _hrmsclient.http;
        }

        public async Task<List<Employee>> GetEmployeesForTrainingAsync(string source, Training t, object _Data)
        {
            var employeeData = await GetTraineeList(_Data);

            //get the employee data, persist record and notifiy employees of the training programme
            return employeeData;
        }

        #region Private Methods

        private async Task<List<Employee>> GetTraineeList(object Data)
        {
            //gets the name and email address for the object in question
            var type = Data.GetType().Name;
            if (type == @"Department")
            {
                return await ByDepartment((Department)Data);
            }
            else if (type == @"Group")
            {
                return await ByGroup((Group)Data);
            }
            else if (type == @"Grade")
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
            try
            {
                return await http.GetFromJsonAsync<List<Employee>>("api/Employees/ByDepartment" + "/" + obj.DepartmentId);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                throw ex;
            }
        }

        private async Task<List<Employee>> ByGrade(Grade obj)
        {
            //gets the list of employees, especially their email addresses
            try
            {
                return await http.GetFromJsonAsync<List<Employee>>("api/Employees/ByGrade" + "/" + obj.GradeId);
            }
            catch (Exception x)
            {
                Debug.Print(x.Message);
                throw x;
            }
        }

        private async Task<List<Employee>> ByGroup(Group obj)
        {
            try
            {
                return await http.GetFromJsonAsync<List<Employee>>("api/Employees/ByGroup" + "/" + obj.GroupId);
            }
            catch (Exception x)
            {
                Debug.Print(x.Message);
                throw x;
            }
        }

        private async Task<List<Employee>> ByJobTitle(JobTitle obj)
        {
            try
            {
                return await http.GetFromJsonAsync<List<Employee>>("api/Employees/ByJobTitle" + "/" + obj.JobTitleId);
            }
            catch (Exception x)
            {
                Debug.Print(x.Message);
                throw x;
            }
        }


        #endregion

        #region IHRMSService interface implementations

        public async Task<List<Department>> GetDepartmentsAsync() { return new List<Department>(); }
        public async Task<List<Employee>> GetEmployeeAsync() { return new List<Employee>(); }
        public async Task<List<Grade>> GetGradeAsync() { return new List<Grade>(); }
        public async Task<List<Group>> GetGroupAsync() { return new List<Group>(); }
        public async Task<List<JobTitle>> GetJobTitlesAsync() { return new List<JobTitle>(); }

        public async Task<Employee> GetEmployee(string username) { return new Employee(); }
        
        public async Task<JobTitle> getEmployeeJobTitle(int? jobTitleID)
        {
            return new JobTitle();
        }

        #endregion

    }

}
