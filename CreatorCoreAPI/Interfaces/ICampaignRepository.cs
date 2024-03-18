using CreatorCoreAPI.Models;

namespace CreatorCoreAPI.Interfaces
{
    public interface ICampaignRepository
    {
        Task<List<Campaign>> GetAllAsync();
        
        Task<Campaign?> GetByIdAsync(int id);

        Task<Campaign> CreateAsyn(Campaign campaignModel);

        Task<Campaign?> UpdateAsync(int id, Campaign campaignModel);

        Task<Campaign?> DeleteAsync(int id);
    }
}