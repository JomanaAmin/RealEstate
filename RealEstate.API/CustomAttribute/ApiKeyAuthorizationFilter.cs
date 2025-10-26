using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using RealEstate.API.Interfaces;

namespace RealEstate.API.CustomAttribute
{
    public class ApiKeyAuthorizationFilter : IAuthorizationFilter

    {
        private IApiKeyAuthentication apiKeyAuthentication;
        public ApiKeyAuthorizationFilter(IApiKeyAuthentication apiKeyAuthentication)
        {
            this.apiKeyAuthentication = apiKeyAuthentication;
        } //dependency injection

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var userApiKey = context.HttpContext.Request.Headers[Constants.ApiKeyHeader];
            if (userApiKey.IsNullOrEmpty())
            {
                context.Result = new BadRequestResult();
                return;
            }
            if (!apiKeyAuthentication.IsValidApiKey(userApiKey)) 
            {
                context.Result = new UnauthorizedResult();
                return;
            }
        }
    }
}
