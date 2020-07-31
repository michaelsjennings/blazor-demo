using System.Collections.Generic;

namespace Mijennin.BlazorDemo.QuizCommon.Models
{
    public class QuizQuestionModel2
    {
        public int QuestionNumber { get; set; }

        public string QuestionText { get; set; }

        public IList<QuizQuestionChoiceModel2> Choices { get; } = new List<QuizQuestionChoiceModel2>();

        public QuizQuestionChoiceModel2 CorrectChoice { get; set; }
    }
}
