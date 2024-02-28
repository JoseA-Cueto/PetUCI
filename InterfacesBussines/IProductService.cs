using PetUci.ViewModels;

namespace PetUci.InterfacesBussines
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetProductsAsync();
        Task<ProductViewModel> GetProductByIdAsync(int productId);
        Task<int> AddProductAsync(ProductViewModel productViewModel);
        Task UpdateProductAsync(ProductViewModel productViewModel);
        Task DeleteProductAsync(int productId);
        Task UpdateProductQuantityAsync(int productId, int quantityChange);
    }
}
