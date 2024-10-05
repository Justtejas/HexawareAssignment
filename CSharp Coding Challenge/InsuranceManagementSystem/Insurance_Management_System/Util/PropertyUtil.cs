using Microsoft.Extensions.Configuration;

namespace Insurance_Management_System.Util
{
    internal static class PropertyUtil
    {
        private static IConfiguration _iconfiguration; 
        static PropertyUtil()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            _iconfiguration = builder.Build();
        }
        public static string GetPropertyString()
        {
            return _iconfiguration.GetConnectionString("LocalConnectionString");
        }
    }
}
