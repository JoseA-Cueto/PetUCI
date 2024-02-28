using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PetUci.InterfacesBussines;
using PetUci.InterfacesDataBase;
using PetUci.Models;
using PetUci.ViewModels;

namespace PetUci.Services
{
    public class VaccineService : IVaccineService
    {
        private readonly IVaccineRepository _vaccineRepository;
        private readonly IMapper _mapper;

        public VaccineService(IVaccineRepository vaccineRepository, IMapper mapper)
        {
            _vaccineRepository = vaccineRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VaccineViewModel>> GetVaccinesAsync()
        {
            var vaccines = await _vaccineRepository.GetVaccinesAsync();
            return _mapper.Map<IEnumerable<VaccineViewModel>>(vaccines);
        }

        public async Task<VaccineViewModel> GetVaccineByIdAsync(int vaccineId)
        {
            var vaccine = await _vaccineRepository.GetVaccineByIdAsync(vaccineId);
            return _mapper.Map<VaccineViewModel>(vaccine);
        }

        public async Task<int> AddVaccineAsync(VaccineViewModel vaccineViewModel)
        {
            var vaccine = _mapper.Map<Vaccine>(vaccineViewModel);
            return await _vaccineRepository.AddVaccineAsync(vaccine);
        }

        public async Task UpdateVaccineAsync(VaccineViewModel vaccineViewModel)
        {
            var vaccine = _mapper.Map<Vaccine>(vaccineViewModel);
            await _vaccineRepository.UpdateVaccineAsync(vaccine);
        }

        public async Task DeleteVaccineAsync(int vaccineId)
        {
            await _vaccineRepository.DeleteVaccineAsync(vaccineId);
        }
    }
}
