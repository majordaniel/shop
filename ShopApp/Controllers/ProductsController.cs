using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopApp.Models;
using PagedList;
using System.Net;

namespace ShopApp.Controllers
{
    public class ProductsController : Controller
    {
        ShopEntities db = new ShopEntities();
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult ProductListPartial(int? page, int? category)
        {

            var pageNumber = page ?? 1;
            var pageSize = 5;
            if (category != null)
            {
                ViewBag.category = category;

                var productList = db.tblProducts
                    .OrderByDescending(x => x.ProductId)
                    .Where(x => x.CategoryId == category)
                    .ToPagedList(pageNumber, pageSize);

                return PartialView(productList);
            }
            else
            {
                var productList = db.tblProducts.OrderByDescending(x => x.ProductId  ).ToPagedList(pageNumber, pageSize);
                return PartialView(productList);
            }
            //var productList = db.tblProducts.OrderByDescending(x => x.ProductId).ToList();
           
        }

        // GET: product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProduct ProductDetails = db.tblProducts.Find(id);
            if (ProductDetails == null)
            {
                return HttpNotFound();
            }
            return View(ProductDetails);
        }
    }
}