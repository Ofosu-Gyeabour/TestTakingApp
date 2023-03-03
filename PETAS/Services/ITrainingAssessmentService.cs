using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Diagnostics;
using PETAS.Models.Domain;

namespace PETAS.Services
{
    public interface ITrainingAssessmentService
    {
        public Task<TrainingAssessment> SaveTrainingAssessment(TrainingAssessment obj);
    }

    public class TrainingAssessmentService: ITrainingAssessmentService
    {
        private readonly HttpClient http;

        public TrainingAssessmentService(HttpClient _http)
        {
            http = _http;
        }

        public async Task<TrainingAssessment> SaveTrainingAssessment(TrainingAssessment obj)
        {
            //saves training assessment...returns the new trainingAssessment object
            var res =  await http.PostAsJsonAsync("api/TrainingAssessments",obj);
            return await res.Content.ReadFromJsonAsync<TrainingAssessment>();
        }
    }
}
