using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatorCoreAPI.Helpers
{
    public class QueryObject
    {
        public string? CreatorName{get;set;} = null;
        
        public string? SortBy {get; set;} = null;
        public bool IsDescending {get; set;} = false;
        
        public float? RevenueSplit {get; set;} = null;

        public int PageNumber{get; set;} = 1;

        public int PageSize{get; set;} = 10;
    }
}