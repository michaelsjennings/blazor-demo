using Microsoft.AspNetCore.Components;
using Mijennin.BlazorDemo.QuizCommon.Data;
using Mijennin.BlazorDemo.QuizCommon.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mijennin.BlazorDemo.QuizServerApp.Pages
{
    public class QuizListBase : ComponentBase
    {
        [Inject]
        private IQuizDataService QuizDataService { get; set; }

        protected IList<QuizModel> Quizzes { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            Quizzes = await QuizDataService.GetQuizzes();
        }
    }
}
