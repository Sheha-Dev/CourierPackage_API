namespace CourierPackage_API.Interfaces
{
    public interface ITokenRepository
    {
        Task<string> UpdateRefreshToken(string UserId, DateTime ExpDate, string TrnUser);
        Task<bool> IsExpireRefreshToken(string UserId);
    }
}
