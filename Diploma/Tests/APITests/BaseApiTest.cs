using Diploma.Core.Clients;
using Diploma.Services.Projects;

namespace Diploma.Tests.APITests;

public class BaseApiTest
{
    protected ProjectsService? ProjectsService;
    protected SuitesService? SuitesService;

    [OneTimeSetUp]
    public void SetUpApi()
    {
        var restClient = new ApiRestClient();
        ProjectsService = new ProjectsService(restClient);
        SuitesService = new SuitesService(restClient);
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        ProjectsService.Dispose();
        SuitesService.Dispose();
    }
}