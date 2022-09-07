using IMS.UseCase.Category.Interfaces;
using IMS.UseCase.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCase.Category
{
    public class EditCategoryUseCase : IEditCategoryUseCase
    {
        private readonly ICategoryRepository categoryRepository;
        public EditCategoryUseCase(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task ExcuteAsync(IMS.CoreBusiness.Category inventory)
        {
            if (await this.categoryRepository.ExistAsync(inventory))
            {
                await this.categoryRepository.UpdateCategoryAsync(inventory);
            }
        }

    }
}
