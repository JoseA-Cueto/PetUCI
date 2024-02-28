using PetUci.Models;
using PetUci.ViewModels;

namespace PetUci.InterfacesBussines
{
    public interface IUserService
    {
        Task<IEnumerable<UserViewModel>> GetUsersAsync();
        Task<UserViewModel> GetUserByIdAsync(int userId);
        Task AddUserAsync(UserViewModel userViewModel);
        Task UpdateUserAsync(UserViewModel userViewModel);
        Task DeleteUserAsync(int userId);
        Task<User> FindUserAsync(UserViewModel userViewModel);
    }
}
