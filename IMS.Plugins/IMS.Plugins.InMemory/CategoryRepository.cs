using IMS.CoreBusiness;
using IMS.UseCase.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugins.InMemory
{
    public class CategoryRepository : ICategoryRepository
    {
        public List<Category> _categories;
        public CategoryRepository()
        {
            _categories = new List<Category>()
            {
                new Category(){ Id= 1, Name ="Quần" , Description="Danh mục quẩn"},
                new Category(){ Id= 2, Name ="Áo" , Description="Danh mục áo"},
                new Category(){ Id= 3, Name ="Mũ" , Description="Danh mục mũ"},
            };
        }
        public Task AddCategoryAsync(Category category)
        {
            var maxId = _categories.Max(x => x.Id);
            category.Id = maxId + 1;
            _categories.Add(category);
            return Task.CompletedTask;

        }

        public async Task<bool> ExistAsync(Category category)
        {
            return await Task.FromResult(_categories.Any(x =>
                    x.Id != category.Id &&
                    x.Name.Equals(category.Name, StringComparison.OrdinalIgnoreCase)));
        }

        public async Task<IEnumerable<Category>> GetCategoriesByNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name)) return await Task.FromResult(_categories);
            return _categories.Where(k => k.Name.Contains(name, StringComparison.OrdinalIgnoreCase));

        }

        public async Task<Category> GetCategoryByIdAsync(int categoryId)
        {
            var cat = _categories.First(x => x.Id == categoryId);
            var newCat = new Category
            {
                Id = cat.Id,
                Name = cat.Name,
                Image = cat.Image,
                Description = cat.Description,
                Products = cat.Products
            };
            return await Task.FromResult(newCat);

        }

        public async Task UpdateCategoryAsync(Category category)
        {
            var cat = _categories.FirstOrDefault(x => x.Id  == category.Id);
            if (cat != null)
            {
                cat.Name = category.Name;
                cat.Image = category.Image;
                cat.Description = category.Description;
                cat.Products = category.Products;
            }
            await Task.CompletedTask;
        }
    }
}
