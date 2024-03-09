using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreatorCoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CreatorCoreAPI.Data
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        :base(dbContextOptions)
        {
            
        }

        public DbSet<Creator> Creators{get;set;}
        public DbSet<Transaction> Transactions{get;set;}
        
    }
}