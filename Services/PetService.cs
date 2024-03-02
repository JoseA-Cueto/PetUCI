using AutoMapper;
using PetUci.InterfacesBussines;
using PetUci.InterfacesDataBase;
using PetUci.Models;
using PetUci.ViewModels;

namespace PetUci.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepositories _petRepository;
        private readonly IMapper _mapper;

        public PetService(IPetRepositories petRepository, IMapper mapper)
        {
            _petRepository = petRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PetViewModel>> GetPetAsync()
        {
            var pet = await _petRepository.GetPetsAsync();
            return _mapper.Map<IEnumerable<PetViewModel>>(pet);
        }

        public async Task<PetViewModel> GetPetByIdAsync(int petId)
        {
            var pet = await _petRepository.GetPetByIdAsync(petId);
            return _mapper.Map<PetViewModel>(pet);
        }

        public async Task AddPetAsync(PetViewModel petViewModel)
        {
            var pet = _mapper.Map<Pet>(petViewModel);
            await _petRepository.AddPetAsync(pet);
        }

        public async Task UpdatePetAsync(PetViewModel petViewModel)
        {
            var existingPet = await _petRepository.GetPetByIdAsync(petViewModel.id);
            if (existingPet != null)
            {
                _mapper.Map(petViewModel, existingPet);
                await _petRepository.UpdatePetAsync(existingPet);
            }
        }

        public async Task DeletePetAsync(int petId)
        {
            await _petRepository.DeletePetAsync(petId);
        }
    }
}
