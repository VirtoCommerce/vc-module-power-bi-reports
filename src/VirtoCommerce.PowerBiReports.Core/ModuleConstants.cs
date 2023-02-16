using System.Collections.Generic;
using VirtoCommerce.Platform.Core.Settings;

namespace VirtoCommerce.PowerBiReports.Core;

public static class ModuleConstants
{
    public static class Security
    {
        public static class Permissions
        {
            public const string Access = "PowerBiReports:access";
            public const string Create = "PowerBiReports:create";
            public const string Read = "PowerBiReports:read";
            public const string Update = "PowerBiReports:update";
            public const string Delete = "PowerBiReports:delete";

            public static string[] AllPermissions { get; } =
            {
                Access,
                Create,
                Read,
                Update,
                Delete,
            };
        }
    }

    public static class Settings
    {
        public static class General
        {
            public static SettingDescriptor PowerBiReportsUrl { get; } = new SettingDescriptor
            {
                Name = "PowerBiReports.PowerBiReportsUrl",
                GroupName = "PowerBiReports|General",
                ValueType = SettingValueType.ShortText,
                DefaultValue = false,
            };

            public static IEnumerable<SettingDescriptor> AllGeneralSettings
            {
                get
                {
                    yield return PowerBiReportsUrl;
                }
            }
        }

        public static IEnumerable<SettingDescriptor> AllSettings
        {
            get
            {
                return General.AllGeneralSettings;
            }
        }
    }
}
