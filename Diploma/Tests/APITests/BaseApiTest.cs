using Diploma.Clients;
using Diploma.Services.SystemFields;

namespace Diploma.Tests.APITests;

public class BaseApiTest
{
    protected SystemFieldsService SystemFieldsService;

    [OneTimeSetUp]
    public void SetUpApi()
    {
        var restClient = new QaseRestClient();
        SystemFieldsService = new SystemFieldsService(restClient);
    }
    
    [OneTimeTearDown]
    public void TearDown()
    {
        SystemFieldsService.Dispose();
    }
}