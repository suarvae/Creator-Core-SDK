using CreatorCoreAPI.Dtos.Transaction;
using CreatorCoreAPI.Models;

namespace CreatorCoreAPI.Mappers
{
    public static class CampaignMapper
    {
        public static CampaignDto ToCampaignDto(this Campaign transactionModel)
        {
            return new CampaignDto()
            {
                campaignId = transactionModel.campaignId,
                campaignTitle = transactionModel.campaignTitle,               
                campaignDescription = transactionModel.campaignDescription,
                campaignValue = transactionModel.campaignValue,            
                issuedDate = transactionModel.issuedDate,
                creatorID = transactionModel.creatorID,
            };
        }

         public static Campaign ToCampaignFromCreate(this CreateCampaignDto transactionDto, int id)
        {
            return new Campaign()
            {
                campaignTitle = transactionDto.campaignTitle,                             
                campaignValue = transactionDto.campaignValue,
                campaignDescription = transactionDto.campaignDescription,
                creatorID = id
            };
        }


         public static Campaign ToTransactionFromUpdate(this UpdateCampaignRequestDto transactionDto)
        {
            return new Campaign()
            {
                campaignTitle = transactionDto.campaignTitle,               
                campaignDescription = transactionDto.campaignDescription,
                campaignValue = transactionDto.campaignValue,
            };
        }
    }
}