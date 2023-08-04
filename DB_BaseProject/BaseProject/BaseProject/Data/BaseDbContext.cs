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

        public DbSet<IoTDataModel> IoTDataModels { get; set; }
        
        public DbSet<IoTModel> IoTModels { get; set; }

        public DbSet<LoginLogModel> LoginLogModels { get; set; }

        public DbSet<MaterialModel> MaterialModels { get; set; }

        public DbSet<OrderModel> OrderModels { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<OrderEditLogModel> OrderEditLogModels { get; set; }        

        public DbSet<ProductEditLogModel> ProductEditLogModels { get; set; }

        public DbSet<ProductModel> ProductModels { get; set; }

        public DbSet<UserEditLogModel> UserEditLogModels { get; set; }
        public DbSet<ProductUseMetrailModel> ProductUseMetrailModels { get; set; }
        public DbSet<InventoryModel> InventoryModels { get; set; }
        public DbSet<InventoryLogModel> InventoryLogModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductEditLogModel>()
                .HasOne(p => p.Product)
                .WithMany(p => p.ProductEditLogModels);

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
