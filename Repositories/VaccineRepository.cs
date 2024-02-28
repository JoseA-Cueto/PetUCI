using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetUci.Context;
using PetUci.InterfacesDataBase;
using PetUci.Models;

namespace PetUci.Repositories
{
    public class VaccineRepository : IVaccineRepository
    {
        private readonly AppDbContext _context;

        public VaccineRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Vaccine>> GetVaccinesAsync()
        {
            return await _context.Vaccines.ToListAsync();
        }

        public async Task<Vaccine> GetVaccineByIdAsync(int vaccineId)
        {
            return await _context.Vaccines.FindAsync(vaccineId);
        }

        public async Task<int> AddVaccineAsync(Vaccine vaccine)
        {
            _context.Vaccines.Add(vaccine);
            await _context.SaveChangesAsync();
            return vaccine.id;
        }

        public async Task UpdateVaccineAsync(Vaccine vaccine)
        {
            _context.Vaccines.Update(vaccine);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteVaccineAsync(int vaccineId)
        {
            var vaccine = await _context.Vaccines.FindAsync(vaccineId);
            if (vaccine != null)
            {
                _context.Vaccines.Remove(vaccine);
                await _context.SaveChangesAsync();
            }
        }
    }
}
