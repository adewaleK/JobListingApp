using JobListingApp.Data.Static;
using JobListingApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListingApp.Data
{
    public class DbInitializer
    {
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();

                string adminUserEmail = "admin@joblist.com";
                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);

                if (adminUser == null)
                {
                    var newAdminUser = new User
                    {
                        FirstName = "Kamil",
                        LastName = "Adewale",
                        Gender = "Male",
                        UserName = "admin-user",
                        Address = "12, Asajoh Way, Sangotedo, Eti-osa, Lagos",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };

                    await userManager.CreateAsync(newAdminUser, "Coding@123?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                //
                string appUserEmail = "user@joblist.com";
                var appUser = await userManager.FindByEmailAsync(appUserEmail);

                if (appUser == null)
                {
                    var newAppUser = new User
                    {
                        FirstName = "Taofeek",
                        LastName = "Jimoh",
                        Gender = "FeMale",
                        UserName = "app-user",
                        Address = "12, Asajoh Way, Sangotedo, Eti-osa, Lagos",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };

                    await userManager.CreateAsync(newAppUser, "Coding@123?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }


        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DataContext>();
                context.Database.EnsureCreated();



            }

        }
    }
}
