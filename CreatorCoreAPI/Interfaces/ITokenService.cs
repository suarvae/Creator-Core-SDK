using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreatorCoreAPI.Models;

namespace CreatorCoreAPI.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}