namespace IMS.UseCase.Category.Interfaces
{
    public interface IViewCategoryByIdUseCase
    {
        Task<CoreBusiness.Category> ExcuteAsync(int categoryId);
    }
}