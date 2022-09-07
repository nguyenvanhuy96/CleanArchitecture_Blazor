using IMS.CoreBusiness;
using IMS.UseCase.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugins.InMemory
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> _products;
        public ProductRepository()
        {
            _products = new List<Product>();
        }
        public Task AddProductAsync(Product product)
        {
            int maxId = 0;
            if (_products.Count>0) maxId = _products.Max(x => x.Id);
            product.Id = maxId + 1;
            _products.Add(product);
            return Task.CompletedTask;
        }

        public async Task<bool> ExistAsync(Product product)
        {
            return await Task.FromResult(_products.Any(x =>
                    x.Id != product.Id &&
                    x.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase)));
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            var cat = _products.First(x => x.Id == productId);
            var newCat = new Product
            {
                Id = cat.Id,
                Name = cat.Name,
                Image = cat.Image,
                Price = cat.Price,
                Description = cat.Description,
                CategoryId = cat.CategoryId,
            };
            return await Task.FromResult(newCat);
        }

        public async Task<IEnumerable<Product>> GetProductsByNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name)) return await Task.FromResult(_products);
            return _products.Where(k => k.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public async Task UpdateProductAsync(Product product)
        {
            var prod = _products.FirstOrDefault(x => x.Id == product.Id);
            if (prod != null)
            {
                prod.Name = product.Name;
                prod.Image = product.Image;
                prod.Price = product.Price;
                prod.Description = product.Description;
                prod.CategoryId = product.CategoryId;
            }
            await Task.CompletedTask;
        }
    }
}
