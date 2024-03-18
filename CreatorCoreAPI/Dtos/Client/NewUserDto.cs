using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatorCoreAPI.Dtos.Client
{
    public class NewUserDto
    {
        public string Username{get;set;} = string.Empty;
        public string Email{get;set;} = string.Empty;
        public string Token{get;set;} = string.Empty;
    }
}