using Microsoft.AspNetCore.Components;
using Mijennin.BlazorDemo.QuizCommon.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Mijennin.BlazorDemo.QuizServerApp.Pages
{
    public class QuizEditorBase : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }

        protected QuizModel2 Quiz { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            Quiz = new QuizModel2 { Title = "My First Quiz" };

            var question1 = new QuizQuestionModel2 { QuestionNumber = Quiz.Questions.Count + 1, QuestionText = "What is the first day of the week?" };
            question1.Choices.Add(new QuizQuestionChoiceModel2 { ChoiceText = "Monday" });
            question1.Choices.Add(new QuizQuestionChoiceModel2 { ChoiceText = "Saturday" });
            question1.Choices.Add(new QuizQuestionChoiceModel2 { ChoiceText = "Sunday" });
            question1.Choices.Add(new QuizQuestionChoiceModel2 { ChoiceText = "Monday" });
            question1.CorrectChoice = question1.Choices.Single(x => x.ChoiceText.Equals("Sunday", StringComparison.OrdinalIgnoreCase));
            Quiz.Questions.Add(question1);

            var question2 = new QuizQuestionModel2 { QuestionNumber = Quiz.Questions.Count + 1, QuestionText = "Which day name has the most characters?" };
            question2.Choices.Add(new QuizQuestionChoiceModel2 { ChoiceText = "Thursday" });
            question2.Choices.Add(new QuizQuestionChoiceModel2 { ChoiceText = "Saturday" });
            question2.Choices.Add(new QuizQuestionChoiceModel2 { ChoiceText = "Wednesday" });
            question2.Choices.Add(new QuizQuestionChoiceModel2 { ChoiceText = "Tuesday" });
            question2.CorrectChoice = question2.Choices.Single(x => x.ChoiceText.Equals("Wednesday", StringComparison.OrdinalIgnoreCase));
            Quiz.Questions.Add(question2);

            var question3 = new QuizQuestionModel2 { QuestionNumber = Quiz.Questions.Count + 1, QuestionText = "Which day name is first when sorted alphabetically?" };
            question3.Choices.Add(new QuizQuestionChoiceModel2 { ChoiceText = "Thursday" });
            question3.Choices.Add(new QuizQuestionChoiceModel2 { ChoiceText = "Monday" });
            question3.Choices.Add(new QuizQuestionChoiceModel2 { ChoiceText = "Friday" });
            question3.Choices.Add(new QuizQuestionChoiceModel2 { ChoiceText = "Tuesday" });
            question3.CorrectChoice = question3.Choices.Single(x => x.ChoiceText.Equals("Monday", StringComparison.OrdinalIgnoreCase));
            Quiz.Questions.Add(question3);
        }
    }
}
