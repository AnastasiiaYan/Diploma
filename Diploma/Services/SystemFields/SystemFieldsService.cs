using RestSharp;
using Diploma.Clients;

namespace Diploma.Services.SystemFields;

public class SystemFieldsService : ISystemFieldsService, IDisposable
{
    private readonly QaseRestClient _client;

    public SystemFieldsService(QaseRestClient client)
    {
        _client = client;
    }

    public Task<Models.SystemFields> GetSystemFields()
    {
        var request = new RestRequest("/v1/system_field");
        return _client.ExecuteAsync<Models.SystemFields>(request);
    }
    
    public void Dispose()
    {
        _client?.Dispose();
        GC.SuppressFinalize(this);
    }
}