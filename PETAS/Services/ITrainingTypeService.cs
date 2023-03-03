using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Diagnostics;
using System.Collections;
using PETAS.Models.Domain;

namespace PETAS.Services
{
    public interface ITrainingTypeService
    {
        public Task<List<TrainingType>> GetTrainingTypesAsync();
    }

    public class TrainingTypeService: ITrainingTypeService
    {
        private readonly HttpClient http;

        public TrainingTypeService(HttpClient _httpClient)
        {
            http = _httpClient;
        }

        public async Task<List<TrainingType>> GetTrainingTypesAsync()
        {
            return await http.GetFromJsonAsync<List<TrainingType>>("api/TrainingTypes");
        }

    }

}
