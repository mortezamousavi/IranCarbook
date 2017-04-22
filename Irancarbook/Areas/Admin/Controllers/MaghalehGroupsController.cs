using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace Irancarbook.Areas.Admin.Controllers
{
    public class MaghalehGroupsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Admin/MaghalehGroups
        public ActionResult Index()
        {
            return View(db.MaghalehGroup.ToList());
        }

        // GET: Admin/MaghalehGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaghalehGroup maghalehGroup = db.MaghalehGroup.Find(id);
            if (maghalehGroup == null)
            {
                return HttpNotFound();
            }
            return View(maghalehGroup);
        }

        // GET: Admin/MaghalehGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/MaghalehGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaghId,Name")] MaghalehGroup maghalehGroup)
        {
            if (ModelState.IsValid)
            {
                db.MaghalehGroup.Add(maghalehGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(maghalehGroup);
        }

        // GET: Admin/MaghalehGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaghalehGroup maghalehGroup = db.MaghalehGroup.Find(id);
            if (maghalehGroup == null)
            {
                return HttpNotFound();
            }
            return View(maghalehGroup);
        }

        // POST: Admin/MaghalehGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaghId,Name")] MaghalehGroup maghalehGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maghalehGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(maghalehGroup);
        }

        // GET: Admin/MaghalehGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaghalehGroup maghalehGroup = db.MaghalehGroup.Find(id);
            if (maghalehGroup == null)
            {
                return HttpNotFound();
            }
            return View(maghalehGroup);
        }

        // POST: Admin/MaghalehGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MaghalehGroup maghalehGroup = db.MaghalehGroup.Find(id);
            db.MaghalehGroup.Remove(maghalehGroup);
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
