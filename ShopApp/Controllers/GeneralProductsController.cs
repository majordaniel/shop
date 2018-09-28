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
    public class GeneralProductsController : Controller
    {
        private ShopEntities db = new ShopEntities();

        // GET: GeneralProducts
        public ActionResult Index()
        {
            var tblProducts = db.tblProducts.Include(t => t.tblCategory).Include(t => t.tblColor).Include(t => t.tblModel).Include(t => t.tblStorage).Include(t => t.tblUser);
            return View(tblProducts.ToList());
        }

        // GET: GeneralProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProduct tblProduct = db.tblProducts.Find(id);
            if (tblProduct == null)
            {
                return HttpNotFound();
            }
            return View(tblProduct);
        }

        // GET: GeneralProducts/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.tblCategories, "CategoryId", "Name");
            ViewBag.ColorId = new SelectList(db.tblColors, "ColorId", "Color");
            ViewBag.ModelId = new SelectList(db.tblModels, "ModelId", "Model");
            ViewBag.StorageId = new SelectList(db.tblStorages, "StorageId", "Storage");
            ViewBag.UserId = new SelectList(db.tblUsers, "UserId", "Username");
            return View();
        }

        // POST: GeneralProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Image,Price,UserId,CategoryId,ColorId,ModelId,StorageId,SellStartDate,SellEndDate,IsNew")] tblProduct tblProduct)
        {
            if (ModelState.IsValid)
            {
                db.tblProducts.Add(tblProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.tblCategories, "CategoryId", "Name", tblProduct.CategoryId);
            ViewBag.ColorId = new SelectList(db.tblColors, "ColorId", "Color", tblProduct.ColorId);
            ViewBag.ModelId = new SelectList(db.tblModels, "ModelId", "Model", tblProduct.ModelId);
            ViewBag.StorageId = new SelectList(db.tblStorages, "StorageId", "Storage", tblProduct.StorageId);
            ViewBag.UserId = new SelectList(db.tblUsers, "UserId", "Username", tblProduct.UserId);
            return View(tblProduct);
        }

        // GET: GeneralProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProduct tblProduct = db.tblProducts.Find(id);
            if (tblProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.tblCategories, "CategoryId", "Name", tblProduct.CategoryId);
            ViewBag.ColorId = new SelectList(db.tblColors, "ColorId", "Color", tblProduct.ColorId);
            ViewBag.ModelId = new SelectList(db.tblModels, "ModelId", "Model", tblProduct.ModelId);
            ViewBag.StorageId = new SelectList(db.tblStorages, "StorageId", "Storage", tblProduct.StorageId);
            ViewBag.UserId = new SelectList(db.tblUsers, "UserId", "Username", tblProduct.UserId);
            return View(tblProduct);
        }

        // POST: GeneralProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,Image,Price,UserId,CategoryId,ColorId,ModelId,StorageId,SellStartDate,SellEndDate,IsNew")] tblProduct tblProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.tblCategories, "CategoryId", "Name", tblProduct.CategoryId);
            ViewBag.ColorId = new SelectList(db.tblColors, "ColorId", "Color", tblProduct.ColorId);
            ViewBag.ModelId = new SelectList(db.tblModels, "ModelId", "Model", tblProduct.ModelId);
            ViewBag.StorageId = new SelectList(db.tblStorages, "StorageId", "Storage", tblProduct.StorageId);
            ViewBag.UserId = new SelectList(db.tblUsers, "UserId", "Username", tblProduct.UserId);
            return View(tblProduct);
        }

        // GET: GeneralProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProduct tblProduct = db.tblProducts.Find(id);
            if (tblProduct == null)
            {
                return HttpNotFound();
            }
            return View(tblProduct);
        }

        // POST: GeneralProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblProduct tblProduct = db.tblProducts.Find(id);
            db.tblProducts.Remove(tblProduct);
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
