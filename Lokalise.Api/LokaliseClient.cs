using Lokalise.Api.Collections.Branches;
using Lokalise.Api.Collections.Comments;
using Lokalise.Api.Collections.Contributors;
using Lokalise.Api.Collections.Files;
using Lokalise.Api.Collections.Keys;
using Lokalise.Api.Collections.Projects;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Lokalise.Api.Collections.Processes;

namespace Lokalise.Api
{
    public class LokaliseClient : ILokaliseClient
    {
        private const string ApiTokenHeader = "X-Api-Token";

        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        private IFilesCollection? _files;
        private IProjectsCollection? _projects;
        private IProcessesCollection? _processes;
        private IBranchesCollection? _branches;
        private ICommentsCollection? _comments;
        private IContributorsCollection? _contributors;
        private IKeysCollection? _keys;

        public LokaliseClient(string apiToken, HttpClient? httpClient = null)
        {
            _httpClient = httpClient ?? new HttpClient();

            if (_httpClient.DefaultRequestHeaders.Contains(ApiTokenHeader))
                _httpClient.DefaultRequestHeaders.Remove(ApiTokenHeader);

            _httpClient.DefaultRequestHeaders.Add(ApiTokenHeader, apiToken);

            _httpClient.BaseAddress = new Uri("https://api.lokalise.com/api2/");
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
        }

        public IFilesCollection Files => _files ??= new FilesCollection(_httpClient, _jsonSerializerOptions);

        public IProjectsCollection Projects => _projects ??= new ProjectsCollection(_httpClient, _jsonSerializerOptions);
        
        public IProcessesCollection Processes => _processes ??= new ProcessesCollection(_httpClient, _jsonSerializerOptions);

        public IBranchesCollection Branches => _branches ??= new BranchesCollection(_httpClient, _jsonSerializerOptions);

        public ICommentsCollection Comments => _comments ??= new CommentsCollection(_httpClient, _jsonSerializerOptions);

        public IContributorsCollection Contributors => _contributors ??= new ContributorsCollection(_httpClient, _jsonSerializerOptions);

        public IKeysCollection Keys => _keys ??= new KeysCollection(_httpClient, _jsonSerializerOptions);
    }
}
