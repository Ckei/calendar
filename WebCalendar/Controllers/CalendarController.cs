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
        public ActionResult Appointment(Appointment app, string appButton)
        {        
            User user = dbe.GetCurrentUser(User.Identity.Name);

                    if (ModelState.IsValid)
                    {
                        using (UserDatabaseEntities db = new UserDatabaseEntities())
                        {
                            if (appButton == "Create" && !dbe.AppointmentExists(app.AppointmentDate, user.Username))
                            {
                                app.UserId = user.UserId;
                                db.Appointments.Add(app);
                                db.SaveChanges();
                            }
                            else {

                                    
                                
                                Appointment appoint = new Appointment();
                                appoint = db.Appointments.Find(dbe.GetAppointmentIDByDate(app.AppointmentDate,user));
                        db.Appointments.Attach(appoint);
                                db.Entry(appoint).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                        }
                    }

            return View("Index",model);
        }

        public ActionResult GetUserMessage(string selectDate)
        {
            return Json(dbe.Messages(selectDate, dbe.GetCurrentUser(User.Identity.Name)));
        }
    }
}