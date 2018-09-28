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
    public class GeneralNewsController : Controller
    {
        private ShopEntities db = new ShopEntities();

        // GET: GeneralNews
        public ActionResult Index()
        {
            var tblNews = db.tblNews.Include(t => t.tblUser);
            return View(tblNews.ToList());
        }

        // GET: GeneralNews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblNew tblNew = db.tblNews.Find(id);
            if (tblNew == null)
            {
                return HttpNotFound();
            }
            return View(tblNew);
        }

        // GET: GeneralNews/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.tblUsers, "UserId", "Username");
            return View();
        }

        // POST: GeneralNews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NewsId,UserId,Title,ShortDescription,Image,Content,CreatedDate,Status")] tblNew tblNew)
        {
            if (ModelState.IsValid)
            {
                db.tblNews.Add(tblNew);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.tblUsers, "UserId", "Username", tblNew.UserId);
            return View(tblNew);
        }

        // GET: GeneralNews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblNew tblNew = db.tblNews.Find(id);
            if (tblNew == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.tblUsers, "UserId", "Username", tblNew.UserId);
            return View(tblNew);
        }

        // POST: GeneralNews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NewsId,UserId,Title,ShortDescription,Image,Content,CreatedDate,Status")] tblNew tblNew)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblNew).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.tblUsers, "UserId", "Username", tblNew.UserId);
            return View(tblNew);
        }

        // GET: GeneralNews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblNew tblNew = db.tblNews.Find(id);
            if (tblNew == null)
            {
                return HttpNotFound();
            }
            return View(tblNew);
        }

        // POST: GeneralNews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblNew tblNew = db.tblNews.Find(id);
            db.tblNews.Remove(tblNew);
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
