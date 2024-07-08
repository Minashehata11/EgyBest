using EgyBest.Domain.IdentityContext.SeedingData;
using EgyBest.Domain.Models.Identity;
using EgyBest.Presentaion.Extention;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace EgyBest.Presentaion
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddAplicationServices(builder.Configuration);


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            #region SeedData
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var LoggerFactory = services.GetRequiredService<ILoggerFactory>();
            try
            {
                var userManger = services.GetRequiredService<UserManager<AppUser>>();
                var roleManger = services.GetRequiredService<RoleManager<IdentityRole>>();
                await SeedRoles.AddRoles(roleManger);
                await SeedAdmin.CreateUser(userManger);
            }
            catch (Exception ex)
            {
                var logger = LoggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "An Error Occurred IN program in Seeding DATA");
            }
            #endregion

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            var locOptions = services.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
