using Microsoft.Azure.Cosmos.Table.Queryable;
using Mijennin.BlazorDemo.QuizCommon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mijennin.BlazorDemo.QuizCommon.Data.TableStorage
{
    public class TableStorageQuizDataService : IQuizDataService
    {
        private TableStorageContext _db;

        public TableStorageQuizDataService(string connectionString)
        {
            _db = new TableStorageContext(connectionString);
        }

        public async Task<QuizModel> GetQuiz(string quizId)
        {
            var quizEntity = await _db.Quizzes.Get<QuizEntity>(quizId);

            return quizEntity.ToQuizModel();
        }

        public async Task<IList<QuizModel>> GetQuizzes()
        {
            var query = _db.Quizzes.CreateQuery<QuizEntity>();

            var quizEntities = await _db.Quizzes.ExecuteQueryAsync(query);

            return quizEntities.Select(x => x.ToQuizModel())
                .OrderBy(x => x.Title)
                .ToList();
        }

        public async Task<QuizModel> AddQuiz(QuizModel quizModel)
        {
            var quizEntity = new QuizEntity(quizModel);

            quizEntity = await _db.Quizzes.Insert(quizEntity);

            return quizEntity.ToQuizModel();
        }

        public async Task<QuizModel> UpdateQuiz(QuizModel quizModel)
        {
            var quizEntity = new QuizEntity(quizModel);

            quizEntity = await _db.Quizzes.Merge(quizEntity);

            return quizEntity.ToQuizModel();
        }

        public async Task DeleteQuiz(string quizId)
        {
            await _db.Quizzes.Delete(quizId);
        }

        public async Task<QuizQuestionModel> GetQuizQuestion(string quizId, string quizQuestionId)
        {
            var quizQuestionEntity = await _db.QuizQuestions.Get<QuizQuestionEntity>(quizId, quizQuestionId);

            return quizQuestionEntity.ToQuizQuestionModel();
        }

        public async Task<IList<QuizQuestionModel>> GetQuizQuestions(string quizId)
        {
            var query = _db.QuizQuestions.CreateQuery<QuizQuestionEntity>();
            query = query.Where(x => x.PartitionKey == quizId).AsTableQuery();

            var quizQuestionEntities = await _db.QuizQuestions.ExecuteQueryAsync(query);

            return quizQuestionEntities.Select(x => x.ToQuizQuestionModel())
                .OrderBy(x => x.QuestionNumber)
                .ToList();
        }

        public async Task<QuizQuestionModel> AddQuizQuestion(QuizQuestionModel quizQuestionModel)
        {
            var quizQuestionEntity = new QuizQuestionEntity(quizQuestionModel);

            quizQuestionEntity = await _db.QuizQuestions.Insert(quizQuestionEntity);

            return quizQuestionEntity.ToQuizQuestionModel();
        }

        public async Task<QuizQuestionModel> UpdateQuizQuestion(QuizQuestionModel quizQuestionModel)
        {
            var quizQuestionEntity = new QuizQuestionEntity(quizQuestionModel);

            quizQuestionEntity = await _db.QuizQuestions.Merge(quizQuestionEntity);

            return quizQuestionEntity.ToQuizQuestionModel();
        }

        public async Task DeleteQuizQuestion(string quizId, string quizQuestionId)
        {
            await _db.QuizQuestions.Delete(quizId, quizQuestionId);
        }

        public async Task<QuizQuestionChoiceModel> GetQuizQuestionChoice(string quizQuestionId, string quizQuestionChoiceId)
        {
            var quizQuestionChoiceEntity = await _db.QuizQuestionChoices.Get<QuizQuestionChoiceEntity>(quizQuestionId, quizQuestionChoiceId);

            return quizQuestionChoiceEntity.ToQuizQuestionChoiceModel();
        }

        public async Task<IList<QuizQuestionChoiceModel>> GetQuizQuestionChoices(string quizQuestionId)
        {
            var query = _db.QuizQuestionChoices.CreateQuery<QuizQuestionChoiceEntity>();
            query = query.Where(x => x.PartitionKey == quizQuestionId).AsTableQuery();

            var quizQuestionChoiceEntities = await _db.QuizQuestionChoices.ExecuteQueryAsync(query);

            var random = new Random();

            return quizQuestionChoiceEntities.Select(x => x.ToQuizQuestionChoiceModel())
                .OrderBy(x => random.Next())
                .ToList();
        }

        public async Task<QuizQuestionChoiceModel> AddQuizQuestionChoice(QuizQuestionChoiceModel quizQuestionChoiceModel)
        {
            var quizQuestionChoiceEntity = new QuizQuestionChoiceEntity(quizQuestionChoiceModel);

            quizQuestionChoiceEntity = await _db.QuizQuestionChoices.Insert(quizQuestionChoiceEntity);

            return quizQuestionChoiceEntity.ToQuizQuestionChoiceModel();
        }

        public async Task<QuizQuestionChoiceModel> UpdateQuizQuestionChoice(QuizQuestionChoiceModel quizQuestionChoiceModel)
        {
            var quizQuestionChoiceEntity = new QuizQuestionChoiceEntity(quizQuestionChoiceModel);

            quizQuestionChoiceEntity = await _db.QuizQuestionChoices.Merge(quizQuestionChoiceEntity);

            return quizQuestionChoiceEntity.ToQuizQuestionChoiceModel();
        }

        public async Task DeleteQuizQuestionChoice(string quizQuestionId, string quizQuestionChoiceId)
        {
            await _db.QuizQuestionChoices.Delete(quizQuestionId, quizQuestionChoiceId);
        }
    }
}
