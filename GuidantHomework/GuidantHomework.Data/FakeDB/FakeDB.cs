using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuidantHomework.Core.Model;

namespace GuidantHomework.Data.FakeDB
{
    public static class FakeDB
    {
        //Normally would be using a db, but this makes sense to distribute with the project
        //Especially when the sql would be so simple
        public static List<User> Users { get; set; }

        static FakeDB()
        {
            //This is just used to populate our data store for testing purposes
            Users = PopulateForTest();
        }

        private static List<User> PopulateForTest()
        {
            var collection = new[]
            {
                new User()
                {
                    ID = 1,
                    Name = "Bill",
                    Points = 0
                },
                new User()
                {
                    ID = 2,
                    Name = "Ted",
                    Points = 1
                },
                new User()
                {
                    ID = 3,
                    Name = "Carlin",
                    Points = 100
                },
                new User()
                {
                    ID = 4,
                    Name = "Foo",
                    Points = 0
                },
                new User()
                {
                    ID = 5,
                    Name = "Bar",
                    Points = 0
                }

            };

            return collection.ToList();
        }
    }
}
