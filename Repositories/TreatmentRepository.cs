using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetUci.Context;
using PetUci.InterfacesDataBase;
using PetUci.Models;

namespace PetUci.Repositories
{
    public class TreatmentRepository : ITreatmentRepository
    {
        private readonly AppDbContext _context;

        public TreatmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Treatment>> GetTreatmentsAsync()
        {
            return await _context.Treatments.ToListAsync();
        }

        public async Task<Treatment> GetTreatmentByIdAsync(int treatmentId)
        {
            return await _context.Treatments.FindAsync(treatmentId);
        }

        public async Task<int> AddTreatmentAsync(Treatment treatment)
        {
            _context.Treatments.Add(treatment);
            await _context.SaveChangesAsync();
            return treatment.id;
        }

        public async Task UpdateTreatmentAsync(Treatment treatment)
        {
            _context.Treatments.Update(treatment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTreatmentAsync(int treatmentId)
        {
            var treatment = await _context.Treatments.FindAsync(treatmentId);
            if (treatment != null)
            {
                _context.Treatments.Remove(treatment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
