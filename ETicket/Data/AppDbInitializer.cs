using ETicket.Data.Static;
using ETicket.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;

namespace ETicket.Data
{
    public class AppDbInitializer
    {

            public static async Task SeedUserAndRolesAsync(IApplicationBuilder applicationBuilder)
            {
                using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
                {
                   var roleManager=serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
                var UserManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var adminUser=await UserManager.FindByEmailAsync("admin@etickets.com");
                if(adminUser==null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = "admin@etickets.com",
                        EmailConfirmed = true
                    };
                    await UserManager.CreateAsync(newAdminUser,"Coding@1234?");
                    await UserManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                var appUser = await UserManager.FindByEmailAsync("user@etickets.com");
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = "user@etickets.com",
                        EmailConfirmed = true
                    };
                    await UserManager.CreateAsync(newAppUser, "Coding@1234?");
                    await UserManager.AddToRoleAsync(newAppUser, UserRoles.Admin);
                }


            }
        }
    }
}
