using PetUci.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetUci.InterfacesDataBase
{
    public interface ITreatmentRepository
    {
        Task<IEnumerable<Treatment>> GetTreatmentsAsync();
        Task<Treatment> GetTreatmentByIdAsync(int treatmentId);
        Task AddTreatmentAsync(Treatment treatment);
        Task UpdateTreatmentAsync(Treatment treatment);
        Task DeleteTreatmentAsync(int treatmentId);
    }
}

