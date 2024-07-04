using EgyBestFilm.Application.Dtos;

namespace EgyBestFilm.Application.Services.AccountService
{
    public interface IAccountService
    {
        public Task<UserDto> Login(LoginDto dto);
        public Task<UserDto> Register(RegisterDto dto);
       
        
       
    }
}
