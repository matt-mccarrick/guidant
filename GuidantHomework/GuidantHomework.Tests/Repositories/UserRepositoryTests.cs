using Microsoft.VisualStudio.TestTools.UnitTesting;
using GuidantHomework.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuidantHomework.Core.Model;
using GuidantHomework.Core.Repositories;
using GuidantHomework.Data.FakeDB;

namespace GuidantHomework.Data.Repositories.Tests
{
    [TestClass()]
    public class UserRepositoryTests
    {
        private readonly UserRepository _repo;

        public UserRepositoryTests()
        {
            _repo = new UserRepository();
        } 
        [TestMethod()]
        public void GetAllTest()
        {
            var results = _repo.GetAll();

            Assert.IsNotNull(results);
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            var userID = 1;
            var user = _repo.GetById(userID);
            Assert.IsNotNull(user);
            Assert.AreEqual(user.ID, userID);
        }

        [TestMethod()]
        public void AddTest()
        {
            db.RefreshTestData();
            var user = new User()
            {
                ID = 7,
                Name = "Test",
                Points = 0
            };
            _repo.Add(user);
            var inserted = _repo.GetById(user.ID);

            Assert.IsNotNull(inserted);
            Assert.AreEqual(inserted.Name, user.Name);
        }
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void AddTestDuplicateIDs()
        {
            db.RefreshTestData();
            var user = new User()
            {
                ID = 7,
                Name = "Test",
                Points = 0
            };
            _repo.Add(user);
            user = new User()
            {
                ID = 7,
                Name = "OtherTest",
                Points = 0
            };
            _repo.Add(user);
        }
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void AddTestDuplicateNames()
        {
            db.RefreshTestData();
            var user = new User()
            {
                ID = 7,
                Name = "Test",
                Points = 0
            };
            _repo.Add(user);
            user = new User()
            {
                ID = 8,
                Name = "Test",
                Points = 0
            };
            _repo.Add(user);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            db.RefreshTestData();
            var userId = 1;
            var name = "NewName";
            var points = 10;

            var user = _repo.GetById(userId);
            user.Name = name;
            user.Points = points;

            _repo.Update(user);
            var updated = _repo.GetById(userId);
            Assert.IsNotNull(updated);
            Assert.AreEqual(updated.Name, user.Name);
            Assert.AreEqual(updated.Points, user.Points);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            db.RefreshTestData();
            var userId = 1;
            var user = _repo.GetById(userId);
            _repo.Delete(user);
            Assert.IsTrue(db.Users.All(u => u.ID != userId));
        }
    }
}
