using CreatorCoreAPI.Models;

namespace CreatorCoreAPI.Interfaces
{
    public interface ITransactionRepository
    {
        Task<List<Transaction>> GetAllAsync();
        
        Task<Transaction?> GetByIdAsync(int id);

        Task<Transaction> CreateAsyn(Transaction transactionModel);

        Task<Transaction?> UpdateAsync(int id, Transaction transactionModel);

        Task<Transaction?> DeleteAsync(int id);
    }
}