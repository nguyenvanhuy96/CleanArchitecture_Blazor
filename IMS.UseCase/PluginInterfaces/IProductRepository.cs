using IMS.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCase.PluginInterfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<IMS.CoreBusiness.Product>> GetProductsByNameAsync(string name);
        Task<bool> ExistAsync(IMS.CoreBusiness.Product product);
        Task AddProductAsync(IMS.CoreBusiness.Product product);
        Task UpdateProductAsync(IMS.CoreBusiness.Product product);
        Task<IMS.CoreBusiness.Product> GetProductByIdAsync(int productId);
    }
}
