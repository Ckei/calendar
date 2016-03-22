using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCalendar.Models;
using WebCalendar.Business;
using System.Data.Entity;

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
        public ActionResult Appointment(Appointment appointment, string appButton)
        {
            //TODO: Skapa en Edit och en Create istället för en if else?
            User user = dbe.GetCurrentUser(User.Identity.Name);

            if (ModelState.IsValid)
            {
                if (model.IsAppointmentTimeFree(appointment, user))
                {
                    using (UserDatabaseEntities db = new UserDatabaseEntities())
                    {
                        if (appButton == "Create")
                        {
                            appointment.UserId = user.UserId;
                            db.Appointments.Add(appointment);
                            db.SaveChanges();
                        }
                        else
                        {
                            Appointment newAppointment = new Appointment();
                            newAppointment = db.Appointments.Find(dbe.GetAppointmentIDByDate(appointment.AppointmentDate, user));
                            newAppointment.AppointmentMessage = appointment.AppointmentMessage;
                            db.Entry(newAppointment).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                }

            }

            return View("Index", model);
        }

        public ActionResult GetUserMessage(string selectDate)
        {
            return Json(dbe.Messages(selectDate, dbe.GetCurrentUser(User.Identity.Name)));
        }
    }
}