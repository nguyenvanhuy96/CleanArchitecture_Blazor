namespace IMS.UseCase.Category.Interfaces
{
    public interface IAddCategoryUseCase
    {
        Task ExcuteAsync(CoreBusiness.Category category);
    }
}