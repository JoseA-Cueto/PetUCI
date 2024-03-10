using PetUci.Models;

namespace PetUci.InterfacesDataBase
{
    public interface IRolRepository
    {
        Task<IEnumerable<Rol>> GetRolsAsync();
        Task<Rol> GetRolByIdAsync(int rolId);
        Task AddRolAsync(Rol rol);
        Task UpdateRolAsync(Rol rol);
        Task DeleteRolAsync(int rolId);
    }
}
