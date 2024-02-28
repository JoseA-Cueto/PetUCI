using PetUci.Models;
using PetUci.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PetUci.InterfacesBussines
{
    public interface IPetService
    {
        Task<IEnumerable<PetViewModel>> GetPetAsync();
        Task<PetViewModel> GetPetByIdAsync(int petId);
        Task AddPetAsync(PetViewModel petViewModel);
        Task UpdatePetAsync(PetViewModel petViewModel);
        Task DeletePetAsync(int petId);
    }
}
