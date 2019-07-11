using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KarnalTravel;
using System.IO;

namespace KarnalTravel.Controllers
{
    public class HotelsController : Controller
    {
        private KarnalTravelEntities db = new KarnalTravelEntities();

        // GET: Hotels
        public ActionResult Index()
        {
            var hotels = db.Hotels.Include(h => h.Country);
            return View(hotels.ToList());
        }

        // GET: Hotels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel hotel = db.Hotels.Find(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View(hotel);
        }

        // GET: Hotels/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = db.Countries.ToList();
            return View();
        }

        // POST: Hotels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public ActionResult Create(FormCollection fc, HttpPostedFileBase file)
        {
            Hotel h = new Hotel();

            if (ModelState.IsValid)
            {

                // string filename = Path.GetFileName(file.FileName);

                h.Name = Request.Form["Name"];
                h.Details = Request.Form["Detail"];
                h.RoomPrice =Convert.ToInt32( Request.Form["roomprice"]);
                h.CountryId = Convert.ToInt32(Request.Form["country"]);
                h.PercentDiscount = Convert.ToInt32( Request.Form["discount"]);

                int count = 2;
                string pt = Path.GetFileNameWithoutExtension(file.FileName);
                string ex = Path.GetExtension(file.FileName);
                string xx = pt + ex;
                //  string FleName = pt + "." + ex;
                // var z = db.tblImgs.Where(x => x.imgUrl == pt + "%**%"+ ex).ToList();

                //Check If file exist or not
                if (System.IO.File.Exists(@"E:\KarnalTravel\KarnalTravel\Uploading\" + pt + ex))
                {
                    int ii = 2;
                    bool x = true;
                    while (x)
                    {
                        string fn = pt + "(" + ii + ")";
                        if (System.IO.File.Exists(@"E:\KarnalTravel\KarnalTravel\Uploading\" + fn + ex))
                        {
                            ii++;
                        }
                        else
                        {
                            x = false;
                            pt = fn;
                            count = ii;
                            h.Photo = fn + ex;
                        }
                    }
                    string pathRename = Path.Combine("~/Uploading/" + pt + ex);
                    h.Photo = pt + ex;
                    file.SaveAs(Server.MapPath(pathRename));
                }
                else
                {
                    file.SaveAs(@"E:\KarnalTravel\KarnalTravel\Uploading\" + pt + ex);
                    h.Photo = pt + ex;
                }

            }
            db.Hotels.Add(h);
            db.SaveChanges();
            ViewBag.CountryId = db.Countries.ToList();
            return View(h);
        }

        // GET: Hotels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel hotel = db.Hotels.Find(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryId = db.Countries.ToList();
            return View(hotel);
        }

        // POST: Hotels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit(FormCollection fc, HttpPostedFileBase file)
        {
            Hotel hotel = new Hotel();
            if (ModelState.IsValid)
            {
                hotel.Id = Convert.ToInt32(Request.Form["id"]);
                hotel.Name = Request.Form["Name"];
                hotel.RoomPrice = Convert.ToInt16(Request.Form["price"]);
                hotel.PercentDiscount =Convert.ToInt16(Request.Form["discount"]);
                hotel.Details = Request.Form["Detail"];
                hotel.CountryId = Convert.ToInt32(Request.Form["country"]);


                if (file == null)
                {
                    hotel.Photo = Request.Form["fileName"];
                }
                else {
                    //-------------------------------------------------
                    int count = 2;
                    string pt = Path.GetFileNameWithoutExtension(file.FileName);
                    string ex = Path.GetExtension(file.FileName);
                    string xx = pt + ex;
                    //  string FleName = pt + "." + ex;
                    // var z = db.tblImgs.Where(x => x.imgUrl == pt + "%**%"+ ex).ToList();

                    //Check If file exist or not
                    if (System.IO.File.Exists(@"E:\KarnalTravel\KarnalTravel\Uploading\" + pt + ex))
                    {
                        int ii = 2;
                        bool x = true;
                        while (x)
                        {
                            string fn = pt + "(" + ii + ")";
                            if (System.IO.File.Exists(@"E:\KarnalTravel\KarnalTravel\Uploading\" + fn + ex))
                            {
                                ii++;
                            }
                            else
                            {
                                x = false;
                                pt = fn;
                                count = ii;
                                hotel.Photo = fn + ex;
                            }
                        }
                        string pathRename = Path.Combine("~/Uploading/" + pt + ex);
                        hotel.Photo = pt + ex;
                        file.SaveAs(Server.MapPath(pathRename));
                    }
                    else
                    {
                        file.SaveAs(@"E:\KarnalTravel\KarnalTravel\Uploading\" + pt + ex);
                        hotel.Photo = pt + ex;
                    }
//---------------------------------------------
                }

                db.Entry(hotel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", hotel.CountryId);
            return View(hotel);
            }

        // GET: Hotels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel hotel = db.Hotels.Find(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View(hotel);
        }

        // POST: Hotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hotel hotel = db.Hotels.Find(id);
            
            var hotal = db.HotelImages.Where(r => r.HotelId == hotel.Id);
            db.HotelImages.RemoveRange(hotal);
           
         
            db.Hotels.Remove(hotel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Image(int? id)
        {

            Hotel r = db.Hotels.Find(id);
            ViewBag.rname = r.Name;
            ViewBag.rid = id;

            ViewBag.ImgList = db.HotelImages.Where(x => x.HotelId == r.Id).ToList();

            return View();
        }
        [HttpPost]
        public ActionResult Image(FormCollection fc, HttpPostedFileBase file)
        {
            int id = Convert.ToInt32(Request.Form["rid"]);
            Hotel r = db.Hotels.Find(id);
            ViewBag.rname = r.Name;
            ViewBag.rid = r.Id;

            ViewBag.ImgList = db.HotelImages.Where(x => x.HotelId == r.Id).ToList();



            HotelImage hotel = new HotelImage();

            int count = 2;
            string pt = Path.GetFileNameWithoutExtension(file.FileName);
            string ex = Path.GetExtension(file.FileName);
            string xx = pt + ex;
            //  string FleName = pt + "." + ex;
            // var z = db.tblImgs.Where(x => x.imgUrl == pt + "%**%"+ ex).ToList();

            //Check If file exist or not
            if (System.IO.File.Exists(@"E:\KarnalTravel\KarnalTravel\Uploading\" + pt + ex))
            {
                int ii = 2;
                bool x = true;
                while (x)
                {
                    string fn = pt + "(" + ii + ")";
                    if (System.IO.File.Exists(@"E:\KarnalTravel\KarnalTravel\Uploading\" + fn + ex))
                    {
                        ii++;
                    }
                    else
                    {
                        x = false;
                        pt = fn;
                        count = ii;
                        hotel.ImageUrl = fn + ex;
                    }
                }
                string pathRename = Path.Combine("~/Uploading/" + pt + ex);
                hotel.ImageUrl = pt + ex;
                file.SaveAs(Server.MapPath(pathRename));
            }
            else
            {
                file.SaveAs(@"E:\KarnalTravel\KarnalTravel\Uploading\" + pt + ex);
                hotel.ImageUrl = pt + ex;
            }
            //-------------

            hotel.HotelId = Convert.ToInt32(Request.Form["rid"]);

            db.HotelImages.Add(hotel);
            db.SaveChanges();
            return RedirectToAction("Image", new { id = hotel.HotelId });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
