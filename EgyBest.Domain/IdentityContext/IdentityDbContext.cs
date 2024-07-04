using EgyBest.Domain.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EgyBest.Domain.IdentityContext
{
    public class IdentityUserDbContext : IdentityDbContext<AppUser>
    {
        public IdentityUserDbContext(DbContextOptions<IdentityUserDbContext> options) : base(options)
        {
        }
    }
}
