using CreatorCoreAPI.Data;
using CreatorCoreAPI.Interfaces;
using CreatorCoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CreatorCoreAPI.Repository
{
    public class CampaignRepository : ICampaignRepository
    {
        private readonly ApplicationDBContext _context;

        public CampaignRepository(ApplicationDBContext context) => _context = context;

        public async Task<Campaign> CreateAsyn(Campaign transactionModel)
        {
            await _context.Campaigns.AddAsync(transactionModel);
            await _context.SaveChangesAsync();
            return transactionModel;
        }

        public async Task<Campaign?> DeleteAsync(int id)
        {
            var transaction = await _context.Campaigns.FirstOrDefaultAsync(t => t.campaignId == id);

            if(transaction == null)
                return null;
            else{
                _context.Campaigns.Remove(transaction);
                await _context.SaveChangesAsync();
                return transaction;
            }
        }

        public async Task<List<Campaign>> GetAllAsync()
        {
            return await _context.Campaigns.ToListAsync();
        }

        public async Task<Campaign?> GetByIdAsync(int id)
        {
            return await _context.Campaigns.FindAsync(id);
        }

        public async Task<Campaign?> UpdateAsync(int id, Campaign transactionModel)
        {
            var existingTransaction = await _context.Campaigns.FindAsync(id);

            if(existingTransaction == null)
                return null;
            else
            {
                existingTransaction.campaignTitle = transactionModel.campaignTitle;
                existingTransaction.campaignDescription = transactionModel.campaignDescription;
                existingTransaction.campaignValue = transactionModel.campaignValue;
                
                await _context.SaveChangesAsync();

                return existingTransaction;
            }
        }
    }
}