using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VirtoCommerce.Platform.Core.Settings;
using VirtoCommerce.PowerBiReports.Core;

namespace VirtoCommerce.PowerBiReports.Web.Controllers.Api
{
    [Route("api/power-bi-reports")]
    public class PowerBiReportsController : Controller
    {
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
            var redirectToPowerBIUrl = _settingsManager.GetValue(ModuleConstants.Settings.General.PowerBiReportsUrl.Name, string.Empty);

            if (string.IsNullOrEmpty(redirectToPowerBIUrl))
                return NotFound("PowerBiReportsUrl is not configured in Platfortm Settings");

            return Redirect(redirectToPowerBIUrl);
        }

    }
}
