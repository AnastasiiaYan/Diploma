using Diploma.Helpers.Configuration;
using NLog;
using RestSharp;
using RestSharp.Authenticators.OAuth2;

namespace Diploma.Clients
{
    public sealed class QaseRestClient 
    {
    private readonly RestClient _client;
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private readonly String SecretHeader = "72d93f3d85b5d4b18e0d3c52b3eb0701ba3b2e6dcda2f59674fd20720b20a99d";

    public QaseRestClient()
    {
        var options = new RestClientOptions(Configurator.AppSettings.URL ?? throw new InvalidOperationException())
        {
            Authenticator = 
                new OAuth2AuthorizationRequestHeaderAuthenticator(SecretHeader)
        };

        _client = new RestClient(options);
    }
    
    public void Dispose()
    {
        _client.Dispose();
        GC.SuppressFinalize(this);
    }

    private void LogRequest(RestRequest request)
    {
        _logger.Debug($"{request.Method} request to: {request.Resource}");

        var body = request.Parameters
            .FirstOrDefault(p => p.Type == ParameterType.RequestBody)?.Value;

        if (body != null)
        {
            _logger.Debug($"body: {body}");
        }
    }

    private void LogResponse(RestResponse response)
    {
        if (response.ErrorException != null)
        {
            _logger.Error(
                $"Error retrieving response. Check inner details for more info. \n{response.ErrorException.Message}");
        }
        
        _logger.Debug($"Request finished with status code: {response.StatusCode}");

        if (!string.IsNullOrEmpty(response.Content))
        {
            _logger.Debug(response.Content);
        }
    }

    public async Task<RestResponse> ExecuteAsync(RestRequest request)
    {
        LogRequest(request);
        var response = await _client.ExecuteAsync(request);
        LogResponse(response);

        return response;
    }

    public async Task<T> ExecuteAsync<T>(RestRequest request)
    {
        LogRequest(request);
        var response = await _client.ExecuteAsync<T>(request);
        LogResponse(response);

        return response.Data ?? throw new InvalidOperationException(); 
    } 
    }
}