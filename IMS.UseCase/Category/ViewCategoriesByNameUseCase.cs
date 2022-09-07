using IMS.UseCase.Category.Interfaces;
using IMS.UseCase.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCase.Category
{
    public class ViewCategoriesByNameUseCase : IViewCategoriesByNameUseCase
    {
        private readonly ICategoryRepository categoryRepository;
        public ViewCategoriesByNameUseCase(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<IMS.CoreBusiness.Category>> ExcuteAsync(string name = "")
        {
            return await categoryRepository.GetCategoriesByNameAsync(name);
        }
    }
}
