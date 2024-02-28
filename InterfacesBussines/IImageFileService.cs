using PetUci.Models;
using PetUci.ViewModels;

namespace PetUci.InterfacesBussines
{
    public interface IImageFileService
    {
        Task<ImageFiles> CreateImageFile(ProductViewModel product);

        Task<ImageFiles> Create(ImageFilesViewModel entity);
        Task UpdateImageFile(ProductViewModel productViewModel);
        Task<ImageFiles> GetImageByProductIdAsync(int productId);
        Task DeleteImageFileAsync(int imageId);
    }
}
