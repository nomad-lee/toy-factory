using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BaseProject.Models;

namespace BaseProject.Data
{
    public class BaseDbContext : IdentityDbContext<IdentityUser>
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> option) : base(option)
        {
        }

        // 테스트용
        public DbSet<ExModel> ExModels { get; set; }

        public DbSet<UserIdentity> Users { get; set; }
        public DbSet<User_Edit_Log_Model> User_Edit_Log_Models { get; set; }
        public DbSet<Login_Log_Model> Login_Log_Models { get; set; }

        public DbSet<IoT_Data_Model> IoT_Data_Models { get; set; }        
        public DbSet<IoT_Model> IoT_Models { get; set; }
        
        public DbSet<Material_Model> Material_Models { get; set; }
        public DbSet<Materal_Stored_Log_Model> Materal_Stored_Log_Models { get; set; }
        public DbSet<Material_Edit_Log_Model> Material_Edit_Log_Models { get; set; }

        public DbSet<Order_Model> Order_Models { get; set; }
        public DbSet<Order_Product_Model> Order_Products { get; set; }
        public DbSet<Order_Edit_Log_Model> Order_Edit_Log_Models { get; set; }        

        public DbSet<Product_Edit_LogModel> Product_Edit_Log_Models { get; set; }
        public DbSet<Product_Model> Product_Models { get; set; }
        public DbSet<Product_Use_Metrail_Model> Product_Use_Metrail_Models { get; set; }
        public DbSet<Product_Create_Model> product_Create_Models { get; set; }

        public DbSet<Inventory_Model> Inventory_Models { get; set; }
        public DbSet<Inventory_Edit_Log_Model> Inventory_Edit_Log_Model { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product_Edit_LogModel>()
                .HasOne(p => p.Product)
                .WithMany(p => p.ProductEditLogModels);

            modelBuilder.Entity<Product_Model>()
                .Ignore(p => p.MetrailId)
                .Ignore(p => p.count);

            modelBuilder.Entity<Order_Model>()
                .Ignore(p => p.ProductId)
                .Ignore(p => p.Quantity);

            //modelBuilder.Entity<ProductModel>()
            //    .HasMany(p => p.WishUsers)
            //    .WithMany(u => u.WishProducts)
            //    .UsingEntity("wish_user_product");

            //modelBuilder
            //.Entity<BuyListModel>()
            //.HasKey(b => b.Id);


            //modelBuilder
            //.Entity<BuyListModel>()
            //.HasOne(b => b.ProductModel)
            //.WithMany(p => p.buyListModels);

            //modelBuilder
            //    .Entity<BuyListModel>()
            //    .HasOne(l => l.NewIdentityUser)
            //    .WithMany(l => l.buyListModels);

            //modelBuilder.Entity<PostModel>()
            //    .HasMany(p => p.LikeUsers)
            //    .WithMany(u => u.LikePosts)
            //    .UsingEntity("like_post_user");
        }













    }
}
