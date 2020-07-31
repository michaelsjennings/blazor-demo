using Microsoft.Azure.Cosmos.Table;
using Mijennin.BlazorDemo.QuizCommon.Models;
using System;

namespace Mijennin.BlazorDemo.QuizCommon.Data.TableStorage
{
    internal class QuizQuestionEntity : TableEntity
    {
        public int QuestionNumber { get; set; }

        public string QuestionText { get; set; }

        public QuizQuestionEntity()
        {
            PartitionKey = TableStorageContext.DefaultPartitionName;
            RowKey = Guid.NewGuid().ToString();
            ETag = "*";
        }

        public QuizQuestionEntity(QuizQuestionModel quizQuestionModel)
        {
            PartitionKey = quizQuestionModel.QuizId;
            RowKey = quizQuestionModel.Id;
            ETag = "*";
            QuestionText = quizQuestionModel.QuestionText;
        }

        public QuizQuestionModel ToQuizQuestionModel()
        {
            return new QuizQuestionModel
            {
                Id = RowKey,
                QuizId = PartitionKey,
                QuestionText = QuestionText
            };
        }
    }
}
