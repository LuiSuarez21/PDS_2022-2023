using BuildMe.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildMe.Test.FakeData
{
    public static class FakeUserData
    {
        public static List<User> GetAllUsers = new List<User>()
        {
                new User { Id = 1, UserName = "Name1", Password = "123" },
                new User { Id = 2, UserName = "Name2", Password = "123" },
                new User { Id = 3, UserName = "Name3", Password = "123" }
        };
    }
}
