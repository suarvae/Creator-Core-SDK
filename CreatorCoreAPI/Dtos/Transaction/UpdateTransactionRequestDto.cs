using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatorCoreAPI.Dtos.Transaction
{
    public class UpdateTransactionRequestDto
    {
          public string itemName {get;set;} = string.Empty;

        public decimal transactionValue{get;set;}
    }
}