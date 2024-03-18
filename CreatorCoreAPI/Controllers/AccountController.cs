using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreatorCoreAPI.Dtos.Client;
using CreatorCoreAPI.Interfaces;
using CreatorCoreAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CreatorCoreAPI.Controllers
{
    public class AccountController: ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signinManager;
        public AccountController(UserManager<AppUser> usernamanager, ITokenService service, SignInManager<AppUser> signInManager)
        {
            _userManager = usernamanager;
            _tokenService = service;
            _signinManager = signInManager;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]RegisterDto registerDto)
    {
        try{
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            else
            {
                var appUser = new AppUser
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email
                };

                var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);  

                if(createdUser.Succeeded)
                {
                    var roleRes = await _userManager.AddToRoleAsync(appUser, "User");

                    if(roleRes.Succeeded)
                        return Ok
                        (
                            new NewUserDto
                            {
                                Username = appUser.UserName,
                                Email= appUser.Email,
                                Token = _tokenService.CreateToken(appUser)
                            }
                        );
                    else
                        return StatusCode(500, roleRes.Errors);
                } 
                else{
                    return StatusCode(500, createdUser.Errors);
                }    
            }
        }
         catch(Exception ex)
         {
            return StatusCode(500, ex);
         }
    }
   
   
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if(!ModelState.IsValid)
                return BadRequest("LOGIN INFO INVALID :" + ModelState);
            else{
                var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());
                
                if(user == null) return Unauthorized("Invalid Username");
                var passwordResult = await _signinManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
                if(!passwordResult.Succeeded)  return Unauthorized("Username not found and/or password incorrect");
                return Ok(
                    new NewUserDto{
                        Username = user.UserName,
                        Email = user.Email,
                        Token = _tokenService.CreateToken(user)
                    }
                
                );
            }

        }
    }
}