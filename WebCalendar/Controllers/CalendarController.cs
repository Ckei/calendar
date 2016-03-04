using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCalendar.Models;
using WebCalendar.Business;

namespace WebCalendar.Controllers
{
    public class CalendarController : Controller
    {
        DatabaseExtensions dbe = new DatabaseExtensions();
        CalendarViewmodel model = new CalendarViewmodel();

        // GET: Calendar
        [Authorize]
        public ActionResult Index()
        {
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(int month, int year, string direction)
        {
            CalendarViewmodel model = new CalendarViewmodel(direction,month,year);
            return View(model);
        }

        [HttpPost]
        public ActionResult Appointment(string Message, string date)
        {        
            User user = dbe.GetCurrentUser(User.Identity.Name); 
            UserDatabaseEntities db = new UserDatabaseEntities();
            if (!dbe.AppointmentExists(date, user.Username))
            {
                if (ModelState.IsValid)
                {
                    Appointment appointment = new Appointment();

                    appointment.AppointmentDate = date;
                    appointment.AppointmentMessage = Message;
                    appointment.UserId = user.UserId;
                    appointment.User = user;

                    db.Appointments.Add(appointment);
                    db.SaveChanges();
                }
         
            }
            else
            {

            }

            return View("Index",model);
        }
    }
}