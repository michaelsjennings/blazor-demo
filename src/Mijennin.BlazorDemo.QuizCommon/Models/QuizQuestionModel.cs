using System;

namespace Mijennin.BlazorDemo.QuizCommon.Models
{
    public class QuizQuestionModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string QuizId { get; set; }

        public int QuestionNumber { get; set; }

        public string QuestionText { get; set; }

        public string CorrectChoiceId { get; set; }
    }
}
