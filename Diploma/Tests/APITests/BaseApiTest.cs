using Diploma.Core.Clients;
using Diploma.Services.Projects;

namespace Diploma.Tests.APITests;

public class BaseApiTest
{
    protected ProjectsService? ProjectsService;

    [OneTimeSetUp]
    public void SetUpApi()
    {
        var restClient = new ApiRestClient();
        ProjectsService = new ProjectsService(restClient);
    }
    
    [OneTimeTearDown]
    public void TearDown()
    {
        ProjectsService!.Dispose();
    }
}