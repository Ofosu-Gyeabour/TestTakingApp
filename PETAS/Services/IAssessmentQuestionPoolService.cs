using PETAS.Models.Domain;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;

namespace PETAS.Services
{
    public interface IAssessmentQuestionPoolService
    {
        public Task<IEnumerable<AssessmentQuestionPool>> GetWRTAnsAssessmentQuestionPoolAsync(int _subjectId);

        public Task<IEnumerable<AssessmentQuestionPool>> GetUnApprovedMCANSAssessmentQuestionPoolAsync(int _subjectId);

        Task<bool> ApproveQuestionAsync(AssessmentQuestionPool question, string userName);

        Task<string> ApproveAllQuestionsAsync(List<AssessmentQuestionPool> questionPools, string userName);
    }

    public class AssessmentQuestionPoolService: IAssessmentQuestionPoolService
    {
        private readonly HttpClient http;

        public AssessmentQuestionPoolService(HttpClient _httpclient)
        {
            http = _httpclient;
        }

        public async Task<IEnumerable<AssessmentQuestionPool>> GetWRTAnsAssessmentQuestionPoolAsync(int _subjectId)
        {
            //uses subject Id to fetch pool of questions
            try
            {
                return await http.GetFromJsonAsync<IEnumerable<AssessmentQuestionPool>>("api/AssessmentQuestionPools" + "/" + _subjectId);
            }
            catch(Exception x)
            {
                return null;
            }
        }

        public async Task<string> ApproveAllQuestionsAsync(List<AssessmentQuestionPool> questionPools, string usrName)
        {
            var postBody = new { questionPools, usrName };
            var result = await http.PostAsJsonAsync("api/AssessmentQuestionPools/ApproveAllQuestions", postBody);
            return await result.Content.ReadFromJsonAsync<string>();
        }

        public async Task<bool> ApproveQuestionAsync(AssessmentQuestionPool question, string usrName)
        {
            //calling API endpoint
            try
            {
                var postBody = new { question, usrName };
                var result = await http.PostAsJsonAsync("api/AssessmentQuestionPools/ApproveSelectedQuestion", postBody);
                return await result.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                System.Diagnostics.Debug.Print($"error {x.Message}");
                return false;
            }
            return true;
        }

        public async Task<IEnumerable<AssessmentQuestionPool>> GetUnApprovedMCANSAssessmentQuestionPoolAsync(int _subjectId)
        {
            try
            {
                
                return await http.GetFromJsonAsync<IEnumerable<AssessmentQuestionPool>>("api/AssessmentQuestionPools/UnApproved" + "/" + _subjectId);
                
            }
            catch(Exception x)
            {
                return null;
            }
        }

    }
}
