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
    public class TransportionsController : Controller
    {
        private KarnalTravelEntities db = new KarnalTravelEntities();

        // GET: Transportions
        public ActionResult Index()
        {
            var transportions = db.Transportions.Include(t => t.Country);
            return View(transportions.ToList());
        }

        // GET: Transportions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transportion transportion = db.Transportions.Find(id);
            if (transportion == null)
            {
                return HttpNotFound();
            }
            return View(transportion);
        }

        // GET: Transportions/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = db.Countries.ToList(); 
            return View();
        }

        // POST: Transportions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public ActionResult Create(FormCollection fc, HttpPostedFileBase file)
        {
            Transportion tr = new Transportion();
               
            if (ModelState.IsValid)
            {
                // string filename = Path.GetFileName(file.FileName);

                tr.BussName = Request.Form["Name"];
                tr.Details = Request.Form["Detail"];
                tr.Price = Request.Form["price"];
                tr.CountryId = Convert.ToInt32(Request.Form["country"]);

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
                            tr.Photo = fn + ex;
                        }
                    }
                    string pathRename = Path.Combine("~/Uploading/" + pt + ex);
                    tr.Photo = pt + ex;
                    file.SaveAs(Server.MapPath(pathRename));
                }
                else
                {
                    file.SaveAs(@"E:\KarnalTravel\KarnalTravel\Uploading\" + pt + ex);
                    tr.Photo = pt + ex;
                }

            }
            db.Transportions.Add(tr);
            db.SaveChanges();
            ViewBag.CountryId = db.Countries.ToList();
            return View(tr);

                  }

        // GET: Transportions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transportion transportion = db.Transportions.Find(id);
            if (transportion == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryId = db.Countries.ToList();
            return View(transportion);
        }

        // POST: Transportions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public ActionResult Edit(FormCollection fc, HttpPostedFileBase file)
        {
            Transportion transport = new Transportion();
            if (ModelState.IsValid)
            {
                transport.Id = Convert.ToInt32(Request.Form["id"]);
                transport.BussName = Request.Form["Name"];
                transport.Details = Request.Form["Detail"];
                transport.Price = Request.Form["price"];
                transport.CountryId = Convert.ToInt32(Request.Form["country"]);


                if (file == null)
                {
                    transport.Photo = Request.Form["fileName"];
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
                                transport.Photo = fn + ex;
                            }
                        }
                        string pathRename = Path.Combine("~/Uploading/" + pt + ex);
                        transport.Photo = pt + ex;
                        file.SaveAs(Server.MapPath(pathRename));
                    }
                    else
                    {
                        file.SaveAs(@"E:\KarnalTravel\KarnalTravel\Uploading\" + pt + ex);
                        transport.Photo = pt + ex;
                    }
                    //---------------------------------------------
                }

                db.Entry(transport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", transport.CountryId);
            return View(transport);
           
        }

        // GET: Transportions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transportion transportion = db.Transportions.Find(id);
            if (transportion == null)
            {
                return HttpNotFound();
            }
            return View(transportion);
        }

        // POST: Transportions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transportion transportion = db.Transportions.Find(id);
         
            var transport = db.TransportImages.Where(r => r.TransportId == transportion.Id);
            db.TransportImages.RemoveRange(transport);
           
            db.Transportions.Remove(transportion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Image(int? id)
        {

            Transportion r = db.Transportions.Find(id);
            ViewBag.rname = r.BussName;
            ViewBag.rid = id;

            ViewBag.ImgList = db.TransportImages.Where(x => x.TransportId == r.Id).ToList();

            return View();
        }
        [HttpPost]
        public ActionResult Image(FormCollection fc, HttpPostedFileBase file)
        {
            int id = Convert.ToInt32(Request.Form["rid"]);
            Transportion r = db.Transportions.Find(id);
            ViewBag.rname = r.BussName;
            ViewBag.rid = r.Id;

            ViewBag.ImgList = db.TransportImages.Where(x => x.TransportId == r.Id).ToList();



            TransportImage transport = new TransportImage();

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
                        transport.ImageUrl = fn + ex;
                    }
                }
                string pathRename = Path.Combine("~/Uploading/" + pt + ex);
                transport.ImageUrl = pt + ex;
                file.SaveAs(Server.MapPath(pathRename));
            }
            else
            {
                file.SaveAs(@"E:\KarnalTravel\KarnalTravel\Uploading\" + pt + ex);
                transport.ImageUrl = pt + ex;
            }
            //-------------

            transport.TransportId = Convert.ToInt32(Request.Form["rid"]);

            db.TransportImages.Add(transport);
            db.SaveChanges();
            return RedirectToAction("Image", new { id = transport.TransportId });
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
