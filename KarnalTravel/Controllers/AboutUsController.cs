using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using KarnalTravel;

namespace KarnalTravel.Controllers
{
    public class AboutUsController : Controller
    {
        KarnalTravelEntities db = new KarnalTravelEntities();
        // GET: AboutUs
        public ActionResult Index()
        {
            ViewBag.Touristspot = db.TouristSpots.Include(t => t.Country).ToList();
            ViewBag.restaurents = db.Resturants.Include(t => t.Country).ToList();
            ViewBag.hotels = db.Hotels.Include(t => t.Country).ToList();
            ViewBag.Resorts = db.Resorts_.Include(t => t.Country).ToList();
            ViewBag.Transport = db.Transportions.Include(t => t.Country).ToList();
        
            return View();
        }
    }
}