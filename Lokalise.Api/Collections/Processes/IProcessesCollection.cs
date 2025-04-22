using System.Threading.Tasks;
using Lokalise.Api.Models;

namespace Lokalise.Api.Collections.Processes
{
    public interface IProcessesCollection
    {
        /// <summary>
        /// <para>Retrieves a Queued process object with an additional details field containing information for a specific process type.</para>
        /// <para>Requires read_background_processes OAuth access scope.</para>
        /// </summary>
        /// <param name="projectId">A unique project identifier</param>
        /// <param name="processId">A unique process identifier.</param>
        /// <returns></returns>
        public Task<ProcessInformation?> RetrieveProcessAsync(string projectId, string processId);
    }
}