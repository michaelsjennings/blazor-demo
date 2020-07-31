using System;
using System.Collections.Generic;

namespace Mijennin.BlazorDemo.QuizCommon.Models
{
    public class QuizModel2
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Title { get; set; }

        public IList<QuizQuestionModel2> Questions { get; } = new List<QuizQuestionModel2>();
    }
}
