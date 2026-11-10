using Soenneker.Google.Calendar.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Google.Calendar.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface IGoogleCalendarOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<GoogleCalendarOpenApiClient> Get(CancellationToken cancellationToken = default);
}
