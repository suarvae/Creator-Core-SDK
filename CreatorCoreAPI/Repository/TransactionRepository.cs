using CreatorCoreAPI.Data;
using CreatorCoreAPI.Interfaces;
using CreatorCoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CreatorCoreAPI.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDBContext _context;
        
        public TransactionRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Transaction>> GetAllAsync()
        {
            return await _context.Transactions.ToListAsync();
        }
    }
}