using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Diagnostics;
using PETAS.Models.Domain;
using PETAS.Models.Domain.HRMS;

namespace PETAS.Services
{
    public interface ITrainingService
    {
        public Task<List<Training>> GetTrainingsAsync();

        public Task<Training> GetTraining(int? tID);

        public Task<bool> SaveTrainingAsync(Training obj, TrainingType ttype, TrainingGrouping tgroup, TrainingCertification tcert);
        public Task<string> AssignTrainingAsync(Training training, List<Employee> empList, string user);

        public Task<bool> IsAdministrator(string user);

        public Task<List<AssignedTraining>> GetAssignedTrainings(int? employeeID);
    }

    public class TrainingService: ITrainingService
    {
        private readonly HttpClient http;

        public TrainingService(HttpClient _httpClient)
        {
            http = _httpClient;
        }

        public async Task<bool> SaveTrainingAsync(Training obj, TrainingType ttype, TrainingGrouping tgroup, TrainingCertification tcert)
        {
            var postBody = new { ttype, tgroup, tcert, obj };
            var status = await http.PostAsJsonAsync("api/Trainings/PostTrainingRecord", postBody);
            return await status.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<bool> IsAdministrator(string user)
        {
            //method is responsible for determinining if the user is an administrator
            return await http.GetFromJsonAsync<bool>("api/Trainings/Administrator" + "/" + user);
        }

        public async Task<List<Training>> GetTrainingsAsync()
        {
            return await http.GetFromJsonAsync<List<Training>>("api/Trainings");
        }

        public async Task<string> AssignTrainingAsync(Training training, List<Employee> empList, string user)
        {
            int success = 0;
            int failed = 0;

            try
            {
                if (empList.Count() > 0)
                {
                    foreach(var emp in empList)
                    {
                        var postBody = new { training, emp, user };
                        var posted = await http.PostAsJsonAsync("api/Trainings/AssignTrainingToEmployee", postBody);
                        var status = await posted.Content.ReadFromJsonAsync<bool>();
                        if (status) 
                        {
                            success += 1; 
                        } else { failed += 1; }
                    }

                    return $"Total records {(success + failed).ToString()} notified with {failed.ToString()} fails";
                }
                else { return @"No data"; }
            }
            catch(Exception x)
            {
                return @"No data";
            }
        }

        public async Task<List<AssignedTraining>> GetAssignedTrainings(int? employeeID)
        {
            return await http.GetFromJsonAsync<List<AssignedTraining>>("api/AssignedTraining" + "/" + employeeID);
        }

        public async Task<Training> GetTraining(int? tID)
        {
            return await http.GetFromJsonAsync<Training>("api/Trainings" + "/" + tID);
        }

    }

}
