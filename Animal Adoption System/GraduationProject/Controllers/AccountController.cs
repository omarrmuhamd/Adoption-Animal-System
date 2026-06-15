using GraduationProject.DTOS;
using GraduationProject.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Core.Entities.Identity;
using Project.Repository.Data;
using Project.Services;

namespace GraduationProject.Controllers
{
  
    public class AccountController : BaseController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ProjectContext _context;

        public AccountController(UserManager<AppUser> userManager , SignInManager<AppUser> signInManager , ITokenService tokenService , RoleManager<IdentityRole> roleManager , ProjectContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _roleManager = roleManager;
            _context = context;
        }




        //adminRole

        [HttpPost("CreateAdminRole")]
        public async Task<IActionResult> CreateAdminRole()
        {
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            return Ok(new ApiResponse(200, "Admin role created successfully"));
        }

        [HttpPost("MakeAdmin")]
        public async Task<IActionResult> MakeAdmin(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
                return NotFound(new ApiResponse(404, "User not found"));

            await _userManager.AddToRoleAsync(user, "Admin");

            return Ok(new ApiResponse(200, "User is now Admin"));
        }

        //Register
        [HttpPost("Register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDto model)
        {
            var user = new AppUser()
            {
                DisplayName = model.DisplayName,
                Email = model.Email,
                UserName = model.Email.Split("@")[0],
                PhoneNumber = model.PhoneNumber
            };

          var test =  await _userManager.CreateAsync(user,model.Password);
            if (!test.Succeeded)
            {
                return BadRequest(new ApiResponse(400));
            }

            else
            {
                var RealUser = new UserDTO()
                {
                    DisplayName = user.DisplayName,
                    Email = user.Email,
                    Token = await _tokenService.CreateTokenAsync(user, _userManager)
                };
                return Ok(RealUser);
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return Unauthorized(new ApiResponse(401));
            }
            else
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
                if (!result.Succeeded) return Unauthorized(new ApiResponse(401));
                else return Ok(new UserDTO()
                {
                    DisplayName = user.DisplayName,
                    Email = user.Email,
                    Token = await _tokenService.CreateTokenAsync(user, _userManager)
                });
            }

        }




    }
}
