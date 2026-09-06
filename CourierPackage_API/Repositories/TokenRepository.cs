using CourierPackage_API.Data;
using CourierPackage_API.Interfaces;
using CourierPackage_API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourierPackage_API.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly AppDbContext _context;

        public TokenRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> UpdateRefreshToken(string UserId, DateTime ExpDate, string TrnUser)
        {
            //var exists = await _context.refreshTokens.AnyAsync( rf => rf.UserId == UserId);

            var exists = await _context.refreshTokens
                .FirstOrDefaultAsync(rf => rf.UserId == UserId);

            if (exists == null)
            {
                var rf = new RefreshToken
                {
                    UserId = UserId,
                    ExpireDate = ExpDate,
                    CreatedBy = TrnUser,
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                };

                var result = await _context.refreshTokens.AddAsync(rf);

                await _context.SaveChangesAsync();

                return "Refresh Token has been successfully created.";
            }

            exists.IsActive = true;
            exists.UpdatedDate = DateTime.Now;
            exists.UpdatedBy = TrnUser;

            await _context.SaveChangesAsync();

            return "Refresh Token has been successfully updated.";
        }
        public async Task<bool> IsExpireRefreshToken(string UserId)
        {
            var exists = await _context.refreshTokens.AnyAsync( rf => rf.UserId == UserId);

            return exists;
        }
    }
}
