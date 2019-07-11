using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KarnalTravel.Controllers
{
    public class AdminController : Controller
    {
        KarnalTravelEntities db = new KarnalTravelEntities();
        // GET: Admin
        public ActionResult Index()
        {
            string x = null;
            if (Session["usertype"] != null)
            {
                x = Session["usertype"].ToString();
            }
            if (Session["usertype"] != null && x == "1")
            {

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }


        }
        
        public ActionResult feedbackview()
        {
            var feedback = db.Feedbacks.ToList();
            return View(feedback);


        }
        public ActionResult Contactrequest()
        {
            var vew = db.ContactUs.ToList();
            return View(vew);
        }
        public ActionResult ViewUsers()
        {

            var d = db.Users.ToList();

            return View(d);
        }

    }
}