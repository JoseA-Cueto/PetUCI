using Microsoft.EntityFrameworkCore;
using PetUci.Context;
using PetUci.InterfacesDataBase;
using PetUci.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetUci.Repositories
{
    public class ForumRepository : IForumRepository
    {
        private readonly AppDbContext _context;

        public ForumRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddForumAsync(Forum forum)
        {
            _context.Forums.Add(forum);
            await _context.SaveChangesAsync();
         
        }

        public async Task DeleteForumAsync(int forumId)
        {
            var forum = await _context.Forums.FindAsync(forumId);
            if (forum != null)
            {
                _context.Forums.Remove(forum);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Forum>> GetForumsAsync()
        {
            return await _context.Forums.ToListAsync();
        }

        public async Task<Forum> GetForumByIdAsync(int forumId)
        {
            return await _context.Forums.FindAsync(forumId);
        }

        public async Task UpdateForumAsync(Forum forum)
        {
            _context.Entry(forum).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
