using PetUci.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetUci.InterfacesBussines
{
    public interface ITreatmentService
    {
        Task<IEnumerable<TreatmentViewModel>> GetTreatmentsAsync();
        Task<TreatmentViewModel> GetTreatmentByIdAsync(int treatmentId);
        Task<int> AddTreatmentAsync(TreatmentViewModel treatmentViewModel);
        Task UpdateTreatmentAsync(TreatmentViewModel treatmentViewModel);
        Task DeleteTreatmentAsync(int treatmentId);
    }
}
