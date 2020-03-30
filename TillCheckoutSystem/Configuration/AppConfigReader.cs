using Microsoft.Extensions.Configuration;

namespace TillCheckoutSystem.Configuration
{
    public static class AppConfigReader
    {
        public static IConfigurationRoot Configuration = GetConfiguration();
        private static IConfigurationRoot GetConfiguration()
        {
            return new ConfigurationBuilder().AddJsonFile($"appConfig.json").Build();
        }
    }
}
