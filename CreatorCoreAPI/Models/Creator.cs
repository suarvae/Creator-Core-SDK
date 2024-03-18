using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreatorCoreAPI.Models
{
    public class Creator
    {
        public int creatorID {get; set;}
        public string creatorName{get;set;} = string.Empty;
        
        public float creatorRevenueSplit {get; set;}
        public decimal creatorRevenue{get;set;} 
        public List<Campaign> campaigns {get;set;} = new();
    }
}