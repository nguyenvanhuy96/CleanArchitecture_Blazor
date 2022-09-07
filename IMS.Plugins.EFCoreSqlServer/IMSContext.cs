using IMS.CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugins.EFCoreSqlServer
{
    public class IMSContext : DbContext
    {
        public IMSContext(DbContextOptions<IMSContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Product>? Products { get; set; }
 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API hoặc sử dụng Atribute trong CoreBusiness trên mỗi thuộc tính
            //modelBuilder.Entity<ProductInventory>()
            //    .HasKey(pi => new { pi.ProductId, pi.InventoryId });

            //modelBuilder.Entity<ProductInventory>()
            //    .HasOne(pi => pi.Product)
            //    .WithMany(p => p.ProductInventories)
            //    .HasForeignKey(pi => pi.ProductId);

           
            // Setting Data
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Quần", Description ="Danh mục quần" },
                new Category { Id = 2, Name = "Áo", Description = "Danh mục áo" }
            );

        }
    }
}
