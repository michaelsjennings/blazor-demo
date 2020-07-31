using Microsoft.AspNetCore.Components;
using Mijennin.BlazorDemo.QuizCommon.Data;
using Mijennin.BlazorDemo.QuizCommon.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mijennin.BlazorDemo.QuizServerApp.Pages
{
    public class QuizAddEditBase : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }

        [Inject]
        private IQuizDataService QuizDataService { get; set; }

        protected QuizModel Quiz { get; private set; } = new QuizModel();

        protected IList<QuizQuestionModel> Questions { get; private set; } = new List<QuizQuestionModel>();

        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrWhiteSpace(Id))
            {
                Quiz = await QuizDataService.GetQuiz(Id);
                await LoadQuestions();
            }
        }

        protected async Task HandleValidSubmit()
        {
            if (Quiz.Id.Equals(Id, StringComparison.OrdinalIgnoreCase))
            {
                Quiz = await QuizDataService.UpdateQuiz(Quiz);
            }
            else
            {
                Quiz = await QuizDataService.AddQuiz(Quiz);
            }

            await LoadQuestions();
        }

        private async Task LoadQuestions()
        {
            Questions = await QuizDataService.GetQuizQuestions(Quiz.Id);
        }
    }
}
