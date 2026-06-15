using Microsoft.AspNetCore.Identity;
using Project.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Identity
{
    public class AppIdentityDbContextSeeder
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var User = new AppUser()
                {
                    DisplayName = "omar mohamed",
                    Email = "omar.mohamed.project@gmail.com",
                    UserName="omarmuhamdd",
                    PhoneNumber = "01011201500",

                };
                await userManager.CreateAsync(User, "Pa$$w0rd");

            }
      
        }
    }
}
