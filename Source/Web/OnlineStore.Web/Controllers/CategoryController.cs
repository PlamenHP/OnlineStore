namespace OnlineStore.Web.Controllers
{
    using Data.UnitOfWork;
    using Services;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using ViewModels.Category;

    public class CategoryController : BaseController
    {
        public CategoryController(IStoreDb data)
            : base(data)
        {
        }

        // GET: Category
        public ActionResult List(string categoryName)
        {
            if (categoryName == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Get category products
            var category = this.Data.Categories.All().Where(x=>x.Name == categoryName).FirstOrDefault();
            var listViewModel = Mapper.Map<ListViewModel>(category);

            // Return the view
            return View(listViewModel);
        }
    }
}