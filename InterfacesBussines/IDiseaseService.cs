using PetUci.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetUci.InterfacesBussines
{
    public interface IDiseaseService
    {
        Task<IEnumerable<Disease>> GetDiseasesAsync();
        Task<Disease> GetDiseaseByIdAsync(int diseaseId);
        Task<int> AddDiseaseAsync(Disease disease);
        Task UpdateDiseaseAsync(Disease disease);
        Task DeleteDiseaseAsync(int diseaseId);
    }
}
