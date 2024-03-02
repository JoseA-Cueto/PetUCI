using PetUci.Models;

namespace PetUci.InterfacesDataBase
{
    public interface IPetRepositories 
    {
        Task<IEnumerable<Pet>> GetPetsAsync();
        Task<Pet> GetPetByIdAsync(int petId);
        Task AddPetAsync(Pet pet);
        Task UpdatePetAsync(Pet pet);
        Task DeletePetAsync(int petId);
    }
}
