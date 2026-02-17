using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ITSupport.Models;
using ITSupport.Services;

namespace ITSupport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPasswordHashService _passwordHashService;

        public AccountController(UserManager<ApplicationUser> userManager, IPasswordHashService passwordHashService)
        {
            _userManager = userManager;
            _passwordHashService = passwordHashService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                return Unauthorized();
            }

            bool isPasswordValid = _passwordHashService.VerifyPassword(model.Password, user.PasswordHash);
            if (!isPasswordValid)
            {
                return Unauthorized();
            }

            // Authentication logic goes here
            return Ok();
        }
    }
}