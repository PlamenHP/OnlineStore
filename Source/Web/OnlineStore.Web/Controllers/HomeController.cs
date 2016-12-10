﻿using OnlineStore.Data;
using OnlineStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            var context = new OnlineStoreDbContext();
            Product p = new Product() {Name="cars" };
            context.Products.Add(p);
            context.SaveChanges();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}