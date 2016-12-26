namespace OnlineStore.Web.Controllers
{
    using Data.UnitOfWork;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;
    using ViewModels.Home;
    using System.Collections.Generic;
    using Services;

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

            var categories = this.cacheService.Get(
                "categories",
                () => this.Data.Categories
                .All()
                .OrderBy(x => x.Name)
                .ToList(),
                30 * 60
            );

            var listCategoriesViewModel = Mapper.Map<IEnumerable<IndexViewModel>>(categories);

            // Return the view
            return View(listCategoriesViewModel);
        }
    }
}