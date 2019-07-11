
using System;
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
    public class InformationController : Controller
    {
        KarnalTravelEntities db = new KarnalTravelEntities();
        // GET: Information
        public ActionResult Index()
        {
            ViewBag.Touristspot = db.TouristSpots.Include(t => t.Country).ToList();
            ViewBag.restaurents = db.Resturants.Include(t => t.Country).ToList();
            ViewBag.hotels = db.Hotels.Include(t => t.Country).ToList();
            ViewBag.Resorts = db.Resorts_.Include(t => t.Country).ToList();
            ViewBag.Transport = db.Transportions.Include(t => t.Country).ToList();
            return View();
        }
        public ActionResult Search(string keyword)
        {
            ViewBag.Touristspot = db.TouristSpots.Where(t => t.Name.Contains(keyword)).ToList();
            ViewBag.restaurents = db.Resturants.Where(t => t.Name.Contains(keyword)).ToList();
            ViewBag.hotels = db.Hotels.Where(t => t.Name.Contains(keyword)).ToList();
            ViewBag.Resorts = db.Resorts_.Where(t => t.Name.Contains(keyword)).ToList();
            ViewBag.Transport = db.Transportions.Where(t => t.BussName.Contains(keyword)).ToList();

            return View("Index");
        }

        public ActionResult AdvanceSearch(string keyword, string location, float price, string quality, int quantity, string availability)
        {
            ViewBag.Touristspot = db.TouristSpots.Where(t => t.Name.Contains(keyword) && t.Country.Name.Contains(location)).ToList();
            ViewBag.restaurents = db.Resturants.Where(t => t.Name.Contains(keyword)&& t.Country.Name.Contains(location)).ToList();
            ViewBag.hotels = db.Hotels.Where(t => t.Name.Contains(keyword) && t.RoomPrice.ToString().Contains(location) && t.PercentDiscount.ToString().Contains(location)).ToList();
            ViewBag.Resorts = db.Resorts_.Where(t => t.Name.Contains(keyword) && t.Country.Name.Contains(location) && t.PercentDiscount.ToString().Contains(location)).ToList();
            ViewBag.Transport = db.Transportions.Where(t => t.BussName.Contains(keyword) && t.Country.Name.Contains(location) && t.Country.Name.Contains(location)).ToList();

            return View("Index");
        }


        public ActionResult InformationDetail(int Id, byte infotype)
        {
            Object info = new object();
            switch (infotype)
            {
                case 1:

                    info = db.Resturants.Find(Id);
                    
                    break;

                case 2:
                    info = db.TouristSpots.Find(Id);

                    break;

                case 3:
                    info = db.Hotels.Find(Id);
                    break;

                case 4:
                    info = db.Resorts_.Find(Id);
                    break;

                case 5:
                    info = db.Transportions.Find(Id);
                    break;
            }

            ViewBag.info = info;
            ViewBag.infotype = infotype;
            return View();
        }
    }
}
