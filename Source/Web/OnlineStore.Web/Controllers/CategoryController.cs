namespace OnlineStore.Web.Controllers
{
    using Data.UnitOfWork;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using ViewModels.Category;

    public class CategoryController : BaseController
    {
        public CategoryController(IStoreDb data)
            :base(data)
        {
        }

        // GET: Category
        public ActionResult List(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Get category products
            var categoty = this.Data.Categories.GetById(id);
            var products = new CategoryViewModel { Id = categoty.Id, Name = categoty.Name, products = categoty.Products};

            // Return the view
            return View(products);
        }
    }
}