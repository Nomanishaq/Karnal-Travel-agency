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
    public class TouristSpotsController : Controller
    {
        private KarnalTravelEntities db = new KarnalTravelEntities();

        // GET: TouristSpots
        public ActionResult Index()
        {
            var touristSpots = db.TouristSpots.Include(t => t.Country);
            return View(touristSpots.ToList());
        }

        // GET: TouristSpots/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TouristSpot touristSpot = db.TouristSpots.Find(id);
            if (touristSpot == null)
            {
                return HttpNotFound();
            }
            return View(touristSpot);
        }

        // GET: TouristSpots/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = db.Countries.ToList();
            return View();
        }

        // POST: TouristSpots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public ActionResult Create(FormCollection fc, HttpPostedFileBase file)
        {
            TouristSpot t = new TouristSpot();

            if (ModelState.IsValid)
            {

                // string filename = Path.GetFileName(file.FileName);

                t.Name = Request.Form["Name"];
                t.Details = Request.Form["Detail"];
                t.CountryId = Convert.ToInt32(Request.Form["country"]);

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
                            t.Photo = fn + ex;
                        }
                    }
                    string pathRename = Path.Combine("~/Uploading/" + pt + ex);
                    t.Photo = pt + ex;
                    file.SaveAs(Server.MapPath(pathRename));
                }
                else
                {
                    file.SaveAs(@"E:\KarnalTravel\KarnalTravel\Uploading\" + pt + ex);
                    t.Photo = pt + ex;
                }

            }
            db.TouristSpots.Add(t);
            db.SaveChanges();
            ViewBag.CountryId = db.Countries.ToList();
            return View(t);

        }

        // GET: TouristSpots/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TouristSpot touristSpot = db.TouristSpots.Find(id);
            if (touristSpot == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryId = db.Countries.ToList();
            return View(touristSpot);
        }

        // POST: TouristSpots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit(FormCollection fc, HttpPostedFileBase file)
        {
            TouristSpot touristSpot = new TouristSpot();
            if (ModelState.IsValid)
            {
                touristSpot.Id = Convert.ToInt32(Request.Form["id"]);
                touristSpot.Name = Request.Form["Name"];
                touristSpot.Details = Request.Form["Detail"];
                touristSpot.CountryId = Convert.ToInt32(Request.Form["country"]);


                if (file == null)
                {
                    touristSpot.Photo = Request.Form["fileName"];
                }
                else
                {
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
                                touristSpot.Photo = fn + ex;
                            }
                        }
                        string pathRename = Path.Combine("~/Uploading/" + pt + ex);
                        touristSpot.Photo = pt + ex;
                        file.SaveAs(Server.MapPath(pathRename));
                    }
                    else
                    {
                        file.SaveAs(@"E:\KarnalTravel\KarnalTravel\Uploading\" + pt + ex);
                        touristSpot.Photo = pt + ex;
                    }
                    //---------------------------------------------
                }

                db.Entry(touristSpot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", touristSpot.CountryId);
            return View(touristSpot);
        }

        // GET: TouristSpots/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TouristSpot touristSpot = db.TouristSpots.Find(id);
            if (touristSpot == null)
            {
                return HttpNotFound();
            }
            return View(touristSpot);
        }

        // POST: TouristSpots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TouristSpot touristSpot = db.TouristSpots.Find(id);
            var touristspot = db.ToristspotImages.Where(r => r.Touristspotid == touristSpot.Id);
            db.ToristspotImages.RemoveRange(touristspot);
           
            db.TouristSpots.Remove(touristSpot);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Image(int? id)
        {

            TouristSpot r = db.TouristSpots.Find(id);
            ViewBag.rname = r.Name;
            ViewBag.rid = id;

            ViewBag.ImgList = db.ToristspotImages.Where(x => x.Touristspotid == r.Id).ToList();

            return View();
        }
        [HttpPost]
        public ActionResult Image(FormCollection fc, HttpPostedFileBase file)
        {
            int id = Convert.ToInt32(Request.Form["rid"]);
            TouristSpot r = db.TouristSpots.Find(id);
            ViewBag.rname = r.Name;
            ViewBag.rid = r.Id;

            ViewBag.ImgList = db.ToristspotImages.Where(x => x.Touristspotid == r.Id).ToList();



            ToristspotImage Toristspot = new ToristspotImage();

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
                       Toristspot.imgurl = fn + ex;
                    }
                }
                string pathRename = Path.Combine("~/Uploading/" + pt + ex);
                Toristspot.imgurl = pt + ex;
                file.SaveAs(Server.MapPath(pathRename));
            }
            else
            {
                file.SaveAs(@"E:\KarnalTravel\KarnalTravel\Uploading\" + pt + ex);
                Toristspot.imgurl = pt + ex;
            }
            //-------------

            Toristspot.Touristspotid = Convert.ToInt32(Request.Form["rid"]);

            db.ToristspotImages.Add(Toristspot);
            db.SaveChanges();
            return RedirectToAction("Image", new { id = Toristspot.Touristspotid });
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
