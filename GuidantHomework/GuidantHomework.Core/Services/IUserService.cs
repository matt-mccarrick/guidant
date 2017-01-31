using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuidantHomework.Core.Model;

namespace GuidantHomework.Core.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        int AddUser(User user);
        User GetUser(int id);
        void SetPoints(int id, int points);
    }
}
