using Microsoft.Azure.Cosmos.Table;
using Mijennin.BlazorDemo.QuizCommon.Models;
using System;

namespace Mijennin.BlazorDemo.QuizCommon.Data.TableStorage
{
    internal class QuizEntity : TableEntity
    {
        public string Title { get; set; }

        public QuizEntity()
        {
            PartitionKey = TableStorageContext.DefaultPartitionName;
            RowKey = Guid.NewGuid().ToString();
            ETag = "*";
        }

        public QuizEntity(QuizModel quizModel)
        {
            PartitionKey = TableStorageContext.DefaultPartitionName;
            RowKey = quizModel.Id;
            ETag = "*";
            Title = quizModel.Title;
        }

        public QuizModel ToQuizModel()
        {
            return new QuizModel
            {
                Id = RowKey,
                Title = Title
            };
        }
    }
}
