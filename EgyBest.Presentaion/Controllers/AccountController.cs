using EgyBest.Domain.Models.Identity;
using EgyBestFilm.Application.Dtos;
using EgyBestFilm.Application.ErrorHandle;
using EgyBestFilm.Application.Services.AccountService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EgyBest.Presentaion.Controllers
{

    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(IAccountService accountService,UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            _accountService = accountService;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto dto)
        {
            var result = await _accountService.Register(dto);
            if (result == null)
                return BadRequest(new ErrorApiResponse(400, "Bad Request"));
            return Ok(result);
        }
        [HttpPost("Login")]

        public async Task<ActionResult<UserDto>> Login(LoginDto dto)
        {
            var ressult = await _accountService.Login(dto);
            if (ressult == null)
                return Unauthorized(new ErrorApiResponse(401));
            return Ok(ressult);
        }
        [HttpPut]
        [Authorize]
        public async Task<ActionResult> ChangePass(PasswordChangeDto dto)
        {
            var user = await GetCurrentUser();
              var result = await _signInManager.CheckPasswordSignInAsync(user, dto.OldPassword, false);
            if (!result.Succeeded)
                return BadRequest(new ErrorApiResponse(400,"PassWord Not Valid"));
             await _userManager.ChangePasswordAsync(user, dto.OldPassword , dto.NewPassord);
            return Ok();
        }


        [HttpGet("Profile")]
        [Authorize]
        public async Task<ActionResult<UserProfileDto>> GetProfile()
        {
            var user = await GetCurrentUser();
            UserProfileDto dto = new UserProfileDto()
            {
                Email = user.Email,
                Name = user.UserName,
                Nationality = user.Nationality,

            };
            return dto;
        }
        [Authorize]
        [HttpPut("UpdateProfile")]
        public async Task<ActionResult> UpdateProfile([FromForm]UpdateProfileDto dto)
        {
            var user= await GetCurrentUser();
            user.Email = dto.Email;
            user.PhoneNumber=dto.PhoneNumber;
            user.DateOfBirth=dto.DateOfBirth;
          await  _userManager.UpdateAsync(user);
            return Ok();
        }
        [Authorize]
        private async Task<AppUser> GetCurrentUser()
       => await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));
    }
    
}