using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KarnalTravel.Controllers
{
    public class ContactController : Controller
    {
        KarnalTravelEntities db = new KarnalTravelEntities();
       // GET: Contant
        public ActionResult Index()
        {
            string x = null;
            if (Session["usertype"] != null)
            {
                x = Session["usertype"].ToString();
            }
            if (Session["usertype"] != null && x == "2")
            {

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

           
        }
        [HttpPost]
        public ActionResult Index(string name, string email, string phone ,string messgae, string audlts, string kids, string date)
        {
            var user = new ContactU();

            user.Name = name;
            user.Email = email;
            user.Phone = phone;
            user.Audlts = audlts;
            user.Kids = kids;
            user.Date = date;
            user.Message = messgae;


            db.ContactUs.Add(user);
            db.SaveChanges();
            ViewBag.Message = "Your Message has been sent Sucessfully";
            return View();
        }

        public ActionResult Feedback()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Feedback(string name, string lastname, string email, string phone, string answer1, string answer2, string answer3, string answer4)
        {
            var feed = new Feedback();
            feed.Name = name;
            feed.LastName = lastname;
            feed.Email = email;
            feed.Phone = phone;
            feed.Answer1 = answer1;
            feed.Answer2 = answer2;
            feed.Answer3 = answer3;
            feed.Answer4 = answer4;

            db.Feedbacks.Add(feed);
            db.SaveChanges();

           return RedirectToAction("Index");
        }
       
     
    }

    }
