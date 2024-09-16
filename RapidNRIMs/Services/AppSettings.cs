using Microsoft.Extensions.Configuration;

namespace RapidNRIMs.Services
{
    public class AppSettings
    {
        public string UploadPath { get; set; }
    }

    public static class AppSettingsHelper
    {
        public static AppSettings GetAppSettings(IConfiguration configuration)
        {
            var appSettingsSection = configuration.GetSection("appSettings");
            var appSettings = appSettingsSection.Get<AppSettings>();
            return appSettings;
        }
    }

}
