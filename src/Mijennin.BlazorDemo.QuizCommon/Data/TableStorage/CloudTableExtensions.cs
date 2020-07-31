using Microsoft.Azure.Cosmos.Table;
using Microsoft.Azure.Cosmos.Table.Queryable;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mijennin.BlazorDemo.QuizCommon.Data.TableStorage
{
    internal static class CloudTableExtensions
    {
        public static async Task<T> Get<T>(this CloudTable table, string rowKey) where T : ITableEntity
        {
            return await Get<T>(table, TableStorageContext.DefaultPartitionName, rowKey);
        }

        public static async Task<T> Get<T>(this CloudTable table, string partitionKey, string rowKey) where T : ITableEntity
        {
            await table.CreateIfNotExistsAsync();

            var getOperation = TableOperation.Retrieve<T>(partitionKey, rowKey);
            var result = await table.ExecuteAsync(getOperation).ConfigureAwait(false);
            return (T)result.Result;
        }

        public static async Task<T> Insert<T>(this CloudTable table, T item) where T : ITableEntity
        {
            await table.CreateIfNotExistsAsync();

            var insertOperation = TableOperation.Insert(item);
            var result = await table.ExecuteAsync(insertOperation).ConfigureAwait(false);
            return (T)result.Result;
        }

        public static async Task<T> Update<T>(this CloudTable table, T item) where T : ITableEntity
        {
            await table.CreateIfNotExistsAsync();

            var updateOperation = TableOperation.Replace(item);
            var result = await table.ExecuteAsync(updateOperation).ConfigureAwait(false);
            return (T)result.Result;
        }

        public static async Task<T> Merge<T>(this CloudTable table, T item) where T : ITableEntity
        {
            await table.CreateIfNotExistsAsync();

            var mergeOperation = TableOperation.Merge(item);
            var result = await table.ExecuteAsync(mergeOperation).ConfigureAwait(false);
            return (T)result.Result;
        }

        public static async Task Delete(this CloudTable table, string rowKey)
        {
            await Delete(table, TableStorageContext.DefaultPartitionName, rowKey);
        }

        public static async Task Delete(this CloudTable table, string partitionKey, string rowKey)
        {
            await table.CreateIfNotExistsAsync();

            var deleteEntity = new TableEntity(partitionKey, rowKey) { ETag = "*" };
            var deleteOperation = TableOperation.Delete(deleteEntity);
            await table.ExecuteAsync(deleteOperation).ConfigureAwait(false);
        }

        public static async Task<List<T>> ExecuteQueryAsync<T>(this CloudTable table, TableQuery<T> query, CancellationToken ct = default(CancellationToken)) where T : ITableEntity, new()
        {
            await table.CreateIfNotExistsAsync();

            var items = new List<T>();
            TableContinuationToken? token = null;

            do
            {
                TableQuerySegment<T> seg = await table.ExecuteQuerySegmentedAsync<T>(query, token);
                items.AddRange(seg);
                token = seg.ContinuationToken;
            } while (token != null && !ct.IsCancellationRequested);

            return items;
        }

        public async static Task<IEnumerable<TElement>> ExecuteAsync<TElement>(this TableQuery<TElement> tableQuery, CancellationToken ct)
        {
            TableQuery<TElement>? nextQuery = tableQuery;
            var continuationToken = default(TableContinuationToken);
            var results = new List<TElement>();

            do
            {
                var queryResult = await nextQuery.ExecuteSegmentedAsync(continuationToken, ct);
                results.Capacity += queryResult.Results.Count;
                results.AddRange(queryResult.Results);

                continuationToken = queryResult.ContinuationToken;
                if (continuationToken != null && tableQuery.TakeCount.HasValue)
                {
                    var itemsToLoad = tableQuery.TakeCount.Value - results.Count;
                    nextQuery = itemsToLoad > 0
                        ? tableQuery.Take<TElement>(itemsToLoad).AsTableQuery()
                        : null;
                }

            } while (continuationToken != null && nextQuery != null && !ct.IsCancellationRequested);

            return results;
        }
    }
}
