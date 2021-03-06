﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopApp.Models;
using PagedList;
using System.Net;

namespace ShopApp.Controllers
{
    public class OrderController : Controller
    {

        ShopEntities db = new ShopEntities();
        // GET: Order
        public ActionResult Index(int? page)
        {
       
            var pageNumber = page ?? 1;
            var pageSize = 5;
            var OrderList = db.tblOrders.OrderByDescending(x => x.OrderId).ToPagedList(pageNumber, pageSize);

            return View(OrderList);
        }

        // GET: Order/Details/5
        public ActionResult Details(int? id)
        {

            if (id ==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var order = db.tblOrders.Find(id);
            if (order== null)
            {
                return HttpNotFound();
            }

            return View(order);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
