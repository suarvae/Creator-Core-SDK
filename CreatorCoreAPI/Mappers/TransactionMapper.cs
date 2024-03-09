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
            };
        }

         public static Transaction ToTransactionFromCreate(this CreateTransactionDto transactionDto, int id)
        {
            return new Transaction()
            {
                itemName = transactionDto.itemName,                             
                transactionValue = transactionDto.transactionValue,
                creatorID = id
            };
        }


         public static Transaction ToTransactionFromUpdate(this UpdateTransactionRequestDto transactionDto)
        {
            return new Transaction()
            {
                itemName = transactionDto.itemName,               
                
                transactionValue = transactionDto.transactionValue,
            };
        }
    }
}