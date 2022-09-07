namespace IMS.UseCase.Product.Interfaces
{
    public interface IAddProductUseCase
    {
        Task ExcuteAsync(CoreBusiness.Product product);
    }
}