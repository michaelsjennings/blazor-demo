using Microsoft.AspNetCore.Components;
using Mijennin.BlazorDemo.QuizCommon.Data;
using Mijennin.BlazorDemo.QuizCommon.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mijennin.BlazorDemo.QuizServerApp.Pages
{
    public class QuizListBase : ComponentBase
    {
        /*
        [Inject]
        private IQuizDataService QuizDataService { get; set; }

        protected IList<QuizModel> Quizzes { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            Quizzes = await QuizDataService.GetQuizzes();
        }
        */

        protected IList<QuizModel2> Quizzes { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            Quizzes = new List<QuizModel2>
            {
                new QuizModel2 { Title = "Quiz One" },
                new QuizModel2 { Title = "Quiz Two" },
                new QuizModel2 { Title = "Quiz Three" }
            };
        }
    }
}
