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
    public class CarInfoesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Admin/CarInfoes
        public ActionResult Index()
        {
            return View(db.CarInfo.ToList());
        }

        // GET: Admin/CarInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarInfo carInfo = db.CarInfo.Find(id);
            if (carInfo == null)
            {
                return HttpNotFound();
            }
            return View(carInfo);
        }

        // GET: Admin/CarInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CarInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Comment,Image,Tarikh")] CarInfo carInfo)
        {
            if (ModelState.IsValid)
            {
                db.CarInfo.Add(carInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carInfo);
        }

        // GET: Admin/CarInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarInfo carInfo = db.CarInfo.Find(id);
            if (carInfo == null)
            {
                return HttpNotFound();
            }
            return View(carInfo);
        }

        // POST: Admin/CarInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Comment,Image,Tarikh")] CarInfo carInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carInfo);
        }

        // GET: Admin/CarInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarInfo carInfo = db.CarInfo.Find(id);
            if (carInfo == null)
            {
                return HttpNotFound();
            }
            return View(carInfo);
        }

        // POST: Admin/CarInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarInfo carInfo = db.CarInfo.Find(id);
            db.CarInfo.Remove(carInfo);
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
