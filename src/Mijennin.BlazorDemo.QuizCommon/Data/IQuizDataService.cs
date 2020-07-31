using Mijennin.BlazorDemo.QuizCommon.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mijennin.BlazorDemo.QuizCommon.Data
{
    public interface IQuizDataService
    {
        Task<QuizModel> GetQuiz(string quizId);

        Task<IList<QuizModel>> GetQuizzes();

        Task<QuizModel> AddQuiz(QuizModel quizModel);

        Task<QuizModel> UpdateQuiz(QuizModel quizModel);

        Task DeleteQuiz(string quizId);

        Task<QuizQuestionModel> GetQuizQuestion(string quizIs, string quizQuestionId);

        Task<IList<QuizQuestionModel>> GetQuizQuestions(string quizId);

        Task<QuizQuestionModel> AddQuizQuestion(QuizQuestionModel quizQuestionModel);

        Task<QuizQuestionModel> UpdateQuizQuestion(QuizQuestionModel quizQuestionModel);

        Task DeleteQuizQuestion(string quizId, string quizQuestionId);

        Task<QuizQuestionChoiceModel> GetQuizQuestionChoice(string quizQuestionId, string quizQuestionChoiceId);

        Task<IList<QuizQuestionChoiceModel>> GetQuizQuestionChoices(string quizQuestionId);

        Task<QuizQuestionChoiceModel> AddQuizQuestionChoice(QuizQuestionChoiceModel quizQuestionChoiceModel);

        Task<QuizQuestionChoiceModel> UpdateQuizQuestionChoice(QuizQuestionChoiceModel quizQuestionChoiceModel);

        Task DeleteQuizQuestionChoice(string quizQuestionId, string quizQuestionChoiceId);
    }
}
