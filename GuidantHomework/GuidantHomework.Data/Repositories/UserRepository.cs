using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using GuidantHomework.Core.Model;
using GuidantHomework.Core.Repositories;
using GuidantHomework.Data.FakeDB;

namespace GuidantHomework.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        //Using a static generated list for data storage right now. DB access is pretty simple in the case. Will put the SQL calls in comments so you know I know what I'm doing :)
        //I prefer using a thin layer like dapper in my own time. I'm also familiar with entity framework, NHibernate, or Linq to SQL
        //------------
        //Users
        //------------
        //PK Int ID Auto Increment
        //VarChar(32) Name
        //Int Points
        //------------
        public IList<User> GetAll()
        {
            //SELECT * FROM Users
            return db.Users;
        }

        public User GetById(int pId)
        {
            //SELECT * FROM Users WHERE ID = @pId
            return db.Users.FirstOrDefault(u => u.ID == pId);
        }

        public int Add(User user)
        {
            //INSERT INTO Users(Name, Points) Values (@user.Name, @user.Points)
            //We'd get the return ID from after the insert
            db.Users.Add(user);
            return user.ID;
        }

        public void Update(User user)
        {
            //UPDATE Users SET Name = @user.Name, Points = @user.Points WHERE ID = @user.ID
            var stored = db.Users.FirstOrDefault(u => u.ID == user.ID);
            if (stored != null)
            {
                stored.Name = user.Name;
                stored.Points = user.Points;
            }
        }

        public void Delete(User user)
        {
            //DELETE FROM Users WHERE ID = @user.ID
            //we're also going to do this just in case because our list doesn't enforce a primary key on the index
            db.Users.RemoveAll(u => u.ID == user.ID);
        }
    }
}
