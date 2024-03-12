using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreatorCoreAPI.Dtos.Client;
using CreatorCoreAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CreatorCoreAPI.Controllers
{
    public class AccountController: ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        public AccountController(UserManager<AppUser> usernamanager)
        {
            _userManager = usernamanager;
            
        }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        try{
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            else
            {
                var appUser = new AppUser{
                    UserName = registerDto.Username,
                    Email = registerDto.Email
                };

                var createdUser= await _userManager.CreateAsync(appUser, registerDto.Password);  

                if(createdUser.Succeeded)
                {
                    var roleRes = await _userManager.AddToRoleAsync(appUser, "User");

                    if(roleRes.Succeeded)
                        return Ok("USER CREATED");
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
    }
}