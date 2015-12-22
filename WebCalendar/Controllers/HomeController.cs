using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCalendar.Models;
using System.Web.Security;

namespace WebCalendar.Controllers
{
    public class HomeController : Controller
    {
        LoginViewmodel model = new LoginViewmodel();

        // GET: Home
        public ActionResult Index()
        {
            if(TempData["errorMessage"] != null)
            ViewBag.Error = TempData["errorMessage"].ToString();
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (model.IsUserRegistered(username, password))
            {
                FormsAuthentication.SetAuthCookie(username, false);
                return RedirectToAction("index", "Calendar");
            }
            else
            {
                TempData["errorMessage"] = "Användaren finns inte registrerad";
                return RedirectToAction("Index","Home");
            }
                
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                using (UserDatabaseEntities db = new UserDatabaseEntities())
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    ModelState.Clear();
                    user = null;
                    ViewBag.Message = "Registrering utförd";
                }

            }
            return View();
        }
    }
}