using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CreatorCoreAPI.Data;
using CreatorCoreAPI.Dtos.Creator;
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

        public async Task<List<Creator>> GetAllAsync()
        {
          return await _context.Creators.ToListAsync();
        }

        public async Task<Creator?> GetByIdAsync(int id)
        {
            return await _context.Creators.FindAsync(id);
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