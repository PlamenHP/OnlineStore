﻿namespace OnlineStore.Web.Controllers
{
    using Data.UnitOfWork;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;
    using ViewModels.Home;
    using Infrastructure.Mapping;
    using System.Collections.Generic;

    public class HomeController : BaseController
    {
        public HomeController(IStoreDb data)
            :base(data)
        {
        }

        public ActionResult Index()
        {
            bool isAdmin = this.User.IsInRole("Admin");
            if (isAdmin)
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }

            var categories = this.Data.Categories
                .All()
                .OrderBy(x => x.Name)            
                .ToList();

            var listCategoriesViewModel = Mapper.Map<IEnumerable<ListCategoriesViewModel>>(categories);

            // Return the view
            return View(listCategoriesViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            
            return this.RedirectToAction(c => c.Contact());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}