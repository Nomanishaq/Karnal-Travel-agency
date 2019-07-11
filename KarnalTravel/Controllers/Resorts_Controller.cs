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
    public class Resorts_Controller : Controller
    {
        private KarnalTravelEntities db = new KarnalTravelEntities();

        // GET: Resorts_
        public ActionResult Index()
        {
            var resorts_ = db.Resorts_.Include(r => r.Country);
            return View(resorts_.ToList());
        }

        // GET: Resorts_/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resorts_ resorts_ = db.Resorts_.Find(id);
            if (resorts_ == null)
            {
                return HttpNotFound();
            }
            return View(resorts_);
        }

        // GET: Resorts_/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = db.Countries.ToList();
            return View();
        }

        // POST: Resorts_/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public ActionResult Create(FormCollection fc, HttpPostedFileBase file)
        {
            Resorts_ r = new Resorts_();

            if (ModelState.IsValid)
            {

                // string filename = Path.GetFileName(file.FileName);

                r.Name = Request.Form["Name"];
                r.Details = Request.Form["Detail"];
                r.Location = Request.Form["location"];
                r.RoomPrice =Convert.ToInt32(Request.Form["room"]);
                r.PercentDiscount =Convert.ToInt32(Request.Form["discount"]);
                r.CountryId = Convert.ToInt32(Request.Form["country"]);

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
                            r.Photo = fn + ex;
                        }
                    }
                    string pathRename = Path.Combine("~/Uploading/" + pt + ex);
                    r.Photo = pt + ex;
                    file.SaveAs(Server.MapPath(pathRename));
                }
                else
                {
                    file.SaveAs(@"E:\KarnalTravel\KarnalTravel\Uploading\" + pt + ex);
                    r.Photo = pt + ex;
                }

            }
            db.Resorts_.Add(r);
            db.SaveChanges();
            ViewBag.CountryId = db.Countries.ToList();
            return View(r);
        }

        // GET: Resorts_/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resorts_ resorts_ = db.Resorts_.Find(id);
            if (resorts_ == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryId = db.Countries.ToList();
            return View(resorts_);
        }

        // POST: Resorts_/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public ActionResult Edit(FormCollection fc, HttpPostedFileBase file)
        {
            Resorts_ resort = new Resorts_();
            if (ModelState.IsValid)
            {
                resort.Id = Convert.ToInt32(Request.Form["id"]);
                resort.Name = Request.Form["Name"];
                resort.Details = Request.Form["Detail"];
                resort.Location = Request.Form["location"];
                resort.RoomPrice = Convert.ToInt32(Request.Form["room"]);
                resort.PercentDiscount = Convert.ToInt32(Request.Form["discount"]);
                resort.CountryId = Convert.ToInt32(Request.Form["country"]);


                if (file == null)
                {
                    resort.Photo = Request.Form["fileName"];
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
                                resort.Photo = fn + ex;
                            }
                        }
                        string pathRename = Path.Combine("~/Uploading/" + pt + ex);
                        resort.Photo = pt + ex;
                        file.SaveAs(Server.MapPath(pathRename));
                    }
                    else
                    {
                        file.SaveAs(@"E:\KarnalTravel\KarnalTravel\Uploading\" + pt + ex);
                        resort.Photo = pt + ex;
                    }
                    //---------------------------------------------
                }

                db.Entry(resort).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", resort.CountryId);
            return View(resort);
        }

        // GET: Resorts_/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resorts_ resorts_ = db.Resorts_.Find(id);
            if (resorts_ == null)
            {
                return HttpNotFound();
            }
            return View(resorts_);
        }

        // POST: Resorts_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resorts_ resorts_ = db.Resorts_.Find(id);

            var resortimages = db.ResortImages.Where(r => r.ResortId == resorts_.Id);
            db.ResortImages.RemoveRange(resortimages);
            db.Resorts_.Remove(resorts_);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Image(int? id)
        {

            Resorts_ r = db.Resorts_.Find(id);
            ViewBag.rname = r.Name;
            ViewBag.rid = id;

            ViewBag.ImgList = db.ResortImages.Where(x => x.ResortId == r.Id).ToList();

            return View();
        }
        [HttpPost]
        public ActionResult Image(FormCollection fc, HttpPostedFileBase file)
        {
            int id = Convert.ToInt32(Request.Form["rid"]);
            Resorts_ r = db.Resorts_.Find(id);
            ViewBag.rname = r.Name;
            ViewBag.rid = r.Id;

            ViewBag.ImgList = db.ResortImages.Where(x => x.ResortId == r.Id).ToList();



            ResortImage resort = new ResortImage();

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
                        resort.ImageUrl = fn + ex;
                    }
                }
                string pathRename = Path.Combine("~/Uploading/" + pt + ex);
                resort.ImageUrl = pt + ex;
                file.SaveAs(Server.MapPath(pathRename));
            }
            else
            {
                file.SaveAs(@"E:\KarnalTravel\KarnalTravel\Uploading\" + pt + ex);
                resort.ImageUrl = pt + ex;
            }
            //-------------

            resort.ResortId = Convert.ToInt32(Request.Form["rid"]);

            db.ResortImages.Add(resort);
            db.SaveChanges();
            return RedirectToAction("Image", new { id = resort.ResortId });
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
