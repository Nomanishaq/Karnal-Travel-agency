using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KarnalTravel.Controllers
{
    public class AccountController : Controller
    {
        KarnalTravelEntities db = new KarnalTravelEntities();
        // GET: Account
     
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var user = db.Users.FirstOrDefault(u => u.Email == email
            && u.Password == password
            );

            if (user != null)
            {
                Session["id"] = user.Id;
                Session["usertype"] = user.UserTypeId;
                Session["name"] = user.Name;
                Session["type"] = user.UserType;

                if (user.UserTypeId == 2)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Admin");
                }
            }
            else
            {
                TempData["message"] = "inalid username password Please registar first!" ;
                return RedirectToAction("Registration");

            }
        }




        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(string name, string email, string password)
        {
            var user = new User();

            user.Name = name;
            user.Email = email;
            user.Password = password;
            user.UserTypeId = 2;

            db.Users.Add(user);
            db.SaveChanges();
                   
            return View("Login");
        }
        public ActionResult Logout() 
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }

    }
}