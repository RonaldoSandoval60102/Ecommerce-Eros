using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eros.src.Domain.User.Repository;
using Microsoft.EntityFrameworkCore;

namespace Eros.src.Domain.User.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Models.User> Create(Models.User entity)
        {
            return await _userRepository.Create(entity);
        }

        public void Delete(Models.User entity)
        {
            _userRepository.Delete(entity);
        }

        public async Task<List<Models.User>> Get()
        {
            return await _userRepository.Get();
        }

        public async Task<Models.User?> Get(long id)
        {
            return await _userRepository.Get(id);
        }

        public async Task<Models.User> Update(Models.User entity)
        {
            return await _userRepository.Update(entity);
        }
    }
}