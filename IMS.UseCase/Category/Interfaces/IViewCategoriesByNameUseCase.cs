namespace IMS.UseCase.Category.Interfaces
{
    public interface IViewCategoriesByNameUseCase
    {
        Task<IEnumerable<CoreBusiness.Category>> ExcuteAsync(string name = "");
    }
}