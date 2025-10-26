using Microsoft.IdentityModel.Tokens;
using RealEstate.API.Interfaces;

namespace RealEstate.API
{
    public class ApiKeyAuthentication : IApiKeyAuthentication
    {
        private readonly IConfiguration configuration;
        public ApiKeyAuthentication(IConfiguration configuration) 
        {
            this.configuration = configuration;
        }
        public bool IsValidApiKey(string apiKey)
        {
            if (apiKey.IsNullOrEmpty()) 
                return false;
            var key=configuration.GetValue<string>(Constants.ApiKeyName);
            if(key is null || key!=apiKey)
                return false;
            return true;
        }
    }
}
