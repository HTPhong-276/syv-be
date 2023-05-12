using Core.Model.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EFCore.Seeding
{
    public class IdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                for(int i = 0; i < 5; i++)
                {
                    var user = new AppUser
                    {
                        UserName = "user" + i,
                        Email = "user" + i + "@gmail.com",
                        Gender = (i % 2 == 0 ? "male" : "female"),
                        Role = (i % 2 == 0 ? Role.ADMIN : Role.USER),
                        DoB = DateTime.Now.ToString(),
                    };

                    await userManager.CreateAsync(user, "Abc123!");
                }
            }
        }
    }
}
