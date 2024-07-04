using EgyBest.Domain.Models.Identity;
using EgyBestFilm.Application.Dtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyBestFilm.Application.Services.SuperAdminService
{
    public class SuperAdminService : ISuperAdminService
    {
        private readonly UserManager<AppUser> _userManager;

        public SuperAdminService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<bool> AddAdmin(RegisterDto dto)
        {
            AppUser user = new AppUser()
            {
                Email = dto.Email,
                DateOfBirth = dto.DateOfBirh,
                Nationality = dto.Nathionality,

            };
            var result = await _userManager.CreateAsync(user,dto.Password);
            await _userManager.AddToRoleAsync(user, "Admin");
            if(!result.Succeeded) 
                return false;
            return true;
        }

        public async Task<bool> DeleteAdmin(string id)
        {
            var user =await _userManager.FindByIdAsync(id);
            if(user == null) return false;
            await _userManager.DeleteAsync(user);
            return true;    
             
        }
    }
}
