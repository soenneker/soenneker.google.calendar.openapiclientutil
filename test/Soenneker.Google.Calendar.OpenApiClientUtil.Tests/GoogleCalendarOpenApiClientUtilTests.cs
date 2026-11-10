using Soenneker.Google.Calendar.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Google.Calendar.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class GoogleCalendarOpenApiClientUtilTests : HostedUnitTest
{
    private readonly IGoogleCalendarOpenApiClientUtil _openapiclientutil;

    public GoogleCalendarOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<IGoogleCalendarOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
