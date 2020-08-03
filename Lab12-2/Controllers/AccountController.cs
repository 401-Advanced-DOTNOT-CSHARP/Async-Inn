using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab12_2.Models;
using Lab12_2.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lab12_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signinManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signinManager = signInManager;
        }
        // api/account/register
        [HttpPost,Route("register")]
        public async Task<IActionResult> Register(RegisterDTO register)
        {
            ApplicationUser user = new ApplicationUser()
            {
                Email = register.Email,
                UserName = register.Email,
                FirstName = register.FirstName,
                LastName = register.LastName
            };

            var result = await _userManager.CreateAsync(user, register.Password);

            if (result.Succeeded)
            {
               await _signinManager.SignInAsync(user, false);
                return Ok();
            }
            return BadRequest("Invalid Registration");
        }

        [HttpPost, Route("login")]
        
        public async Task<IActionResult> Login(LoginDTO login)
        {
          var result = await _signinManager.PasswordSignInAsync(login.Email, login.Password, false, false);
            if (result.Succeeded)
            {
                return Ok("Logged In");
            }

            return BadRequest("invalid attempt");
        }
    }
}
