using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urfu.Models;
using Urfu.Repository;

namespace Urfu.Service
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> Authenticate(string username, string password)
        {
            var user = await Task.Run(() => _userRepository.Authenticate(username, password));
            if (user == null)
                return null;
            return user;
        }
    }
}
