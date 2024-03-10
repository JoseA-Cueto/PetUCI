using PetUci.Context;
using PetUci.InterfacesDataBase;
using PetUci.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetUci.Repositories
{
    public class DiseaseRepository : IDiseaseRepository
    {
        private readonly AppDbContext _context;

        public DiseaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Disease>> GetDiseasesAsync()
        {
            return await _context.Diseases.ToListAsync();
        }

        public async Task<Disease> GetDiseaseByIdAsync(int diseaseId)
        {
            return await _context.Diseases.FindAsync(diseaseId);
        }

        public async Task AddDiseaseAsync(Disease disease)
        {
            await _context.Diseases.AddAsync(disease);
            await _context.SaveChangesAsync();
           
        }

        public async Task UpdateDiseaseAsync(Disease disease)
        {
            _context.Diseases.Update(disease);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDiseaseAsync(int diseaseId)
        {
            var disease = await _context.Diseases.FindAsync(diseaseId);
            if (disease != null)
            {
                _context.Diseases.Remove(disease);
                await _context.SaveChangesAsync();
            }
        }
    }
}
