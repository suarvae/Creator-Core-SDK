using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using System.Threading.Tasks;

namespace CreatorCoreAPI.Models
{
    public class Campaign
    {
        public int campaignId {get;set;}
        public string campaignTitle {get;set;} = string.Empty;
        public string campaignDescription{get;set;} = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal campaignValue{get;set;}
        public DateTime issuedDate{get;set;} = DateTime.Now;
        public DateTime startDate{get;set;}
        public int? creatorID{get;set;}
        public Creator? creator{get;set;}
    }
}