using System;

namespace Mijennin.BlazorDemo.QuizCommon.Models
{
    public class QuizModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Title { get; set; }
    }
}
