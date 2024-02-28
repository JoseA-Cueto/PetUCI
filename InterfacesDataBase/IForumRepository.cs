using PetUci.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetUci.InterfacesDataBase
{
    public interface IForumRepository
    {
        Task<IEnumerable<Forum>> GetForumsAsync();
        Task<Forum> GetForumByIdAsync(int forumId);
        Task<int> AddForumAsync(Forum forum);
        Task UpdateForumAsync(Forum forum);
        Task DeleteForumAsync(int forumId);
    }
}
