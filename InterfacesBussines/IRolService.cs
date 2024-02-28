using PetUci.ViewModels;

namespace PetUci.InterfacesBussines
{
    public interface IRolService
    {
        Task<IEnumerable<RolViewModel>> GetRolAsync();
        Task<RolViewModel> GetRolByIdAsync(int rolId);
        Task AddRolAsync(RolViewModel rolViewModel);
        Task UpdateRolAsync(RolViewModel rolViewModel);
        Task DeleteRolAsync(int rolId);
    }
}
