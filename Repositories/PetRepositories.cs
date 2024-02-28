using Microsoft.EntityFrameworkCore;
using PetUci.Context;
using PetUci.InterfacesDataBase;
using PetUci.Models;

namespace PetUci.Repositories
{
    public class PetRepositories : IPetRepositories
    {
        private AppDbContext _context;

        public PetRepositories(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Pet entity) => await _context.AddAsync(entity);


        public async Task<Pet> Delete(int id)
        {
            var Pet = await _context.Pets.FindAsync(id);
            _context.Remove(Pet!);
            return Pet!;
        }

        public Task<List<Pet>> GetAll() => _context.Pets.ToListAsync();

        public Task<Pet> GetOne(int id) => _context.Pets.FindAsync(id).AsTask()!;


        public Task UpdateAsync(Pet entity)
        {
            _context.Update(entity);
            return Task.CompletedTask;
        }
    }
}

