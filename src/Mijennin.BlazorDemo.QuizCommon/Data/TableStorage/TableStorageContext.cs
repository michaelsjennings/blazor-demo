using Microsoft.Azure.Cosmos.Table;

namespace Mijennin.BlazorDemo.QuizCommon.Data.TableStorage
{
    internal class TableStorageContext
    {
        public const string DefaultPartitionName = "default";

        private readonly CloudStorageAccount _storageAccount;

        private readonly CloudTableClient _tableClient;

        public CloudTable Quizzes { get; }

        public CloudTable QuizQuestions { get; }

        public CloudTable QuizQuestionChoices { get; }

        public TableStorageContext(string connectionString)
        {
            _storageAccount = CloudStorageAccount.Parse(connectionString);
            _tableClient = _storageAccount.CreateCloudTableClient();

            Quizzes = _tableClient.GetTableReference(nameof(Quizzes));
            QuizQuestions = _tableClient.GetTableReference(nameof(QuizQuestions));
            QuizQuestionChoices = _tableClient.GetTableReference(nameof(QuizQuestionChoices));
        }
    }
}
