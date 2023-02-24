using AcmeCorpTesting.Authentication;
using Microsoft.Extensions.Configuration;

namespace AcmeCorpTesting.Helpers
{
    public class Helper
    {
        public static string GetApiKey()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

                IConfiguration config = builder.Build();
                var apiKey = config.GetValue<string>(AuthConstants.ApiKeySectionName);
                return apiKey;  

        }

    }
}
