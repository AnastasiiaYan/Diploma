using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Diploma.Helpers.Configuration
{
    public static class Configurator
    {
        private static readonly Lazy<IConfiguration> configuration;
        public static IConfiguration Configuration => configuration.Value;

        static Configurator()
        {
            configuration = new Lazy<IConfiguration>(BuildConfiguration);
        }

        private static IConfiguration BuildConfiguration()
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath ?? throw new InvalidOperationException())
                .AddJsonFile("appsettings.json");

            var appSettingFiles = Directory.EnumerateFiles(basePath ?? string.Empty, "appsettings.*.json");

            foreach (var appSettingFile in appSettingFiles)
            {
                builder.AddJsonFile(appSettingFile);
            }

            return builder.Build();
        }

        public static AppSettings AppSettings
        {
            get
            {
                var appSettings = new AppSettings();
                var child = Configuration.GetSection("AppSettings");

                appSettings.URL = child["URL"];
                appSettings.URI = child["URI"];
                appSettings.ApiKey = child["ApiKey"];
                appSettings.Username = child["Username"];
                appSettings.Password = child["Password"];

                return appSettings;
            }
        }

        public static string? BrowserType => Configuration[nameof(BrowserType)];
        public static double WaitsTimeout => Convert.ToDouble(Configuration[nameof(WaitsTimeout)]);
    }
}