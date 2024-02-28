using PetUci.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetUci.InterfacesDataBase
{
    public interface IVaccineRepository
    {
        Task<IEnumerable<Vaccine>> GetVaccinesAsync();
        Task<Vaccine> GetVaccineByIdAsync(int vaccineId);
        Task<int> AddVaccineAsync(Vaccine vaccine);
        Task UpdateVaccineAsync(Vaccine vaccine);
        Task DeleteVaccineAsync(int vaccineId);
    }
}
