
using GraduationProject.Errors;
using GraduationProject.Extentions;
using GraduationProject.Helper;
using GraduationProject.MiddleWares;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Project.Core.Entities;
using Project.Core.Entities.Identity;
using Project.Core.Repositories;
using Project.Repository;
using Project.Repository.Data;
using Project.Repository.Identity;

namespace GraduationProject
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
           
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ProjectContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddDbContext<AppIdentityDbContext>(options => 
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
            });

            builder.Services.AddApplicationServices();
            builder.Services.AddIdentityService(builder.Configuration);



            var app = builder.Build();

            var Scope = app.Services.CreateScope();
            var Services = Scope.ServiceProvider;

            var LoggerFactory = Services.GetRequiredService<ILoggerFactory>();

            try
            {
                var dbContext = Services.GetRequiredService<ProjectContext>();
                await dbContext.Database.MigrateAsync();

                var IdentitydbContext = Services.GetRequiredService<AppIdentityDbContext>();
                await IdentitydbContext.Database.MigrateAsync();

                var userManger = Services.GetRequiredService<UserManager<AppUser>>();
                await AppIdentityDbContextSeeder.SeedUserAsync(userManger);

                await ProjectContextSeeder.SeedAsync(dbContext);


            }

            catch (Exception ex)
            {
                var Logger = LoggerFactory.CreateLogger<Program>();
                Logger.LogError(ex, "There Is a Problem Here");
            }

            // Configure the HTTP request pipeline.

                app.UseMiddleware<ExeptionMiddleWare>();

                //app.UseSwagger();
                //app.UseSwaggerUI();
                app.UseSwaggerMiddleWares();
            

            app.UseStatusCodePagesWithRedirects("/errors/{0}");
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
