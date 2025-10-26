namespace RealEstate.API.Interfaces
{
    public interface IApiKeyAuthentication
    {
        public bool IsValidApiKey(string apiKey);
    }
}
