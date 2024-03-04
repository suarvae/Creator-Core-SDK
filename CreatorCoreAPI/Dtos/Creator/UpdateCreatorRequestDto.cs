using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatorCoreAPI.Dtos.Creator
{
    public class UpdateCreatorRequestDto
    {
        public string creatorName{get;set;} = string.Empty;        
        public float creatorRevenueSplit {get; set;}
        public decimal creatorRevenue{get;set;}
        public long lifeTimeEarnings{get;set;}
    }
}