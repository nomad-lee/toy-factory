using Microsoft.AspNetCore.Identity;
using BaseProject.Models;
using BaseProject.Data.Static;
using System;
using Microsoft.EntityFrameworkCore;

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
                        Quantity = 0,
                        Price = 1000,
                        Status = Data.Enums.Defult_StatusCategory.가능,
                        ImgUrl = "/" + "Material" + "/" + 1 + "/" + "플라스틱.jpg",
                        CreateTime = DateTime.Today
                    },
                    new Material_Model
                    {
                        Name = "가죽",
                        Quantity = 0,
                        Price = 2000,
                        Status = Data.Enums.Defult_StatusCategory.불가능,
                        ImgUrl = "/" + "Material" + "/" + 2 + "/" + "가죽.jpg",
                   CreateTime = DateTime.Today
                    },
                    new Material_Model
                    {
                        Name = "고무",
                        Quantity = 0,
                        Price = 10,
                        Status = Data.Enums.Defult_StatusCategory.가능,
                        ImgUrl = "/" + "Material" + "/" + 3 + "/" + "고무.jpg",
                        CreateTime = DateTime.Today
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
                        Status = Data.Enums.Defult_StatusCategory.가능,
                        ImgUrl = "/" + "Product" + "/" + 1 + "/" + "Car.jpg",
                        Quantity = 200,
                        CreateTime = DateTime.Today
                    },
                    new Product_Model
                    {
                        Name = "Boomerang",
                        Price = 10000,
                        Status = Data.Enums.Defult_StatusCategory.불가능,
                        ImgUrl = "/" + "Product" + "/" + 2 + "/" + "Boomerang.png",
                        Quantity = 200,
                        CreateTime = DateTime.Today
                    },
                    new Product_Model
                    {
                        Name = "NinjaStar",
                        Price = 20000,
                        Status = Data.Enums.Defult_StatusCategory.가능,
                        ImgUrl = "/" + "Product" + "/" + 3 + "/" + "NinjaStar.png",
                        Quantity = 300,
                        CreateTime = DateTime.Today
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
                        Status = Data.Enums.Order_StatusCategory.작업중,
                        RegisterDate = new DateTime(2020, 5, 5),
                        Deadline = new DateTime(2020, 5, 10),
                    },new Order_Model
                    {
                        Customer = "이지원",
                        Status = Data.Enums.Order_StatusCategory.작업대기,
                        RegisterDate = new DateTime(2020, 10, 20),
                        Deadline = new DateTime(2020, 11, 30),
                    },
                        new Order_Model
                    {
                        Customer = "삼지원",
                        Status = Data.Enums.Order_StatusCategory.작업대기,
                        RegisterDate = new DateTime(2025, 4, 5),
                        Deadline = new DateTime(2026, 1, 10),
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
                if (!context.product_Create_Models.Any())
                {
                    var Products = context.Product_Models.ToList();
                    var Create_Modesls = context.product_Create_Models;
                    foreach(var product in Products)
                    {
                        var Create_Model = new Product_Create_Model
                        {
                            ProductId = product.Id,
                            CreateTime = DateTime.Now,
                            Count = 0,
                        };
                        Create_Modesls.Add(Create_Model);
                    }
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
                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Member));
                if (!await roleManager.RoleExistsAsync(UserRoles.InventoryManager))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.InventoryManager));
                if (!await roleManager.RoleExistsAsync(UserRoles.MaterialManager))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.MaterialManager));
                if (!await roleManager.RoleExistsAsync(UserRoles.ProductManager))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.ProductManager));
                if (!await roleManager.RoleExistsAsync(UserRoles.OrderManager))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.OrderManager));
                if (!await roleManager.RoleExistsAsync(UserRoles.NoRole))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.NoRole));
                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<UserIdentity>>();
                string adminUserEmail = "admin@web.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new UserIdentity()
                    {
                        Id = "admin",
                        UserName = "Admin",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        ImgUrl = "gg"
                    };
                    var result =  await userManager.CreateAsync(newAdminUser, "Dkagh1234!");
                    var result2 = await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                //string appUserEmail = "user@web.com";

                //var appUser = await userManager.FindByEmailAsync(appUserEmail);
                //if (appUser == null)
                //{
                //    var newAppUser = new IdentityUser()
                //    {
                //        UserName = "app-user",
                //        Email = appUserEmail,
                //        EmailConfirmed = true
                //    };
                //    await userManager.CreateAsync(newAppUser, "Dkagh1234!");
                //    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                //}
            }
        }
            
    }    
}
