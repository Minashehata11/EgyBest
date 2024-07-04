using Microsoft.AspNetCore.Identity;

namespace EgyBest.Domain.Models.Identity
{
    public class AppUser:IdentityUser
    {
        public string Nationality { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
