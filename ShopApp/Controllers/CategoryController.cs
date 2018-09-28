using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopApp.Models;
using System.Net;
using System.Data.Entity;
using PagedList;

namespace ShopApp.Controllers
{
    public class CategoryController : Controller
    {

        ShopEntities db = new ShopEntities();
        // GET: Category
        public ActionResult Index(int ? page)

        {
            int PageNumber = page ?? 1;
            int PageSize = 5;
            //return View(db.tblCategories.OrderBy(x =>x.Name).ToList());
            var categoryList = db.tblCategories.OrderBy(x => x.Name).ToPagedList(PageNumber, PageSize);
            return View(categoryList);
        }

        public PartialViewResult CategoryPartial()
        {
            var CategoryList = db.tblCategories.OrderBy(x => x.Name).ToList();
            return PartialView(CategoryList);
        }

        //GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }


        //POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="CategoryId,Name")]tblCategory Category)
        {
            if (ModelState.IsValid)
            {
                db.tblCategories.Add(Category);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(Category);
        }
        //GET: Category/Edit/{id}

        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCategory Category = db.tblCategories.Find(id);
            return View(Category);

        }
        //POST: Category/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include ="CategoryId, Name")] tblCategory Category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Category).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Category);
        }


        //GET: Category/Details/{id}
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCategory Category = db.tblCategories.Find(id);
            if (Category==null)
            {
                return HttpNotFound();
            }

            return View(Category);
        }
        //POST: Category/Delete/{id}

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var Category = db.tblCategories.Find(id);
            db.tblCategories.Remove(Category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
            

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                base.Dispose(disposing);
            }
            base.Dispose(disposing);    
        }
    }
}