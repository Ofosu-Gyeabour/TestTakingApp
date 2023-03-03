using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Diagnostics;

using PETAS.Models.Domain;

namespace PETAS.Services
{
    public interface IQAllotedService
    {
        public Task<string> SaveAllotedQuestionsAsync(Training trainingObj, TrainingAssessment tAssessment, List<AssessmentQuestionPool> questions, int qTypeID);

        public Task<List<Qalloted>> GetSelectedQuestions(int? trainingId, int? questiontypeId);

        public Task<List<AssessmentQuestionPool>> getRandomQuestions(List<Qalloted> list);

    }

    public class QAllotedService: IQAllotedService
    {
        private readonly HttpClient http;

        public QAllotedService(HttpClient _httpClient)
        {
            http = _httpClient;
        }

        public async Task<string> SaveAllotedQuestionsAsync(Training trainingObj, TrainingAssessment tAssessment, List<AssessmentQuestionPool> questions, int qTypeID)
        {
            int success = 0;
            int failed = 0;

            try
            {
                foreach(var question in questions)
                {
                    try
                    {
                        var postBody = new { trainingObj, tAssessment, question, qTypeID };

                        var result = await http.PostAsJsonAsync("api/QAlloted", postBody);
                        var obj = result.Content.ReadFromJsonAsync<Qalloted>();
                        if (obj.Id > 0)
                        {
                            success += 1;
                        }
                        else { failed += 1; }
                    }
                    catch(Exception xx)
                    {
                        Debug.Print($"error: {xx.Message}");
                        failed += 1;
                    }
                }

                return $"Total questions: {questions.Count().ToString()}, successful inserts: {success.ToString()}, failed inserts: {failed.ToString()}";
            }
            catch(Exception ex)
            {
                return $"error: {ex.Message}";
            }
        }

        public async Task<List<Qalloted>> GetSelectedQuestions(int? trainingId, int? questiontypeId)
        {
            return await http.GetFromJsonAsync<List<Qalloted>>("api/QAlloted" + "/" + trainingId + "/" + questiontypeId);
        }

        public async Task<List<AssessmentQuestionPool>> getRandomQuestions(List<Qalloted> list)
        {
            List<AssessmentQuestionPool> questionList = new List<AssessmentQuestionPool>();

            int counter = 0;
            int? questionCount = list[0].Alloted;
            int[] selectedQuestions = new int[(int)questionCount];

            int?[] res = new int?[list.Count()];

            if (list.Count() > 0)
            {
                for (int i = 0; i <= list.Count() - 1; i++)
                {
                    res[i] = list[i].QuestionId;
                }
            }

            var min = res.Min();
            var max = res.Max();

            Random r = new Random();

            //getting questions in a random fashion
            while(counter < (int)questionCount)
            {
                var generatedQuestionNo = r.Next((int)min, (int)max);

                //check if the question no exists in the original questions pulled up
                if ((!selectedQuestions.Contains(generatedQuestionNo)) && (res.Contains(generatedQuestionNo)))
                {
                    selectedQuestions[counter] = generatedQuestionNo;
                    counter++;
                }
            }

            //after getting selected question numbers, fetch question
            foreach(var item in selectedQuestions)
            {
                var q = await http.GetFromJsonAsync<AssessmentQuestionPool>("api/Questions" + "/" + item);
                if (q != null)
                {
                    AssessmentQuestionPool obj = q;
                    questionList.Add(obj);
                }
            }

            return questionList;
        }

    }
}
