using PetUci.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetUci.InterfacesDataBase
{
    public interface IDiseaseRepository
    {
        Task<IEnumerable<Disease>> GetDiseasesAsync();
        Task<Disease> GetDiseaseByIdAsync(int diseaseId);
        Task<int> AddDiseaseAsync(Disease disease);
        Task UpdateDiseaseAsync(Disease disease);
        Task DeleteDiseaseAsync(int diseaseId);
    }
}
