using CreatorCoreAPI.Dtos.Transaction;

namespace CreatorCoreAPI.Dtos.Client.Creator.Transactions
{
    public class CreatorDto
    {
         public int creatorID {get; set;}
        public string creatorName{get;set;} = string.Empty;
        
        public float creatorRevenueSplit {get; set;}

        public decimal creatorRevenue{get;set;}
        public long lifeTimeEarnings{get;set;}
        public List<TransactionDto> transactions {get;set;}
    }
}