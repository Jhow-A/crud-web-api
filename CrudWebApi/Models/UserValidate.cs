using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudWebApi.Models
{
    public class UserValidate
    {
        public static bool Login(string username, string password)
        {
            var UserLists = UsersBL.GetUsers();
            return UserLists.Any(user =>
                user.Username.Equals(username, StringComparison.OrdinalIgnoreCase)
                && user.Password == password);
        }
    }
}