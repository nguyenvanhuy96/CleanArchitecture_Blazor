namespace IMS.UseCase.Category.Interfaces
{
    public interface IEditCategoryUseCase
    {
        Task ExcuteAsync(CoreBusiness.Category inventory);
    }
}