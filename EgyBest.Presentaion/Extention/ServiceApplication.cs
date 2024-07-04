using EgyBest.Domain.Context;
using EgyBest.Domain.IdentityContext;
using EgyBest.Domain.Models.Identity;
using EgyBest.Infrastructure.Interfaces;
using EgyBest.Infrastructure.Repositories;
using EgyBestFilm.Application;
using EgyBestFilm.Application.ErrorHandle;
using EgyBestFilm.Application.Helper;
using EgyBestFilm.Application.Services.AccountService;
using EgyBestFilm.Application.Services.AdminService;
using EgyBestFilm.Application.Services.MovieService;
using EgyBestFilm.Application.Services.SuperAdminService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EgyBest.Presentaion.Extention
{
    public static class ServiceApplication
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection Services, IConfiguration configuration)
        {
            Services.AddControllers();
            Services.AddDbContext<MovieDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            Services.AddDbContext<IdentityUserDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("IdentityConnetion"));
            });
            Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<IdentityUserDbContext>();
            Services.AddScoped<IUnitOfWork, UnitOfWork>();
            Services.AddScoped<IMovieService, MovieService>();
            Services.AddScoped<ITokenService, TokenService>();
            Services.AddScoped<IAccountService, AccountService>();
            Services.AddScoped<IAdminService, AdminService>();
            Services.AddScoped<ISuperAdminService,SuperAdminService>();
            Services.AddAutoMapper(typeof(MappingProfile));
            Services.Configure<ApiBehaviorOptions>(option =>
            {
                option.InvalidModelStateResponseFactory = (actionContext) =>
                {
                    var errors = actionContext.ModelState.Where(p => p.Value.Errors.Count() > 0)
                                             .SelectMany(p => p.Value.Errors)
                                             .Select(e => e.ErrorMessage)
                                             .ToArray();
                    var validtionErrorResponse = new ErrorApiValidationResponse()
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(validtionErrorResponse);
                };
            }
            );

            Services.AddAuthentication(Option =>
            {
                Option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                Option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(Option =>
            {
                Option.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration["JWT:ValidIssuer"],
                    ValidateAudience = true,
                    ValidAudience = configuration["JWT:ValidAudience"],
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWt:Key"]))
                };

            });
            Services.AddAuthorization();
            Services.AddEndpointsApiExplorer();
            Services.AddSwaggerDocumentation();

            return Services;
        }
    }
}