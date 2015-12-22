using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCalendar.Models
{
    public class LoginViewmodel
    {
        public bool IsUserRegistered(string username, string password)
        {
            UserDatabaseEntities db = new UserDatabaseEntities();
            var user = db.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                return true;
            }
            else {
                return false;
            }


        }
    }
}

