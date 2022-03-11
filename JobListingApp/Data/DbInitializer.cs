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

                if (!context.Jobs.Any())
                {
                    context.Jobs.AddRange(new List<Job>() {
                        new Job()
                    {
                        Id= "22f29i42-e6d0-4a8f-1ec1-2d0074c08e0b",
                        JobTitle = "Senior Backend Developer",
                        CompanyName = "AutoMata",
                        Location = "Remote",
                        MinimumSalary = 300000,
                        MaximumSalary = 400000,
                        Duration = "Full Time",
                        CategoryId = "45f29a42-e6b0-4a8f-8ec1-2d0074c08e0b",
                    },
                    new Job()
                    {
                        Id= "89f29n42-k6d0-2a8f-1lc1-2d0074c08e0b",
                        JobTitle = "UI/UX Designer",
                        CompanyName = "AutoMata",
                        Location = "Remote",
                        MinimumSalary = 200000,
                        MaximumSalary = 300000,
                        Duration = "Part Time",
                        CategoryId = "45f29a42-e6b0-4a8f-8ec1-2d0074c08e0b",
                    },
                    new Job()
                    {
                        Id= "07f89i42-e7d0-4e8f-1pk1-7d0032c08c0b",
                        JobTitle = "Engineering Manager",
                        CompanyName = "Decagon",
                        Location = "Lagos",
                        MinimumSalary = 300000,
                        MaximumSalary = 400000,
                        Duration = "Full Time",
                        CategoryId = "45f29a42-e6b0-4a8f-8ec1-2d0074c08e0b",
                    },
                    new Job()
                    {
                        Id= "44f99i42-e6d0-0a8m-1ec1-5d0034c08n0b",
                        JobTitle = "Frontend Developer",
                        CompanyName = "Ustacky",
                        Location = "Lagos",
                        MinimumSalary = 350000,
                        MaximumSalary = 400000,
                        Duration = "Full Time",
                        CategoryId = "45f29a42-e6b0-4a8f-8ec1-2d0074c08e0b",
                    },
                    new Job()
                    {
                        Id= "11f68i42-e6d0-4a8f-1gg1-9d0074c08e0b",
                        JobTitle = "Backend Developer",
                        CompanyName = "Ustacky",
                        Location = "Remote",
                        MinimumSalary = 350000,
                        MaximumSalary = 400000,
                        Duration = "Part Time",
                        CategoryId = "45f29a42-e6b0-4a8f-8ec1-2d0074c08e0b",
                    },
                    new Job()
                    {
                        Id= "38f27h42-g3d0-9a8f-1mc1-7d0074c08x0b",
                        JobTitle = "Lecturer II",
                        CompanyName = "UniLag",
                        Location = "Ilorin",
                        MinimumSalary = 350000,
                        MaximumSalary = 400000,
                        Duration = "Part Time",
                        CategoryId = "38327868-cfa8-4f2f-b944-cb341ce17417",
                    },
                    new Job()
                    {
                        Id= "qtf50i32-c6d0-4a8t-7ec1-4d0004c05e0b",
                        JobTitle = "Nurse",
                        CompanyName = "Defat Clinic",
                        Location = "Lagos",
                        MinimumSalary = 350000,
                        MaximumSalary = 400000,
                        Duration = "Full Time",
                        CategoryId = "95f29a42-p6b0-4a8f-8ec1-2d0074c08e0b",
                    }

                });

                    context.SaveChanges();
                }

                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(new List<Category>()
                    {
                            new Category()
                        {
                            Id = "45f29a42-e6b0-4a8f-8ec1-2d0074c08e0b",
                            CategoryName = "Software Engineering"
                        },
                        new Category()
                        {
                            Id = "38327868-cfa8-4f2f-b944-cb341ce17417",
                            CategoryName = "Education"
                        },
                        new Category()
                        {
                            Id = "15242969-2d98-4883-8311-918d2b0e3b34",
                            CategoryName = "Real Estate"
                        },
                        new Category()
                        {
                            Id = "95f29a42-p6b0-4a8f-8ec1-2d0074c08e0b",
                            CategoryName = "Healthcare"
                        }
                    });

                    context.SaveChanges();

                }


                if (!context.UsersJobs.Any())
                {
                    context.UsersJobs.AddRange(new List<UserJob>() {
                        new UserJob()
                        {
                            UserId = "03cf7a83-148a-4660-a714-fd9238531885",
                            JobId = "44f99i42-e6d0-0a8m-1ec1-5d0034c08n0b"
                        },
                         new UserJob()
                        {
                            UserId = "03cf7a83-148a-4660-a714-fd9238531885",
                            JobId = "07f89i42-e7d0-4e8f-1pk1-7d0032c08c0b"
                        }

                    });

                    context.SaveChanges();

                }

            }

        }
    }
}
