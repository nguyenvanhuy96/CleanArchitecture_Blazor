using IMS.UseCase.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.CoreBusiness;
using IMS.UseCase.Category.Interfaces;

namespace IMS.UseCase.Category
{
    public class AddCategoryUseCase : IAddCategoryUseCase
    {
        private readonly ICategoryRepository categoryRepository;
        public AddCategoryUseCase(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task ExcuteAsync(IMS.CoreBusiness.Category category)
        {
            if (!await this.categoryRepository.ExistAsync(category))
                await this.categoryRepository.AddCategoryAsync(category);
        }

    }
}
