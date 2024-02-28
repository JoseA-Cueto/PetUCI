using PetUci.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetUci.InterfacesBussines
{
    public interface IForumService
    {
        Task<IEnumerable<ForumViewModel>> GetForumsAsync();
        Task<ForumViewModel> GetForumByIdAsync(int forumId);
        Task<int> AddForumAsync(ForumViewModel forumViewModel);
        Task UpdateForumAsync(ForumViewModel forumViewModel);
        Task DeleteForumAsync(int forumId);
    }
}
