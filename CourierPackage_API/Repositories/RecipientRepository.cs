using CourierPackage_API.Data;
using CourierPackage_API.Interfaces;
using CourierPackage_API.Models.DTOs;
using CourierPackage_API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourierPackage_API.Repositories
{
    public class RecipientRepository:IRecipientRepository
    {
        private readonly AppDbContext _dbContext;

        public RecipientRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<(IEnumerable<RecipientResponseDto> recipients, string message)> GetAllRecipients()
        {
            var list = await _dbContext.recipient.ToListAsync();

            var result = new List<RecipientResponseDto>();

            foreach (Recipient recipient in list)
            {
                var recipientResponseDto = new RecipientResponseDto();

                recipientResponseDto.RecipientId = recipient.RecipientId;
                recipientResponseDto.SenderId = recipient.SenderId;
                recipientResponseDto.UserName = recipient.UserName;
                recipientResponseDto.NickName = recipient.NickName;
                recipientResponseDto.ContactNumber = recipient.ContactNumber;
                recipientResponseDto.Email = recipient.Email;
                recipientResponseDto.IsActive = recipient.IsActive;

                result.Add(recipientResponseDto);
            }

            return (result, "Recipients retrieved successfully.");
        }

        public async Task<(bool success, string message)> CreateRecipient(
           RecipientRequestDto request)
        {
            var recipient = new Recipient
            {
                SenderId = request.SenderId,
                UserName = request.UserName,
                NickName = request.NickName,
                ContactNumber = request.ContactNumber,
                Email = request.Email,

                CreatedBy = request.TrnUser,
                CreatedDate = DateTime.Now,
                IsActive = true
            };

            await _dbContext.recipient.AddAsync(recipient);

            await _dbContext.SaveChangesAsync();

            return (true, "Recipient created successfully.");
        }

        public async Task<(bool success, string message)> UpdateRecipient(
            RecipientRequestDto request)
        {
            var recipient = await _dbContext.recipient
                .FirstOrDefaultAsync(x =>
                    x.RecipientId == request.RecipientId);

            if (recipient == null)
            {
                return (false, "Recipient not found.");
            }

            recipient.SenderId =
                request.SenderId;

            recipient.UserName =
                request.UserName;

            recipient.NickName =
                request.NickName;

            recipient.ContactNumber =
                request.ContactNumber;

            recipient.Email =
                request.Email;


            recipient.UpdatedBy = request.TrnUser;
            recipient.UpdatedDate = DateTime.Now;

            recipient.IsActive =
                true;

            _dbContext.recipient.Update(recipient);

            await _dbContext.SaveChangesAsync();

            return (true, "Recipient updated successfully.");
        }

        public async Task<(bool success, string message)> DeleteRecipient(
            int recipientId)
        {
            var recipient = await _dbContext.recipient
                .FirstOrDefaultAsync(x =>
                    x.RecipientId == recipientId);

            if (recipient == null)
            {
                return (false, "Recipient not found.");
            }

            recipient.IsActive = false;

            await _dbContext.SaveChangesAsync();

            return (true, "Recipient deleted successfully.");
        }
    }
}
