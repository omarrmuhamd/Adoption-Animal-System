using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Project.Core.Entities.Identity;
using Project.Repository.Identity;
using Project.Services;
using System.Security.Claims;
using System.Text;

namespace GraduationProject.Extentions
{
    public static class IdentityExtention
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection Services , IConfiguration configuration)
        {
            Services.AddScoped<ITokenService, TokenService>();
            Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>();
            Services.AddApplicationServices();
            Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                
                
                Options =>
                {

                    Options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = configuration["JWT:ValidIssuer"],
                        ValidateAudience = true,
                        ValidAudience = configuration["JWT:ValidAudience"],
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"])),




                        RoleClaimType = ClaimTypes.Role,       
                        NameClaimType = ClaimTypes.NameIdentifier

                    };
                }
                
                
                );

            return Services;
        }
    }
}
