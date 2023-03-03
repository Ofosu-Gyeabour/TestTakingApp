using PETAS.Data.Data;
using Microsoft.EntityFrameworkCore;

using PETAS.Models.Domain;

namespace PANTrainerAPI.Helpers
{
    public class Utils
    {
        private readonly PantrainerContext config;

        public Utils(PantrainerContext _context)
        {
            config = _context;
        }

        public async Task<PETAS.Models.Domain.QuestionType> getQuestionType(string strQuestionType)
        {
            //method gets the questionID for the question sent
            return await config.QuestionTypes.Where(x => x.QuestionType1 == strQuestionType).FirstOrDefaultAsync(); 
        }

        public async Task<PETAS.Models.Domain.AssessmentSubject> getAssessmentSubject(string strAssessmentSubject)
        {
            //gets the assessmentsubject object
            return await config.AssessmentSubjects.Where(x => x.SubjectName == strAssessmentSubject).FirstOrDefaultAsync();
        }

    }
}
