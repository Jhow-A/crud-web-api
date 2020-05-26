using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudWebApi.Models
{
    public class UsersBL
    {
        public static ICollection<User> GetUsers()
        {
            ICollection<User> userList = new List<User>();

            userList.Add(new User()
            {
                Username = "MaleUser",
                Password = "123456"
            });

            userList.Add(new User()
            {
                Username = "FemaleUser",
                Password = "abcdef"
            });

            return userList;
        }
    }
}