namespace IMS.UseCase.Product.Interfaces
{
    public interface IEditProductUseCase
    {
        Task ExcuteAsync(CoreBusiness.Product product);
    }
}