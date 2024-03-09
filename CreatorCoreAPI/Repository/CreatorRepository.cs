using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CreatorCoreAPI.Data;
using CreatorCoreAPI.Dtos.Creator;
using CreatorCoreAPI.Helpers;
using CreatorCoreAPI.Interfaces;
using CreatorCoreAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace CreatorCoreAPI.Repository
{
    public class CreatorRepository : ICreatorRepository
    {    
        private readonly ApplicationDBContext _context;
        
        public CreatorRepository(ApplicationDBContext context) => _context = context; 


        public async Task<Creator> CreateAsync(Creator creatorModel)
        {
            await _context.Creators.AddAsync(creatorModel);
            await _context.SaveChangesAsync();
            return creatorModel;
        }

        public Task<bool> CreatorExists(int id)
        {
            return _context.Creators.AnyAsync(t => t.creatorID == id);
        }

        public async Task<Creator?> DeleteAsync(int id)
        {
            var creator = await _context.Creators.FirstOrDefaultAsync(c => c.creatorID == id);

            if(creator == null)
                return null;
            else
            {
                _context.Creators.Remove(creator);
                await _context.SaveChangesAsync();
                return creator;
            }
        }

        public async Task<List<Creator>> GetAllAsync(QueryObject query)
        {
            var creator = _context.Creators.Include(t => t.transactions).AsQueryable();

            if(!string.IsNullOrWhiteSpace(query.CreatorName))
            {
                creator = creator.Where(c => c.creatorName.Contains(query.CreatorName));
            }

            if(query.RevenueSplit > 0)
            {
                creator = creator.Where(c => c.creatorRevenueSplit >= query.RevenueSplit);
            }

            if(!string.IsNullOrWhiteSpace(query.SortBy)){
                
                if(query.SortBy.Equals("CreatorName", StringComparison.OrdinalIgnoreCase))
                {
                    creator = query.IsDescending ? creator.OrderByDescending(c => c.creatorName) : creator.OrderBy(c => c.creatorName);
                }
                else if (query.SortBy.Equals("RevenueSplit", StringComparison.OrdinalIgnoreCase))
                {
                    creator = query.IsDescending ? creator.OrderByDescending(c => c.creatorRevenueSplit) : creator.OrderBy(c => c.creatorRevenueSplit);
                }
            }
            return await creator.ToListAsync();
        }

        public async Task<Creator?> GetByIdAsync(int id)
        {
            return await _context.Creators.Include(t => t.transactions).FirstOrDefaultAsync(i => i.creatorID == id);
        }

        public async Task<Creator?> UpdateAsync(int id, UpdateCreatorRequestDto creatorRequestDto)
        {
            var creator = await _context.Creators.FirstOrDefaultAsync(c => c.creatorID == id);

            if(creator == null)
                return null;
            else
            {
                creator.creatorName = creatorRequestDto.creatorName;
                creator.creatorRevenue = creatorRequestDto.creatorRevenue;
                creator.creatorRevenueSplit = creatorRequestDto.creatorRevenueSplit;
                creator.lifeTimeEarnings = creatorRequestDto.lifeTimeEarnings;
                
                await _context.SaveChangesAsync();
                
                return creator;
            }
        }
    }
}