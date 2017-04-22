using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using System.IO;

namespace Irancarbook.Areas.Admin.Controllers
{
    public class MaghalehsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Admin/Maghalehs
        public ActionResult Index()
        {
            var maghaleh = db.Maghaleh.Include(m => m.MaghalehGroup);
            return View(maghaleh.ToList());
        }

        // GET: Admin/Maghalehs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maghaleh maghaleh = db.Maghaleh.Find(id);
            if (maghaleh == null)
            {
                return HttpNotFound();
            }
            return View(maghaleh);
        }

        // GET: Admin/Maghalehs/Create
        public ActionResult Create()
        {
            ViewBag.MaghId = new SelectList(db.MaghalehGroup, "MaghId", "Name");
            return View();
        }

        // POST: Admin/Maghalehs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Maghaleh maghaleh, HttpPostedFileBase MyPic, HttpPostedFileBase MyFile)
        {
            if (ModelState.IsValid)
            {
                string ImageName = "no-photo.jpg";
                string filename = "";
                if (MyPic != null)
                {
                    ImageName = MyPic.FileName;
                    MyPic.SaveAs(Server.MapPath("/Content/MaghalehImage/" + ImageName));

                }
                if (MyFile != null)
                {
                    filename = MyFile.FileName;
                    MyFile.SaveAs(Server.MapPath("/Content/MaghalehImage/mfile/" + filename));

                }
                maghaleh.FileName = filename;
                maghaleh.ImageName = ImageName;
                maghaleh.Tarikh = DateTime.Now;
                maghaleh.Position = 0;
                db.Maghaleh.Add(maghaleh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaghId = new SelectList(db.MaghalehGroup, "MaghId", "Name", maghaleh.MaghId);
            return View(maghaleh);
        }

        // GET: Admin/Maghalehs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maghaleh maghaleh = db.Maghaleh.Find(id);
            if (maghaleh == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaghId = new SelectList(db.MaghalehGroup, "MaghId", "Name", maghaleh.MaghId);
            return View(maghaleh);
        }

        // POST: Admin/Maghalehs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ImageName,FileName,Content,Tarikh,writer,Position,MaghId")] Maghaleh maghaleh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maghaleh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaghId = new SelectList(db.MaghalehGroup, "MaghId", "Name", maghaleh.MaghId);
            return View(maghaleh);
        }

        // GET: Admin/Maghalehs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maghaleh maghaleh = db.Maghaleh.Find(id);
            if (maghaleh == null)
            {
                return HttpNotFound();
            }
            return View(maghaleh);
        }

        // POST: Admin/Maghalehs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Maghaleh maghaleh = db.Maghaleh.Find(id);
            db.Maghaleh.Remove(maghaleh);
            db.SaveChanges();
            return RedirectToAction("Index");
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
