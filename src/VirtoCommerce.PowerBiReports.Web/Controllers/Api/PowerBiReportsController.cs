using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VirtoCommerce.Platform.Core.Settings;
using VirtoCommerce.PowerBiReports.Core;

namespace VirtoCommerce.PowerBiReports.Web.Controllers.Api
{
    [Route("api/power-bi-reports")]
    public class PowerBiReportsController : Controller
    {
        private const string NotConfiguredPage =
            "<!DOCTYPE html><html><head><meta charset=\"UTF-8\"><title>Power BI Reports</title></head>" +
            "<body style=\"font-family:sans-serif;margin:40px\"><h1>Power BI Reports is not configured</h1>" +
            "<p>Set the report URL in Settings &gt; Power BI Reports &gt; General (setting <b>PowerBiReports.PowerBiReportsUrl</b>).</p>" +
            "</body></html>";

        private readonly ISettingsManager _settingsManager;

        public PowerBiReportsController(ISettingsManager settingsManager)
        {
            _settingsManager = settingsManager;
        }

        [HttpGet]
        [Route("redirect")]
        [Authorize(ModuleConstants.Security.Permissions.Read)]
        public ActionResult Redirect()
        {
            var redirectToPowerBIUrl = _settingsManager.GetValue<string>(ModuleConstants.Settings.General.PowerBiReportsUrl);

            // An absolute http(s) URL or a local path (/apps/my-report/). Anything else would be a broken or unsafe redirect:
            // a relative "False" (the old default) to /api/power-bi-reports/False, javascript:, a protocol-relative //host
            var isHttpUrl = Uri.TryCreate(redirectToPowerBIUrl, UriKind.Absolute, out var uri) && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
            if (!isHttpUrl && !Url.IsLocalUrl(redirectToPowerBIUrl))
            {
                return Content(NotConfiguredPage, "text/html");
            }

            return Redirect(redirectToPowerBIUrl);
        }

    }
}
