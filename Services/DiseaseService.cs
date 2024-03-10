using PetUci.InterfacesBussines;
using PetUci.InterfacesDataBase;
using PetUci.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetUci.Services
{
    public class DiseaseService : IDiseaseService
    {
        private readonly IDiseaseRepository _diseaseRepository;

        public DiseaseService(IDiseaseRepository diseaseRepository)
        {
            _diseaseRepository = diseaseRepository;
        }

        public Task<IEnumerable<Disease>> GetDiseasesAsync()
        {
            return _diseaseRepository.GetDiseasesAsync();
        }

        public Task<Disease> GetDiseaseByIdAsync(int diseaseId)
        {
            return _diseaseRepository.GetDiseaseByIdAsync(diseaseId);
        }

        public Task AddDiseaseAsync(Disease disease)
        {
            return _diseaseRepository.AddDiseaseAsync(disease);
        }

        public Task UpdateDiseaseAsync(Disease disease)
        {
            return _diseaseRepository.UpdateDiseaseAsync(disease);
        }

        public Task DeleteDiseaseAsync(int diseaseId)
        {
            return _diseaseRepository.DeleteDiseaseAsync(diseaseId);
        }
    }
}
