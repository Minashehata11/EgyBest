using EgyBest.Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace EgyBest.Domain.IdentityContext.SeedingData
{
    public static class SeedAdmin
    {
        public async static Task CreateUser(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                AppUser user = new AppUser()
                {
                    Email = "Mina@Gmail.com",
                    UserName = "Mayno",
                    PhoneNumber = "01225666903",
                    DateOfBirth= new DateTime(2002,05,14),
                    Nationality="Egyptian"
                };
                await userManager.CreateAsync(user, "P@ssW0rd");
                await userManager.AddToRoleAsync(user, Roles.SuperAdmin);
            }
        }
    }
}
