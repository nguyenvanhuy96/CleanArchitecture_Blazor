using IMS.CoreBusiness;
using IMS.UseCase.PluginInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugins.EFCoreSqlServer
{
    public class ProductEFRepository : IProductRepository
    {
        private readonly IDbContextFactory<IMSContext> contextFactory;
        public ProductEFRepository(IDbContextFactory<IMSContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }
        public async Task AddProductAsync(Product product)
        {
            using var db = this.contextFactory.CreateDbContext();
            db.Products.Add(product);
            await db.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync(Product product)
        {
            using var db = this.contextFactory.CreateDbContext();
            var inv = await db.Products.FindAsync(product.Id);
            if (inv != null) return true;
            return false;
        }

        public async   Task<Product> GetProductByIdAsync(int productId)
        {
            using var db = this.contextFactory.CreateDbContext();
            var inv = await db.Products.Include(x=>x.Category)
                            .FirstOrDefaultAsync(x=> x.Id == productId);
            if (inv != null) return inv;
            return new Product();
        }

        public  async Task<IEnumerable<Product>> GetProductsByNameAsync(string name)
        {
            using var db = this.contextFactory.CreateDbContext();
            return await db.Products.Include(x=>x.Category)
                     .Where(k => k.Name.ToLower().IndexOf(name.ToLower()) >= 0)
                     .ToListAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            using var db = this.contextFactory.CreateDbContext();
            var inv = await db.Products.Include(x=>x.Category)
                            .FirstOrDefaultAsync(x => x.Id == product.Id);
            if (inv != null)
            {
                inv.Name = product.Name;
                inv.Description = product.Description;
                inv.Price = product.Price;
                inv.CategoryId = product.CategoryId;
            }
            await db.SaveChangesAsync();
        }
        public async Task<int> DeleteProduct(int productId)
        {
            using var db = this.contextFactory.CreateDbContext();
            var product = await db.Products.FindAsync(productId);
            if (product != null)
            {
                db.Products.Remove(product);
                return db.SaveChanges();
            }
            return 0;
        }
    }
}
