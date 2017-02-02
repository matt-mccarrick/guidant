using System;
using System.Linq;
using GuidantHomework.Core.Model;
using GuidantHomework.Core.Services;
using GuidantHomework.Data.Repositories;
using GuidantHomework.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuidantHomework.Tests.Services
{
    [TestClass()]
    public class UserServiceTests
    {
        private readonly IUserService _userService;

        public UserServiceTests()
        {
            _userService = new UserService(new UserRepository());
        }

        [TestMethod()]
        public void GetAllUsersTest()
        {
            var users = _userService.GetAllUsers();
            Assert.IsNotNull(users);
            //Test data generates with 5 values. Sorry about the magic number
            Assert.AreEqual(users.Count(), 5);
        }

        [TestMethod()]
        public void AddUserTest()
        {
            var testUser = new User()
            {
                ID = 7,
                Name = "Test",
                Points = 0
            };
            _userService.AddUser(testUser);
            var user = _userService.GetUser(testUser.ID);

            Assert.IsNotNull(user);
            Assert.AreEqual(testUser.Name, user.Name);
        }

        [TestMethod()]
        public void GetUserTest()
        {
            var userID = 1;
            var user = _userService.GetUser(userID);
            Assert.IsNotNull(user);
            Assert.AreEqual(userID, user.ID);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void GetUserTestInvalidID()
        {
            var userID = -1;
            var user = _userService.GetUser(userID);
        }

        [TestMethod()]
        public void SetPointsTest()
        {
            var userID = 1;
            var points = 5;
            _userService.SetPoints(userID, points);
            var user = _userService.GetUser(userID);

            Assert.IsNotNull(user);
            Assert.AreEqual(user.Points, points);
        }
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void SetPointsTestInvalidID()
        {
            var userID = -1;
            var points = 5;
            _userService.SetPoints(userID, points);
        }
    }
}