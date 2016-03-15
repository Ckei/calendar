using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebCalendar.Models;

namespace WebCalendar.Business
{
    public class DatabaseExtensions
    {
        UserDatabaseEntities db = new UserDatabaseEntities();

        public bool AppointmentExists(string date,string username)
        {
            var currentUser = db.Users.FirstOrDefault(u => u.Username == username);
            int userID = currentUser.UserId;
            bool appointmentExists = db.Appointments.Any(o => o.AppointmentDate == date && o.UserId == userID);

            if (appointmentExists)
                return true;
            else
                return false;
        }

        public User GetCurrentUser(string username)
        {
            return db.Users.FirstOrDefault(u => u.Username == username);
        }

        public IEnumerable<UserMessages> Messages(string date, User user)
        {
            List<UserMessages> messages = new List<UserMessages>();
            var AllMessages = db.Appointments.Where(u => u.UserId == user.UserId && u.AppointmentDate == date);

            foreach (var message in AllMessages)
            {
                messages.Add(new UserMessages(message.AppointmentDate,message.AppointmentMessage));
            }
           
            return messages;
        }
    }
}