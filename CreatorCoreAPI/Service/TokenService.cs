using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CreatorCoreAPI.Interfaces;
using CreatorCoreAPI.Models;
using Microsoft.IdentityModel.Tokens;

namespace CreatorCoreAPI.Service
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _securityKey;
        public TokenService(IConfiguration config)
        {
            _config = config;
            _securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SigningKey"]));
            //Json reads
        }
        public string CreateToken(AppUser user)
        {
            var claim = new List<Claim>{
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, user.UserName)
            };

            var credentials = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha512Signature);
            var tokenDesc =  new SecurityTokenDescriptor
            {

                Subject = new ClaimsIdentity(claim),
                Expires = DateTime.Now.AddDays(3),
                SigningCredentials = credentials,
                Issuer = _config["JWT:Issuer"],
                Audience = _config["JWT:Audience"]
            };

            var handler = new JwtSecurityTokenHandler();

            var token = handler.CreateToken(tokenDesc);

            return handler.WriteToken(token);
        }
    }
}