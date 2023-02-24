using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AcmeCorpTesting.Authentication
{
    public class ApiKeyAuthFilter : IAuthorizationFilter
    {
        private readonly IConfiguration _configuration;

        public ApiKeyAuthFilter(IConfiguration configuration)
        {
            _configuration = configuration;
        }               

        public string GetApiKey() {

            var apiKey = _configuration.GetValue<string>(AuthConstants.ApiKeySectionName);
            return apiKey;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if(!context.HttpContext.Request.Headers.TryGetValue(AuthConstants.ApiKeyHeaderName, out var extractedApiKey))
            {
                context.Result = new UnauthorizedObjectResult("Api Key Missing");
                return;
            }

            var apiKey = GetApiKey();
            if(!apiKey.Equals(extractedApiKey)) {
                context.Result = new UnauthorizedObjectResult("Invalid Api Key");
                return;
            }
        }
    }
}
