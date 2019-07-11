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
    public class ResturantsController : Controller
    {
        private KarnalTravelEntities db = new KarnalTravelEntities();

        // GET: Resturants
        public ActionResult Index()
        {
            var resturants = db.Resturants.Include(r => r.Country);
            return View(resturants.ToList());
        }

        // GET: Resturants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resturant resturant = db.Resturants.Find(id);
            if (resturant == null)
            {
                return HttpNotFound();
            }
            return View(resturant);
        }

        // GET: Resturants/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = db.Countries.ToList();
            return View();
        }

        // POST: Resturants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
 
        public ActionResult Create(FormCollection fc, HttpPostedFileBase file)
        {
            Resturant r = new Resturant();

            if (ModelState.IsValid)
            {

                // string filename = Path.GetFileName(file.FileName);

                r.Name = Request.Form["Name"];
                r.Details = Request.Form["Detail"];
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
            db.Resturants.Add(r);
            db.SaveChanges();
            ViewBag.CountryId = db.Countries.ToList();
            return View(r);

        }

        // GET: Resturants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resturant resturant = db.Resturants.Find(id);
            if (resturant == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryId = db.Countries.ToList();
            return View(resturant);
        }

        // POST: Resturants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit(FormCollection fc, HttpPostedFileBase file)
        {

            Resturant resturant = new Resturant();
            if (ModelState.IsValid)
            {
                resturant.Id = Convert.ToInt32(Request.Form["id"]);
                resturant.Name = Request.Form["Name"];
                resturant.Details= Request.Form["Detail"];
                resturant.CountryId = Convert.ToInt32(Request.Form["country"]);


                if (file == null)
                {
                    resturant.Photo = Request.Form["fileName"];
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
                                resturant.Photo = fn + ex;
                            }
                        }
                        string pathRename = Path.Combine("~/Uploading/" + pt + ex);
                        resturant.Photo = pt + ex;
                        file.SaveAs(Server.MapPath(pathRename));
                    }
                    else
                    {
                        file.SaveAs(@"E:\KarnalTravel\KarnalTravel\Uploading\" + pt + ex);
                        resturant.Photo = pt + ex;
                    }
//---------------------------------------------
                }
                
                db.Entry(resturant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", resturant.CountryId);
            return View(resturant);
        }

        // GET: Resturants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resturant resturant = db.Resturants.Find(id);
            if (resturant == null)
            {
                return HttpNotFound();
            }
            return View(resturant);
        }

        // POST: Resturants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resturant resturant = db.Resturants.Find(id);


            var restaurantimages = db.ResturantImages.Where(r => r.resturantId == resturant.Id);
            db.ResturantImages.RemoveRange(restaurantimages);

            db.Resturants.Remove(resturant);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Image(int? id) {

            Resturant r = db.Resturants.Find(id);
            ViewBag.rname = r.Name;
            ViewBag.rid = id;

            ViewBag.ImgList =db.ResturantImages.Where(x => x.resturantId == r.Id).ToList() ;

            return View();
        }
        [HttpPost]
        public ActionResult Image(FormCollection fc , HttpPostedFileBase file)
        {
            int id =Convert.ToInt32(Request.Form["rid"]);
            Resturant r = db.Resturants.Find(id);
            ViewBag.rname = r.Name;
            ViewBag.rid = r.Id;

            ViewBag.ImgList = db.ResturantImages.Where(x => x.resturantId == r.Id).ToList();



            ResturantImage resturant = new ResturantImage();

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
                        resturant.imgUrl = fn + ex;
                    }
                }
                string pathRename = Path.Combine("~/Uploading/" + pt + ex);
                resturant.imgUrl = pt + ex;
                file.SaveAs(Server.MapPath(pathRename));
            }
            else
            {
                file.SaveAs(@"E:\KarnalTravel\KarnalTravel\Uploading\" + pt + ex);
                resturant.imgUrl = pt + ex;
            }
            //-------------

            resturant.resturantId = Convert.ToInt32(Request.Form["rid"]);

            db.ResturantImages.Add(resturant);
            db.SaveChanges();
            return RedirectToAction("Image", new { id = resturant.resturantId });
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
