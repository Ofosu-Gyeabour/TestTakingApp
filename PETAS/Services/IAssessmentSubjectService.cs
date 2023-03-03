using System.Net;
using System.Net.Http.Json;
using PETAS.Models.Domain;

namespace PETAS.Services
{
    public interface IAssessmentSubjectService
    {
        public Task<AssessmentSubject> SaveSubject(AssessmentSubject objSubject);

        public Task<bool> DeleteSubject(AssessmentSubject objSubject);
        public Task<IEnumerable<AssessmentSubject>> GetAllAssessmentSubjects();
    }

    public class AssessmentSubjectService : IAssessmentSubjectService
    {
        private readonly HttpClient http;
        public AssessmentSubjectService(HttpClient _http)
        {
            http = _http;
        }

        public async Task<AssessmentSubject> SaveSubject(AssessmentSubject objSubject)
        {
            var result = await http.PostAsJsonAsync("api/AssessmentSubjects", objSubject);
            return await result.Content.ReadFromJsonAsync<AssessmentSubject>();
        }

        public async Task<bool> DeleteSubject(AssessmentSubject objSubject)
        {
            try
            {
                await http.DeleteAsync("api/AssessmentSubjects/" + objSubject.Id.ToString());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<AssessmentSubject>> GetAllAssessmentSubjects()
        {
            return await http.GetFromJsonAsync<IEnumerable<AssessmentSubject>>("api/AssessmentSubjects");
        }
    }

}
