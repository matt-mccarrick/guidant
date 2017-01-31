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
        User GetById(long pId);
        bool Add(User user);
        bool Update(User user);
        bool Delete(User user);
    }
}
