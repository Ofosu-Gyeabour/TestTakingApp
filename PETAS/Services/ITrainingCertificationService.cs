using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Diagnostics;
using PETAS.Models.Domain;

namespace PETAS.Services
{
    public interface ITrainingCertificationService
    {
        public Task<IEnumerable<TrainingCertification>> GetTrainingCertificationsAsync();
        public Task<bool> SaveTrainingCertificationAsync(TrainingCertification obj);
    }

    public class TrainingCertificationService: ITrainingCertificationService
    {
        private readonly HttpClient http;
        public TrainingCertificationService(HttpClient _httpclient)
        {
            http = _httpclient;
        }

        public async Task<IEnumerable<TrainingCertification>> GetTrainingCertificationsAsync()
        {
            return await http.GetFromJsonAsync<IEnumerable<TrainingCertification>>("api/TrainingCertifications");
        }

        public async Task<bool> SaveTrainingCertificationAsync(TrainingCertification obj)
        {
            var stat = await http.PostAsJsonAsync("api/TrainingCertifications", obj);
            return true;
        }

    }
}
