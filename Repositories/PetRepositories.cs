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

        public async Task<IEnumerable<Pet>> GetPetsAsync()
        {
            return await _context.Pets.ToListAsync();
        }

        public async Task<Pet> GetPetByIdAsync(int petId)
        {
            return await _context.Pets.FindAsync(petId);
        }

        public async Task AddPetAsync(Pet pet)
        {
            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePetAsync(Pet pet)
        {
            _context.Entry(pet).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePetAsync(int petId)
        {
            var pet = await _context.Pets.FindAsync(petId);
            if (pet != null)
            {
                _context.Pets.Remove(pet);
                await _context.SaveChangesAsync();
            }
        }
    }
}

