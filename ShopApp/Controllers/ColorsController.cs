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
    public class ColorsController : Controller
    {
        private ShopEntities db = new ShopEntities();

        // GET: Colors
        public ActionResult Index()
        {
            return View(db.tblColors.ToList());
        }

        // GET: Colors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblColor tblColor = db.tblColors.Find(id);
            if (tblColor == null)
            {
                return HttpNotFound();
            }
            return View(tblColor);
        }

        // GET: Colors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Colors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ColorId,Color")] tblColor tblColor)
        {
            if (ModelState.IsValid)
            {
                db.tblColors.Add(tblColor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblColor);
        }

        // GET: Colors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblColor tblColor = db.tblColors.Find(id);
            if (tblColor == null)
            {
                return HttpNotFound();
            }
            return View(tblColor);
        }

        // POST: Colors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ColorId,Color")] tblColor tblColor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblColor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblColor);
        }

        // GET: Colors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblColor tblColor = db.tblColors.Find(id);
            if (tblColor == null)
            {
                return HttpNotFound();
            }
            return View(tblColor);
        }

        // POST: Colors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblColor tblColor = db.tblColors.Find(id);
            db.tblColors.Remove(tblColor);
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
