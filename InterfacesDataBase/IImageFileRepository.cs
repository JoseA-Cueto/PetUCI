using PetUci.Models;

namespace PetUci.InterfacesDataBase
{
    public interface IImageFileRepository
    {
        Task<IEnumerable<ImageFiles>> GetAllAsync();
        Task<ImageFiles> GetByIdAsync(int id);
        Task<ImageFiles> CreateAsync(ImageFiles imageFile);
        Task UpdateAsync(ImageFiles imageFile);
        Task DeleteAsync(int id);
        Task<ImageFiles> CreateImageFile(ImageFiles entity);
        Task<ImageFiles> GetImageFileByProductIdAsync(int productId);
        Task<ImageFiles> GetImageByProductIdAsync(int productId);
        Task<ImageFiles> GetImageByPetIdAsync(int petId);
    }
}
