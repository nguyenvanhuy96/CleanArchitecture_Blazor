using IMS.UseCase.PluginInterfaces;
using IMS.UseCase.Product.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCase.Product
{
    public class ViewProductsByNameUseCase : IViewProductsByNameUseCase
    {
        private readonly IProductRepository productRepository;
        public ViewProductsByNameUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<IEnumerable<IMS.CoreBusiness.Product>> ExcuteAsync(string name = "")
        {
            return await productRepository.GetProductsByNameAsync(name);
        }
    }
}
