using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuidantHomework.Core.Model;
using GuidantHomework.Core.Repositories;
using GuidantHomework.Core.Services;

namespace GuidantHomework.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IEnumerable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public int AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public User GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public void SetPoints(int id, int points)
        {
            throw new NotImplementedException();
        }
    }
}
