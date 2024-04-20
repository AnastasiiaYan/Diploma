using Diploma.Core.Clients;
using Diploma.Models;
using RestSharp;

namespace Diploma.Services.Projects
{
    public class SuitesService : ISuitesService, IDisposable
    {
        private readonly ApiRestClient _client;

        public SuitesService(ApiRestClient client)
        {
            _client = client;
        }

        public Task<NewSuiteResponse> CreateNewTestSuite(NewSuiteRequest newSuiteRequest, string projectCode)
        {
            var request = new RestRequest("/v1/suite/{code}", Method.Post)
                .AddJsonBody(newSuiteRequest)
                .AddUrlSegment("code", projectCode);

            return _client.ExecuteAsync<NewSuiteResponse>(request);
        }

        public Task<SpecificSuiteResponse> GetSpecificTestSuite(string projectCode, int suiteId)
        {
            var request = new RestRequest("/v1/suite/{code}/{id}")
                .AddUrlSegment("code", projectCode)
                .AddUrlSegment("id", suiteId);

            return _client.ExecuteAsync<SpecificSuiteResponse>(request);
        }

        public Task<AllSuitesResponse> GetAllTestSuitesBy(string projectCode, string? suiteName)
        {
            var request = new RestRequest("/v1/suite/{code}")
                .AddUrlSegment("code", projectCode);

            request.AddQueryParameter("search", suiteName ?? "");

            return _client.ExecuteAsync<AllSuitesResponse>(request);
        }

        public Task<ErrorResponse> GetAllTestSuitesBy(string nonExistingProjectCode)
        {
            var request = new RestRequest("/v1/suite/{code}")
                .AddUrlSegment("code", nonExistingProjectCode);

            return _client.ExecuteAsync<ErrorResponse>(request);
        }

        public void Dispose()
        {
            _client?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}