using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.Google.Calendar.HttpClients.Abstract;
using Soenneker.Google.Calendar.OpenApiClientUtil.Abstract;
using Soenneker.Google.Calendar.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Google.Calendar.OpenApiClientUtil;
public sealed class GoogleCalendarOpenApiClientUtil : IGoogleCalendarOpenApiClientUtil
{
    private readonly AsyncSingleton<GoogleCalendarOpenApiClient> _client;

    public GoogleCalendarOpenApiClientUtil(IGoogleCalendarOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<GoogleCalendarOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("Google:Calendar:AccessToken");
            string authHeaderName = configuration["Calendar:AuthHeaderName"] ?? "Authorization";
            string authHeaderValueTemplate = configuration["Calendar:AuthHeaderValueTemplate"] ?? "Bearer {token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerName: authHeaderName, headerValue: authHeaderValue),
                httpClient: httpClient);

            return new GoogleCalendarOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<GoogleCalendarOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
