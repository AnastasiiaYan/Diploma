using Diploma.Models;
using Diploma.Services.SystemFields;
using NLog;

namespace Diploma.Tests.APITests;

public class SystemFieldsTest : BaseApiTest
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    
    [Test]
    [Order(1)]
    public void GetSystemFieldsTest()
    {
        var response = SystemFieldsService.GetSystemFields();
        
        
    }
}