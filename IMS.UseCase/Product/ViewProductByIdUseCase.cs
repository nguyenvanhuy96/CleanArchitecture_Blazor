using IMS.UseCase.PluginInterfaces;
using IMS.UseCase.Product.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCase.Product
{
    public class ViewProductByIdUseCase : IViewProductByIdUseCase
    {
        private readonly IProductRepository productRepository;
        public ViewProductByIdUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task<IMS.CoreBusiness.Product> ExcuteAsync(int productId)
        {
            return await this.productRepository.GetProductByIdAsync(productId);
        }
    }
}
