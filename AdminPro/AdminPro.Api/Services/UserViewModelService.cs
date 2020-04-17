using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdminPro.Api.Interfaces;
using AdminPro.Api.ViewModels;
using AdminPro.Core.Entities;
using AdminPro.Core.Interfaces;
using AutoMapper;

namespace AdminPro.Api.Services
{
    public class UserViewModelService : IUserViewModelService
    {
        private readonly IAsyncRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserViewModelService(IAsyncRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<bool> ExistsUser(Guid id)
        {
            var exists = await _userRepository.ExistsAsync(id);
            return exists;
        }

        public async Task<IEnumerable<UserViewModel>> GetAll()
        {
            var users = await _userRepository.ListAllAsync();
            var usersViewModel = _mapper.Map<IEnumerable<UserViewModel>>(users);

            return usersViewModel;
        }

        public async Task<UserViewModel> GetById(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            var userViewModel = _mapper.Map<UserViewModel>(user);
            return userViewModel;
        }

        public async Task Update(Guid id, UserForUpdateViewModel userViewModel)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user != null)
            {
                user.Img = userViewModel.Img;
                user.Role = userViewModel.Role;

                await _userRepository.UpdateAsync(user);
            }
        }
    }
}
