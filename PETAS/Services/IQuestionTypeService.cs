using PETAS.Models.Domain;
using System.Net;
using System.Net.Http.Json;

namespace PETAS.Services
{
    public interface IQuestionTypeService
    {
        public Task<QuestionType> SaveQuestionType(QuestionType oQuestionType);

        public Task<IEnumerable<QuestionType>> GetAllQuestionTypes();

        public Task<QuestionType> GetQuestionType(int _id);
        public Task<bool> DeleteQuestionType(QuestionType oQuestionType);
    }

    public class QuestionTypeService: IQuestionTypeService
    {
        private readonly HttpClient http;

        public QuestionTypeService(HttpClient _httpClient)
        {
            http = _httpClient;
        }

        public async Task<QuestionType> SaveQuestionType(QuestionType oQuestionType)
        {
            var result = await http.PostAsJsonAsync("api/QuestionTypes", oQuestionType);
            return await result.Content.ReadFromJsonAsync<QuestionType>();
        }

        public async Task<bool> DeleteQuestionType(QuestionType oQuestionType)
        {
            try
            {
                http.DeleteAsync("api/QuestionTypes/" + oQuestionType.Id.ToString());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public async Task<IEnumerable<QuestionType>> GetAllQuestionTypes()
        {
            //gets all question types from the REST API
            return await http.GetFromJsonAsync<IEnumerable<QuestionType>>("api/QuestionTypes");
        }

        public async Task<QuestionType> GetQuestionType(int _id)
        {
            //gets a question type object, giving the display value
            try
            {
                return await http.GetFromJsonAsync<QuestionType>("api/QuestionTypes" + "/" + _id);
            }
            catch(Exception x)
            {
                return null;
            }
        }

    }
}
