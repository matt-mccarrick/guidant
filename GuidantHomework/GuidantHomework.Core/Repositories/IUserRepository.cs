using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GuidantHomework.Core.Model;

namespace GuidantHomework.Core.Repositories
{
    public interface IUserRepository
    {
        IList<User> GetAll();
        User GetById(int pId);
        void Add(User user);
        void Update(User user);
        void Delete(User user);
    }
}
