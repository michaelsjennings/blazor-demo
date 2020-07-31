using Microsoft.Azure.Cosmos.Table;
using Mijennin.BlazorDemo.QuizCommon.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mijennin.BlazorDemo.QuizCommon.Data.TableStorage
{
    internal class QuizQuestionChoiceEntity : TableEntity
    {
        public string ChoiceText { get; set; }

        public QuizQuestionChoiceEntity()
        {
            PartitionKey = TableStorageContext.DefaultPartitionName;
            RowKey = Guid.NewGuid().ToString();
            ETag = "*";
        }

        public QuizQuestionChoiceEntity(QuizQuestionChoiceModel quizQuestionChoiceModel)
        {
            PartitionKey = quizQuestionChoiceModel.QuizQuestionId;
            RowKey = quizQuestionChoiceModel.Id;
            ETag = "*";
            ChoiceText = quizQuestionChoiceModel.ChoiceText;
        }

        public QuizQuestionChoiceModel ToQuizQuestionChoiceModel()
        {
            return new QuizQuestionChoiceModel
            {
                Id = RowKey,
                QuizQuestionId = PartitionKey,
                ChoiceText = ChoiceText
            };
        }
    }
}
