using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShopApp.Models;

namespace ShopApp.Controllers
{
    public class StoragesController : Controller
    {
        private ShopEntities db = new ShopEntities();

        // GET: Storages
        public ActionResult Index()
        {
            return View(db.tblStorages.ToList());
        }

        // GET: Storages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStorage tblStorage = db.tblStorages.Find(id);
            if (tblStorage == null)
            {
                return HttpNotFound();
            }
            return View(tblStorage);
        }

        // GET: Storages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Storages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StorageId,Storage")] tblStorage tblStorage)
        {
            if (ModelState.IsValid)
            {
                db.tblStorages.Add(tblStorage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblStorage);
        }

        // GET: Storages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStorage tblStorage = db.tblStorages.Find(id);
            if (tblStorage == null)
            {
                return HttpNotFound();
            }
            return View(tblStorage);
        }

        // POST: Storages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StorageId,Storage")] tblStorage tblStorage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblStorage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblStorage);
        }

        // GET: Storages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStorage tblStorage = db.tblStorages.Find(id);
            if (tblStorage == null)
            {
                return HttpNotFound();
            }
            return View(tblStorage);
        }

        // POST: Storages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblStorage tblStorage = db.tblStorages.Find(id);
            db.tblStorages.Remove(tblStorage);
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
