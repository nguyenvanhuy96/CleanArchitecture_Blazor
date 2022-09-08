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
    public class CategoryEFRepository : ICategoryRepository
    {
        private readonly IDbContextFactory<IMSContext> contextFactory;
        public CategoryEFRepository(IDbContextFactory<IMSContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }
        public async Task AddCategoryAsync(Category category)
        {
            using var db = this.contextFactory.CreateDbContext();
            await db.Categories.AddAsync(category);
            await db.SaveChangesAsync();

        }

        public async Task<bool> ExistAsync(Category category)
        {
            using var db = this.contextFactory.CreateDbContext();
            var inv = await db.Categories.FindAsync(category.Id);
            if (inv != null) return true;
            return false;
        }

        public async Task<IEnumerable<Category>> GetCategoriesByNameAsync(string name)
        {
            using var db = this.contextFactory.CreateDbContext();
            return await db.Categories
                     .Where(k => k.Name.ToLower().IndexOf(name.ToLower()) >= 0)
                     .ToListAsync();

        }

        public async Task<Category> GetCategoryByIdAsync(int categoryId)
        {
            using var db = this.contextFactory.CreateDbContext();
            var inv = await db.Categories.FindAsync(categoryId);
            if (inv != null) return inv;
            return new Category();

        }

        public async Task UpdateCategoryAsync(Category category)
        {
            using var db = this.contextFactory.CreateDbContext();
            var inv = await db.Categories.FindAsync(category.Id);
            if (inv != null)
            {
                inv.Name = category.Name;
                inv.Description = category.Description;
            }
            await db.SaveChangesAsync();
        }
        public async Task<int> DeleteCategory(int roomId)
        {
            using var db = this.contextFactory.CreateDbContext();
            var category = await db.Categories.FindAsync(roomId);
            if (category != null)
            {
                db.Categories.Remove(category);
                return db.SaveChanges();
            }
            return 0;
        }
    }
}
