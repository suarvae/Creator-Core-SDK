using CreatorCoreAPI.Dtos.Transaction;
using CreatorCoreAPI.Models;

namespace CreatorCoreAPI.Mappers
{
    public static class TransactionMapper
    {
        public static TransactionDto ToTransactionDto(this Transaction transactionModel)
        {
            return new TransactionDto()
            {
                transactionID = transactionModel.transactionID,
                itemName = transactionModel.itemName,               
                
                transactionValue = transactionModel.transactionValue,
                transactionDate = transactionModel.transactionDate,
                
                creatorID = transactionModel.creatorID,
                clientID = transactionModel.clientID,
            };
        }
    }
}