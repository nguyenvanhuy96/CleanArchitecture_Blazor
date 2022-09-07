using IMS.UseCase.Category.Interfaces;
using IMS.UseCase.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCase.Category
{
    public class ViewCategoryByIdUseCase : IViewCategoryByIdUseCase
    {
        private readonly ICategoryRepository categoryRepository;
        public ViewCategoryByIdUseCase(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public async Task<IMS.CoreBusiness.Category> ExcuteAsync(int categoryId)
        {
            return await this.categoryRepository.GetCategoryByIdAsync(categoryId);
        }
    }
}
