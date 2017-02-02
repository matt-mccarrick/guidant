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
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public int AddUser(User user)
        {
            return _userRepository.Add(user);
        }

        public User GetUser(int id)
        {
            var user = _userRepository.GetById(id);
            if(user == null)
                throw new Exception($"No user found for ID:{id}");
            return user;
        }

        public void SetPoints(int id, int points)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
                throw new Exception($"No user found for ID:{id}");
            user.Points = points;
            //This line is redundant because we're modifying in-memory storage and c# is pass by ref, but this would be how this method would be structured with a DB behind it
            _userRepository.Update(user);
        }
    }
}
