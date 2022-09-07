namespace IMS.UseCase.Product.Interfaces
{
    public interface IViewProductByIdUseCase
    {
        Task<CoreBusiness.Product> ExcuteAsync(int productId);
    }
}