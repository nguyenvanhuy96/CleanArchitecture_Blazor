using IMS.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCase.PluginInterfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<IMS.CoreBusiness.Category>> GetCategoriesByNameAsync(string name);
        Task<bool> ExistAsync(IMS.CoreBusiness.Category category);
        Task AddCategoryAsync(IMS.CoreBusiness.Category category);
        Task UpdateCategoryAsync(IMS.CoreBusiness.Category category);
        Task<IMS.CoreBusiness.Category> GetCategoryByIdAsync(int categoryId);
    }
}
