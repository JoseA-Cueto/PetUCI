using AutoMapper;
using PetUci.InterfacesBussines;
using PetUci.InterfacesDataBase;
using PetUci.Models;
using PetUci.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetUci.Services
{
    public class TreatmentService : ITreatmentService
    {
        private readonly ITreatmentRepository _treatmentRepository;
        private readonly IMapper _mapper;

        public TreatmentService(ITreatmentRepository treatmentRepository, IMapper mapper)
        {
            _treatmentRepository = treatmentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TreatmentViewModel>> GetTreatmentsAsync()
        {
            var treatments = await _treatmentRepository.GetTreatmentsAsync();
            return _mapper.Map<IEnumerable<TreatmentViewModel>>(treatments);
        }

        public async Task<TreatmentViewModel> GetTreatmentByIdAsync(int treatmentId)
        {
            var treatment = await _treatmentRepository.GetTreatmentByIdAsync(treatmentId);
            return _mapper.Map<TreatmentViewModel>(treatment);
        }

        public async Task<int> AddTreatmentAsync(TreatmentViewModel treatmentViewModel)
        {
            var treatment = _mapper.Map<Treatment>(treatmentViewModel);
            return await _treatmentRepository.AddTreatmentAsync(treatment);
        }

        public async Task UpdateTreatmentAsync(TreatmentViewModel treatmentViewModel)
        {
            var existingTreatment = await _treatmentRepository.GetTreatmentByIdAsync(treatmentViewModel.id);
            if (existingTreatment != null)
            {
                _mapper.Map(treatmentViewModel, existingTreatment);
                await _treatmentRepository.UpdateTreatmentAsync(existingTreatment);
            }
        }

        public async Task DeleteTreatmentAsync(int treatmentId)
        {
            await _treatmentRepository.DeleteTreatmentAsync(treatmentId);
        }
    }
}
