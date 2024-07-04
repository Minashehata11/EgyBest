using EgyBest.Domain.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using EgyBestFilm.Application.Dtos;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace EgyBestFilm.Application.Services.AccountService
{
    public class AccountService:IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _token;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(UserManager<AppUser> userManager,ITokenService token,SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _token = token;
            _signInManager = signInManager;
         
        }

       

        [ApiExplorerSettings(IgnoreApi =true)]
       
      

        public async Task<UserDto> Login(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
                return null;
            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
            if (!result.Succeeded)
                return null;
            var UserRole = await _userManager.GetRolesAsync(user);

            return new UserDto
            {
                Email = user.Email,
                Name = user.UserName,
                Roles = UserRole,
                Token = await _token.GenerateToken(user, _userManager),
            };
        }

        public async Task<UserDto> Register(RegisterDto dto)
        {
            AppUser user = new AppUser()
            {
                Email = dto.Email,
                DateOfBirth = dto.DateOfBirh,
                Nationality = dto.Nathionality,
                UserName=dto.Email.Split('@')[0],
            };
            var result=await _userManager.CreateAsync(user,dto.Password);
            if (!result.Succeeded)
                return null;
            var UserRole=await _userManager.GetRolesAsync(user);
            return new UserDto
            {
                Email = user.Email,
                Name = user.UserName,
                Roles = UserRole,
                Token = await _token.GenerateToken(user, _userManager),
            };

            
        }
       
           

    }
}
