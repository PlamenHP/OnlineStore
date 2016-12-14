namespace OnlineStore.Web.Controllers
{
    using Data.UnitOfWork;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;

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
            return View();
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