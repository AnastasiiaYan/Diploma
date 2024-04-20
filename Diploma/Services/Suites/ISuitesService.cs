using Diploma.Models;

namespace Diploma.Services.Projects
{
    public interface ISuitesService
    {
        Task<NewSuiteResponse> CreateNewTestSuite(NewSuiteRequest newSuiteRequest, string projectCode);

        Task<SpecificSuiteResponse> GetSpecificTestSuite(string projectCode, int suiteid);

        Task<AllSuitesResponse> GetAllTestSuitesBy(string projectCode, string? suiteName);

        Task<ErrorResponse> GetAllTestSuitesBy(string nonExistingProjectCode);
    }
}