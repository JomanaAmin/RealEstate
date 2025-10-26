using Microsoft.AspNetCore.Mvc;

namespace RealEstate.API.CustomAttribute
{
    public class ApiKeyAttribute : ServiceFilterAttribute
    {
        public ApiKeyAttribute() : base(typeof(ApiKeyAuthorizationFilter))
        {
        }
    }
}
