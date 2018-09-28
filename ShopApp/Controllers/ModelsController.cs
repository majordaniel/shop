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
    public class ModelsController : Controller
    {
        private ShopEntities db = new ShopEntities();

        // GET: Models
        public ActionResult Index()
        {
            return View(db.tblModels.ToList());
        }

        // GET: Models/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblModel tblModel = db.tblModels.Find(id);
            if (tblModel == null)
            {
                return HttpNotFound();
            }
            return View(tblModel);
        }

        // GET: Models/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Models/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ModelId,Model")] tblModel tblModel)
        {
            if (ModelState.IsValid)
            {
                db.tblModels.Add(tblModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblModel);
        }

        // GET: Models/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblModel tblModel = db.tblModels.Find(id);
            if (tblModel == null)
            {
                return HttpNotFound();
            }
            return View(tblModel);
        }

        // POST: Models/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ModelId,Model")] tblModel tblModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblModel);
        }

        // GET: Models/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblModel tblModel = db.tblModels.Find(id);
            if (tblModel == null)
            {
                return HttpNotFound();
            }
            return View(tblModel);
        }

        // POST: Models/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblModel tblModel = db.tblModels.Find(id);
            db.tblModels.Remove(tblModel);
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
