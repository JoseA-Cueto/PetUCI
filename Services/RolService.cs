using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PetUci.InterfacesBussines;
using PetUci.InterfacesDataBase;
using PetUci.Models;
using PetUci.ViewModels;

namespace PetUci.Services
{
    public class RolService : IRolService
    {
        private readonly IRolRepository _rolRepository;
        private readonly IMapper _mapper;

        public RolService(IRolRepository rolRepository, IMapper mapper)
        {
            _rolRepository = rolRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RolViewModel>> GetRolAsync()
        {
            var rols = await _rolRepository.GetRolsAsync();
            return _mapper.Map<IEnumerable<RolViewModel>>(rols);
        }

        public async Task<RolViewModel> GetRolByIdAsync(int rolId)
        {
            var rol = await _rolRepository.GetRolByIdAsync(rolId);
            return _mapper.Map<RolViewModel>(rol);
        }

        public async Task AddRolAsync(RolViewModel rolViewModel)
        {
            var rol = _mapper.Map<Rol>(rolViewModel);
            await _rolRepository.AddRolAsync(rol);
        }

        public async Task UpdateRolAsync(RolViewModel rolViewModel)
        {
            var existingRol = await _rolRepository.GetRolByIdAsync(rolViewModel.id);
            if (existingRol != null)
            {
                _mapper.Map(rolViewModel, existingRol);
                await _rolRepository.UpdateRolAsync(existingRol);
            }
        }

        public async Task DeleteRolAsync(int rolId)
        {
            await _rolRepository.DeleteRolAsync(rolId);
        }
    }
}
