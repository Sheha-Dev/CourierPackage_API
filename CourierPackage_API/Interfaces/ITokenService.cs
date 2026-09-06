namespace CourierPackage_API.Interfaces
{
    public interface ITokenService
    {
        Task<(string AccessToken, bool success)> GenerateAccessToken(string UserId,IList<string> roles);
        Task<string> UpdateRefreshToken(string UserId, DateTime ExpDate, string TrnUser);
        Task<bool> IsExpireRefreshToken(string UserId);
    }
}
