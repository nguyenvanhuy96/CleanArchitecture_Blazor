using IMS.UseCase.PluginInterfaces;
using IMS.UseCase.Product.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCase.Product
{
    public class EditProductUseCase : IEditProductUseCase
    {
        private readonly IProductRepository productRepository;
        public EditProductUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task ExcuteAsync(IMS.CoreBusiness.Product product)
        {
            if ((await this.productRepository.ExistAsync(product)))
            {
                await this.productRepository.UpdateProductAsync(product);
            }
        }
    }
}
