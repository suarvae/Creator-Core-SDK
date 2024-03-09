using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatorCoreAPI.Dtos.Transaction
{
    public class TransactionDto
    {
        public int transactionID {get;set;}
        public string itemName {get;set;} = string.Empty;

        public decimal transactionValue{get;set;}
        public DateTime transactionDate{get;set;} = DateTime.Now;

        public int? creatorID{get;set;}
    }
}