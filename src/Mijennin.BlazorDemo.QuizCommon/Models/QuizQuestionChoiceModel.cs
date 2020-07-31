using System;

namespace Mijennin.BlazorDemo.QuizCommon.Models
{
    public class QuizQuestionChoiceModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string QuizQuestionId { get; set; }

        public string ChoiceText { get; set; }
    }
}
