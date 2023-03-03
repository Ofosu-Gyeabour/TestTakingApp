using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Diagnostics;
using System.Collections;
using PETAS.Models.Domain.HRMS;

namespace PETAS.Services
{
    public interface IHRMSService
    {
        public Task<List<Department>> GetDepartmentsAsync();
        public Task<List<Employee>> GetEmployeeAsync();
        public Task<List<Grade>> GetGradeAsync();
        public Task<List<Group>> GetGroupAsync();
        public Task<List<JobTitle>> GetJobTitlesAsync();
        public Task<Employee> GetEmployee(string username);

        public Task<JobTitle> getEmployeeJobTitle(int? jobTitleID);
    }

    public class HRMSService: IHRMSService
    {
        private readonly HRMSClient hrmsclient;
        private readonly HttpClient http;
        public HRMSService(HRMSClient _hrmsClient)
        {
            hrmsclient = _hrmsClient;
            http = hrmsclient.http;
        }

        public async Task<List<Department>> GetDepartmentsAsync()
        {
            return await http.GetFromJsonAsync<List<Department>>("api/Departments");
        }

        public async Task<List<Employee>> GetEmployeeAsync()
        {
            return await http.GetFromJsonAsync<List<Employee>>("api/Employees");
        }

        public async Task<List<Grade>> GetGradeAsync()
        {
            return await http.GetFromJsonAsync<List<Grade>>("api/Grades");
        }

        public async Task<List<Group>> GetGroupAsync()
        {
            return await http.GetFromJsonAsync<List<Group>>("api/Groups");
        }

        public async Task<List<JobTitle>> GetJobTitlesAsync()
        {
            return await http.GetFromJsonAsync<List<JobTitle>>("api/JobTitles");
        }

        public async Task<Employee> GetEmployee(string username)
        {
            //service gets an employee's record
            return await http.GetFromJsonAsync<Employee>("api/Employees" + "/" + username);
        }

        public async Task<JobTitle> getEmployeeJobTitle(int? jobTitleID)
        {
            //service gets an employee's job title, using jobTitleID
            return await http.GetFromJsonAsync<JobTitle>("api/JobTitles" + "/" + jobTitleID);
        }

    }
}
