using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreatorCoreAPI.Dtos.Client.Creator.Transactions;
using CreatorCoreAPI.Dtos.Creator;
using CreatorCoreAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CreatorCoreAPI.Mappers
{
    public static class CreatorMappers
    {
        public static CreatorDto ToCreatorDto(this Creator creatorModel)
        {
            return new CreatorDto
            {
                creatorID = creatorModel.creatorID,
                creatorName = creatorModel.creatorName,
                creatorRevenue = creatorModel.creatorRevenue,
                campaigns = creatorModel.campaigns.Select(t => t.ToCampaignDto()).ToList()
            };
        }

        public static Creator ToCreatorFromCreateDto(this CreateCreatorRequestDto createModel)
        {
            return new Creator
            {
                creatorName = createModel.creatorName,
                creatorRevenue = createModel.creatorRevenue,
            };
        }
    }
}