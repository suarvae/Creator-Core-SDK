using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreatorCoreAPI.Data;
using CreatorCoreAPI.Dtos.Creator;
using CreatorCoreAPI.Helpers;
using CreatorCoreAPI.Models;
using CreatorCoreAPI.Repository;

namespace CreatorCoreAPI.Interfaces
{
    public interface ICreatorRepository
    {
       Task<List<Creator>> GetAllAsync(QueryObject query);

      Task<Creator?> GetByIdAsync(int id);

      Task<Creator> CreateAsync(Creator creatorModel);

      Task<Creator?> UpdateAsync(int id, UpdateCreatorRequestDto creatorRequestDto);

      Task<Creator?> DeleteAsync(int id);

      Task<bool> CreatorExists(int id);
    }
}