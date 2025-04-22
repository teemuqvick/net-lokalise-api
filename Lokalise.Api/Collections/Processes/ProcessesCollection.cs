using Lokalise.Api.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lokalise.Api.Collections.Processes
{
    internal class ProcessesCollection : BaseCollection, IProcessesCollection
    {
        internal ProcessesCollection(
            HttpClient httpClient,
            JsonSerializerOptions jsonSerializerOptions)
            : base(httpClient, jsonSerializerOptions)
        {
        }

        /// <inheritdoc />
        public async Task<ProcessInformation?> RetrieveProcessAsync(string projectId, string processId)
        {
            var result = await GetAsync<ProcessInformation>($"{ProcessesUri(projectId)}/{processId}");
            return result;
        }
        
        private string ProcessesUri(string projectId) => $"projects/{projectId}/processes";
    }
}
