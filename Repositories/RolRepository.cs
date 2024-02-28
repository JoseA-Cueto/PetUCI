using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetUci.Context;
using PetUci.InterfacesDataBase;
using PetUci.Models;

namespace PetUci.Repositories
{
    public class RolRepository : IRolRepository
    {
        private readonly AppDbContext _context;

        public RolRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Rol>> GetRolsAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Rol> GetRolByIdAsync(int rolId)
        {
            return await _context.Roles.FindAsync(rolId);
        }

        public async Task<int> AddRolAsync(Rol rol)
        {
            _context.Roles.Add(rol);
            await _context.SaveChangesAsync();
            return rol.id;
        }

        public async Task UpdateRolAsync(Rol rol)
        {
            _context.Roles.Update(rol);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRolAsync(int rolId)
        {
            var rol = await _context.Roles.FindAsync(rolId);
            if (rol != null)
            {
                _context.Roles.Remove(rol);
                await _context.SaveChangesAsync();
            }
        }
    }
}
