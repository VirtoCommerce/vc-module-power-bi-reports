using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using Moq;
using VirtoCommerce.Platform.Core.Settings;
using VirtoCommerce.PowerBiReports.Core;
using VirtoCommerce.PowerBiReports.Web.Controllers.Api;
using Xunit;

namespace VirtoCommerce.PowerBiReports.Tests;

[Trait("Category", "Unit")]
public class PowerBiReportsControllerTests
{
    private static readonly SettingDescriptor Setting = ModuleConstants.Settings.General.PowerBiReportsUrl;

    private static Mock<ISettingsManager> SettingsManager(object storedValue)
    {
        var manager = new Mock<ISettingsManager>();
        manager.Setup(x => x.GetObjectSettingAsync(Setting.Name, null, null))
            .ReturnsAsync(new ObjectSettingEntry(Setting) { Value = storedValue });
        return manager;
    }

    private static PowerBiReportsController Controller(object storedValue) => new(SettingsManager(storedValue).Object)
    {
        Url = new UrlHelper(new ActionContext(new DefaultHttpContext(), new RouteData(), new ActionDescriptor())),
    };

    [Fact]
    public void UrlSetting_HasNoNonStringDefault()
    {
        // The old DefaultValue (bool false) read back as "False" on the platform and became a relative redirect target
        Assert.True(Setting.DefaultValue is null or string);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("False")]
    [InlineData("javascript:alert(1)")]
    [InlineData("//evil.example/report")]
    [InlineData("/\\evil.example/report")]
    [InlineData("ftp://example.com/report")]
    public void Redirect_NotConfigured_ShowsNotConfiguredPage(string storedValue)
    {
        var result = Controller(storedValue).Redirect();

        var content = Assert.IsType<ContentResult>(result);
        Assert.Equal("text/html", content.ContentType);
        Assert.Contains("not configured", content.Content);
    }

    [Theory]
    [InlineData("https://app.powerbi.com/groups/me/reports/123")]
    [InlineData("/apps/my-report/")]
    public void Redirect_Configured_RedirectsToUrl(string url)
    {
        var result = Controller(url).Redirect();

        Assert.Equal(url, Assert.IsType<RedirectResult>(result).Url);
    }
}
