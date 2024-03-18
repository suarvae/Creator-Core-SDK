using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatorCoreAPI.Dtos.Transaction
{
    public class CampaignDto
    {
        public int campaignId{get;set;}
        public string campaignTitle{get;set;} = string.Empty;
        public string campaignDescription{get;set;} = string.Empty;
        public decimal campaignValue{get;set;} =0;
        public DateTime issuedDate {get;set;} = DateTime.Now;
        public DateTime startDate {get;set;}
        public int? creatorID{get;set;}
    }
}