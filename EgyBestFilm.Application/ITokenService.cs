using EgyBest.Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace EgyBestFilm.Application
{
    public interface ITokenService
    {
        Task<string> GenerateToken(AppUser appUser,UserManager<AppUser> userManager);
    }
}
