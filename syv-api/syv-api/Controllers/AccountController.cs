using Core.Interfaces.Authentication;
using Core.Model.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using syv_api.Dtos;
using syv_api.Dtos.Authentication;

namespace syv_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly ITokenService tokenService;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenService = tokenService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await userManager.FindByNameAsync(loginDto.Username);

            if(user == null) { return Unauthorized("Username not found!"); }

            var result = await signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded) { return Unauthorized("Login fail!"); }

            return new UserDto
            {
                Email = user.Email,
                Username = user.UserName,
                Token = tokenService.CreateToken(user),
                Gender = user.Gender,
                DoB = user.DoB
            };
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            var user = new AppUser
            {
                UserName = registerDto.Username,
                Email = registerDto.Email,
                Gender = "None",
                DoB = DateTime.Now.ToString(),
            };

            var result = await userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded) { return BadRequest(result); }

            return new UserDto 
            { 
                Email = user.Email, 
                Username = user.UserName, 
                Token = tokenService.CreateToken(user),
                Gender = user.Gender,
                DoB = user.DoB
            };
        }
    }
}
