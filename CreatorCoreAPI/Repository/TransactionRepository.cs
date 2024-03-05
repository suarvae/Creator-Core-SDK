using CreatorCoreAPI.Data;
using CreatorCoreAPI.Interfaces;
using CreatorCoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CreatorCoreAPI.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDBContext _context;

        public TransactionRepository(ApplicationDBContext context) => _context = context;

        public async Task<Transaction> CreateAsyn(Transaction transactionModel)
        {
            await _context.Transactions.AddAsync(transactionModel);
            await _context.SaveChangesAsync();
            return transactionModel;
        }

        public async Task<Transaction?> DeleteAsync(int id)
        {
            var transaction = await _context.Transactions.FirstOrDefaultAsync(t => t.transactionID == id);

            if(transaction == null)
            return null;
            else{
                _context.Transactions.Remove(transaction);
                await _context.SaveChangesAsync();
                return transaction;
            }
        }

        public async Task<List<Transaction>> GetAllAsync()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task<Transaction?> GetByIdAsync(int id)
        {
            return await _context.Transactions.FindAsync(id);
        }

        public async Task<Transaction?> UpdateAsync(int id, Transaction transactionModel)
        {
            var existingTransaction = await _context.Transactions.FindAsync(id);

            if(existingTransaction == null)
                return null;
            else
            {
                existingTransaction.itemName = transactionModel.itemName;
                existingTransaction.transactionValue = transactionModel.transactionValue;
                
                await _context.SaveChangesAsync();

                return existingTransaction;
            }
        }
    }
}