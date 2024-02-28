using PetUci.Models;

namespace PetUci.InterfacesDataBase
{
    public interface IPetRepositories 
    {
        Task AddAsync(Pet entity);
        Task<Pet> Delete(int id);
        Task<List<Pet>> GetAll();
        Task<Pet> GetOne(int id);
        Task UpdateAsync(Pet entity);
    }
}
