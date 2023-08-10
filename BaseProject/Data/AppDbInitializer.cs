using Microsoft.AspNetCore.Identity;
using BaseProject.Models;
using BaseProject.Data.Static;
using System;

namespace BaseProject.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<BaseDbContext>();
                context.Database.EnsureCreated();

                if (!context.Material_Models.Any())
                {
                    context.Material_Models.AddRange(new List<Material_Model>()
                    {
                        new Material_Model
                    {
                        Name = "플라스틱",
                        Quantity = 30,
                        Price = 1000,
                        Status = Data.Enums.StatusCategory.Activation,
                        ImgUrl = "/" + "Material" + "/" + 1 + "/" + "플라스틱.jpg",
                        CreateTime = DateTime.Now
                    },
                    new Material_Model
                    {
                        Name = "가죽",
                        Quantity = 5000,
                        Price = 2000,
                        Status = Data.Enums.StatusCategory.Activation,
                        ImgUrl = "/" + "Material" + "/" + 2 + "/" + "가죽.jpg",
                   CreateTime = DateTime.Now
                    },
                    new Material_Model
                    {
                        Name = "고무",
                        Quantity = 900,
                        Price = 10,
                        Status = Data.Enums.StatusCategory.Activation,
                        ImgUrl = "/" + "Material" + "/" + 3 + "/" + "고무.jpg",
                        CreateTime = DateTime.Now
                    },
                });
                    context.SaveChanges();                    
                }
                if (!context.Product_Models.Any())
                {
                    context.Product_Models.AddRange(new List<Product_Model>()
                    {
                        new Product_Model
                    {
                        Name = "Car",
                        Price = 1000,
                        Status = Data.Enums.StatusCategory.Activation,
                        ImgUrl = "/" + "Product" + "/" + 1 + "/" + "Car.jpg",
                        CreateTime = DateTime.Now
                    },
                    new Product_Model
                    {
                        Name = "Boomerang",
                        Price = 10000,
                        Status = Data.Enums.StatusCategory.Activation,
                        ImgUrl = "/" + "Product" + "/" + 2 + "/" + "Boomerang.png",
                        CreateTime = DateTime.Now
                    },
                    new Product_Model
                    {
                        Name = "NinjaStart",
                        Price = 20000,
                        Status = Data.Enums.StatusCategory.Activation,
                        ImgUrl = "/" + "Product" + "/" + 3 + "/" + "NinjaStart.png",
                        CreateTime = DateTime.Now
                    },
                });
                    
                    context.SaveChanges();
                }
                if (!context.Product_Use_Metrail_Models.Any())
                {
                    context.Product_Use_Metrail_Models.AddRange(new List<Product_Use_Metrail_Model>()
                    {
                        new Product_Use_Metrail_Model
                    {
                        ProductId = 1,
                        MetrailId = 1,
                        Quantity = 10,
                    },
                    new Product_Use_Metrail_Model
                    {
                        ProductId = 1,
                        MetrailId = 2,
                        Quantity = 20,
                    },
                    new Product_Use_Metrail_Model
                    {
                        ProductId = 1,
                        MetrailId = 3,
                        Quantity = 30,
                    },
                    new Product_Use_Metrail_Model
                    {
                        ProductId = 2,
                        MetrailId = 1,
                        Quantity = 100,
                    },
                    new Product_Use_Metrail_Model
                    {
                        ProductId = 2,
                        MetrailId = 2,
                        Quantity = 200,
                    },
                    new Product_Use_Metrail_Model
                    {
                        ProductId = 2,
                        MetrailId = 3,
                        Quantity = 300,
                    },
                    new Product_Use_Metrail_Model
                    {
                        ProductId = 3,
                        MetrailId = 1,
                        Quantity = 1000,
                    },
                    new Product_Use_Metrail_Model
                    {
                        ProductId = 3,
                        MetrailId = 2,
                        Quantity = 2000,
                    },
                    new Product_Use_Metrail_Model
                    {
                        ProductId = 3,
                        MetrailId = 3,
                        Quantity = 3000,
                    },
                });

                    context.SaveChanges();
                }
                if (!context.Inventory_Models.Any())
                {
                    context.Inventory_Models.AddRange(new List<Inventory_Model>()
                    {
                        new Inventory_Model
                    {
                        ProductId = 1,
                        Count = 100,
                        CreateTime = new DateTime(2020, 5, 5)
                    },
                        new Inventory_Model
                    {
                        ProductId = 1,
                        Count = 100,
                        CreateTime = new DateTime(2020, 5, 5)
                    },
                        new Inventory_Model
                    {
                        ProductId = 3,
                        Count = 300,
                        CreateTime = new DateTime(2020, 5, 8)
                    },
                        new Inventory_Model
                    {
                        ProductId = 2,
                        Count = 100,
                        CreateTime = new DateTime(2020, 10, 20)
                    },
                        new Inventory_Model
                    {
                        ProductId = 2,
                        Count = 100,
                        CreateTime = new DateTime(2021, 1, 1)
                    },

                });
                    context.SaveChanges();
                }
                if (!context.Order_Models.Any())
                {
                    context.Order_Models.AddRange(new List<Order_Model>()
                    {
                        new Order_Model
                    {
                        Customer = "일지원",
                        Status = Data.Enums.StatusCategory.Deactivation,
                        RegisterDate = new DateTime(2020, 5, 5),
                        EndDate = new DateTime(2020, 5, 10),
                    },new Order_Model
                    {
                        Customer = "이지원",
                        Status = Data.Enums.StatusCategory.Working,
                        RegisterDate = new DateTime(2020, 10, 20),
                        EndDate = new DateTime(2020, 11, 30),
                    },
                        new Order_Model
                    {
                        Customer = "삼지원",
                        Status = Data.Enums.StatusCategory.Activation,
                        RegisterDate = new DateTime(2025, 4, 5),
                        EndDate = new DateTime(2026, 1, 10),
                    },

                });
                    context.SaveChanges();
                }
                if (!context.Order_Products.Any())
                {
                    context.Order_Products.AddRange(new List<Order_Product_Model>()
                    {
                        new Order_Product_Model
                    {
                        OrderId = 1,
                        ProductId = 1,
                        Quantity = 300,
                    },
                        new Order_Product_Model
                    {
                        OrderId = 1,
                        ProductId = 2,
                        Quantity = 100,
                    },
                        new Order_Product_Model
                    {
                        OrderId = 1,
                        ProductId = 3,
                        Quantity = 100,
                    },
                        new Order_Product_Model
                    {
                        OrderId = 2,
                        ProductId = 1,
                        Quantity = 300,
                    },                        
                        new Order_Product_Model
                    {
                        OrderId = 2,
                        ProductId = 3,
                        Quantity = 10,
                    },
                        new Order_Product_Model
                    {
                        OrderId = 3,
                        ProductId = 1,
                        Quantity = 300,
                    },
                    });
                    context.SaveChanges();
                }
            }

        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            await Console.Out.WriteLineAsync("Seed");
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.Manager))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Manager));
                if (!await roleManager.RoleExistsAsync(UserRoles.Member))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Member));
                if (!await roleManager.RoleExistsAsync(UserRoles.NoRole))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.NoRole));
            }
                ////Users
                //var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                //string adminUserEmail = "admin@web.com";

                //var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                //if (adminUser == null)
                //{
                //    var newAdminUser = new IdentityUser()
                //    {
                //        UserName = "admin-user",
                //        Email = adminUserEmail,
                //        EmailConfirmed = true
                //    };
                //    await userManager.CreateAsync(newAdminUser, "Dkagh1234!?");
                //    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                //}


                //    string appUserEmail = "user@web.com";

                //    var appUser = await userManager.FindByEmailAsync(appUserEmail);
                //    if (appUser == null)
                //    {
                //        var newAppUser = new IdentityUser()
                //        {
                //            UserName = "app-user",
                //            Email = appUserEmail,
                //            EmailConfirmed = true
                //        };
                //        await userManager.CreateAsync(newAppUser, "Dkagh1234!");
                //        await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                //    }
                //}
            }
    }
}
