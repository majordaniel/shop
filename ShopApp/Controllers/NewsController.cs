﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopApp.Models;

namespace ShopApp.Controllers
{
    public class NewsController : Controller
    {
        ShopEntities db = new ShopEntities();
        // GET: News
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult NewsListPartial()
        {
            var NewsList = db.tblNews.OrderByDescending(x => x.NewsId).ToList();

            return PartialView(NewsList);
        }
    }
}