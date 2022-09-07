namespace IMS.UseCase.Product.Interfaces
{
    public interface IViewProductsByNameUseCase
    {
        Task<IEnumerable<CoreBusiness.Product>> ExcuteAsync(string name = "");
    }
}