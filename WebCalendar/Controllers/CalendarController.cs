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

        // GET: Calendar
        [Authorize]
        public ActionResult Index()
        {
            CalendarViewmodel model = new CalendarViewmodel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(int month, int year, string direction)
        {

            CalendarViewmodel model = new CalendarViewmodel(direction,month,year);

            return View(model);
        }

        [HttpPost]
        public ActionResult Appointment(string Message, string Date)
        {
            string currentUser = User.Identity.Name; 
            UserDatabaseEntities db = new UserDatabaseEntities();
            if (!dbe.AppointmentExists(Date, currentUser))
            {
                if (ModelState.IsValid)
                {
                    Models.Appointment appointment = new Models.Appointment();

                    appointment.AppointmentDate = Date;
                    appointment.AppointmentMessage = Message;
                    appointment.UserId = dbe.GetUserID(currentUser);

                    db.SaveChanges();
                }
         
            }
            else
            {

            }

            return View("Index");
        }
    }
}