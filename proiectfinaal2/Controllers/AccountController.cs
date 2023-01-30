using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using proiectfinaal2.Entities.DTOs;
using proiectfinaal2.Models.Constants;
using proiectfinaal2.Models.entities;
using proiectfinaal2.Services.UserServices;
using System.Threading.Tasks;

namespace proiectfinaal2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserServices _userService;
        public AccountController(UserManager<User> userManager, IUserServices userService)
        {
            _userManager = userManager;
            _userService = userService;
        }


        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO dto)
        {
            var exists = await _userManager.FindByEmailAsync(dto.Email);

            if (exists != null)
            {
                return BadRequest("User already has an account!");
            }
            var result = await _userService.RegisterUserAsync(dto);
            if(result)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO dto)
        {
            var token = await _userService.LoginUser(dto);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(new { token });
        }

        
    }
}
