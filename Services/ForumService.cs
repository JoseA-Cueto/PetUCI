using AutoMapper;
using PetUci.InterfacesBussines;
using PetUci.InterfacesDataBase;
using PetUci.Models;
using PetUci.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetUci.Services
{
    public class ForumService : IForumService
    {
        private readonly IForumRepository _forumRepository;
        private readonly IMapper _mapper;

        public ForumService(IForumRepository forumRepository, IMapper mapper)
        {
            _forumRepository = forumRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ForumViewModel>> GetForumsAsync()
        {
            var forums = await _forumRepository.GetForumsAsync();
            return _mapper.Map<IEnumerable<ForumViewModel>>(forums);
        }

        public async Task<ForumViewModel> GetForumByIdAsync(int forumId)
        {
            var forum = await _forumRepository.GetForumByIdAsync(forumId);
            return _mapper.Map<ForumViewModel>(forum);
        }

        public async Task AddForumAsync(ForumViewModel forumViewModel)
        {
            var forum = _mapper.Map<Forum>(forumViewModel);
            await _forumRepository.AddForumAsync(forum);
        }

        public async Task UpdateForumAsync(ForumViewModel forumViewModel)
        {
            var forum = _mapper.Map<Forum>(forumViewModel);
            await _forumRepository.UpdateForumAsync(forum);
        }

        public async Task DeleteForumAsync(int forumId)
        {
            await _forumRepository.DeleteForumAsync(forumId);
        }
    }
}
