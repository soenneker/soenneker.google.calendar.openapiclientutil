using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Google.Calendar.HttpClients.Registrars;
using Soenneker.Google.Calendar.OpenApiClientUtil.Abstract;

namespace Soenneker.Google.Calendar.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class GoogleCalendarOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="GoogleCalendarOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddGoogleCalendarOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddGoogleCalendarOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IGoogleCalendarOpenApiClientUtil, GoogleCalendarOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="GoogleCalendarOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddGoogleCalendarOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddGoogleCalendarOpenApiHttpClientAsSingleton()
                .TryAddScoped<IGoogleCalendarOpenApiClientUtil, GoogleCalendarOpenApiClientUtil>();

        return services;
    }
}
