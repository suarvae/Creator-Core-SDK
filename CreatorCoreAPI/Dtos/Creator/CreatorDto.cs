using CreatorCoreAPI.Dtos.Transaction;

namespace CreatorCoreAPI.Dtos.Client.Creator.Transactions
{
    public class CreatorDto
    {
         public int creatorID {get; set;}
        public string creatorName{get;set;} = string.Empty;        
        public decimal creatorRevenue{get;set;} = 0;
        public List<CampaignDto> campaigns {get;set;} = new();
    }
}