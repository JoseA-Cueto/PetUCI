using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetUci.Context;
using PetUci.InterfacesBussines;
using PetUci.InterfacesDataBase;
using PetUci.Models;
using PetUci.ViewModels;

namespace PetUci.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _dbContext;
        private readonly IEncryptionService _encryptionService;

        public UserService(IUserRepository userRepository, IMapper mapper, AppDbContext dbContext, IEncryptionService encryptionService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _dbContext = dbContext;
            _encryptionService = encryptionService;
        }

        public async Task<IEnumerable<UserViewModel>> GetUsersAsync()
        {
            var users = await _userRepository.GetUsersAsync();
            return _mapper.Map<IEnumerable<UserViewModel>>(users);
        }
        public async Task<User> FindUserAsync(UserViewModel userViewModel)
        {
            // Encripta la contraseña proporcionada por el usuario
            string encryptedPassword = _encryptionService.EncryptPassword(userViewModel.contraseña);


            var entity = await _dbContext.Users.FirstOrDefaultAsync(u => u.nombre == userViewModel.nombre && u.contraseña == encryptedPassword);

            return entity;
        }


        public async Task<UserViewModel> GetUserByIdAsync(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            return _mapper.Map<UserViewModel>(user);
        }

        public async Task AddUserAsync(UserViewModel userViewModel)
        {
            var user = _mapper.Map<User>(userViewModel);
            user.contraseña = _encryptionService.EncryptPassword(user.contraseña);
            await _userRepository.AddUserAsync(user);
        }

        public async Task UpdateUserAsync(UserViewModel userViewModel)
        {
            var existingUser = await _userRepository.GetUserByIdAsync(userViewModel.id);
            if (existingUser != null)
            {
                _mapper.Map(userViewModel, existingUser);
                await _userRepository.UpdateUserAsync(existingUser);
            }
        }

        public async Task DeleteUserAsync(int userId)
        {
            await _userRepository.DeleteUserAsync(userId);
        }
    }
}
