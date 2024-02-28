using PetUci.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetUci.InterfacesBussines
{
    public interface IVaccineService
    {
        Task<IEnumerable<VaccineViewModel>> GetVaccinesAsync();
        Task<VaccineViewModel> GetVaccineByIdAsync(int vaccineId);
        Task<int> AddVaccineAsync(VaccineViewModel vaccineViewModel);
        Task UpdateVaccineAsync(VaccineViewModel vaccineViewModel);
        Task DeleteVaccineAsync(int vaccineId);
    }
}
