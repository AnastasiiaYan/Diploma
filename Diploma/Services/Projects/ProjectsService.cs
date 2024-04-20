using Diploma.Core.Clients;
using Diploma.Models;
using RestSharp;

namespace Diploma.Services.Projects
{
    public class ProjectsService : IProjectsService, IDisposable
    {
        private readonly ApiRestClient _client;

        public ProjectsService(ApiRestClient client)
        {
            _client = client;
        }

        public Task<NewProjectResponse> CreateNewProject(NewProjectRequest newProjectRequest)
        {
            var request = new RestRequest("/v1/project", Method.Post)
                .AddJsonBody(newProjectRequest);

            return _client.ExecuteAsync<NewProjectResponse>(request);
        }

        public Task<ProjectResponse> GetProjectByCode(string code)
        {
            var request = new RestRequest("/v1/project/{code}")
                .AddUrlSegment("code", code);

            return _client.ExecuteAsync<ProjectResponse>(request);
        }

        public Task<ErrorResponse> GetProjectByNonExistingCode(string nonExistingCode)
        {
            var request = new RestRequest("/v1/project/{code}")
                .AddUrlSegment("code", nonExistingCode);

            return _client.ExecuteAsync<ErrorResponse>(request);
        }

        public void Dispose()
        {
            _client?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}