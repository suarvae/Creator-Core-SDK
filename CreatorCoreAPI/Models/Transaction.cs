using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using System.Threading.Tasks;

namespace CreatorCoreAPI.Models
{
    public class Transaction
    {
        public int transactionID {get;set;}
        public string itemName {get;set;} = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal transactionValue{get;set;}
        public DateTime transactionDate{get;set;} = DateTime.Now;

        public int? creatorID{get;set;}
        public Creator? creator{get;set;}
    }
}