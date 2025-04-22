using Lokalise.Api.Collections.Branches;
using Lokalise.Api.Collections.Comments;
using Lokalise.Api.Collections.Contributors;
using Lokalise.Api.Collections.Files;
using Lokalise.Api.Collections.Keys;
using Lokalise.Api.Collections.Processes;
using Lokalise.Api.Collections.Projects;

namespace Lokalise.Api
{
    public interface ILokaliseClient
    {
        public IBranchesCollection Branches { get; }
        public ICommentsCollection Comments { get; }
        public IContributorsCollection Contributors { get; }
        public IProjectsCollection Projects { get; }
        public IProcessesCollection Processes { get; }
        public IFilesCollection Files { get; }
        public IKeysCollection Keys { get; }
    }
}
