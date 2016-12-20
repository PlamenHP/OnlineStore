namespace OnlineStore.Web.Controllers
{
    using Data.UnitOfWork;
    using System.Net;
    using System.Web.Mvc;
    using ViewModels.Category;

    public class CategoryProductsController : BaseController
    {
        public CategoryProductsController(IStoreDb data)
            : base(data)
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
            var category = this.Data.Categories.GetById(id);
            var listCategoryProductsView = Mapper.Map<ListCategoryProductsViewModel>(category);

            // Return the view
            return View(listCategoryProductsView);
        }

        // GET: Category
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = Data.Products.GetById(id);

            var detailsView = Mapper.Map<ProductViewModel>(product);
            return View(detailsView);
        }

        // POST: Category
        [HttpPost]
        public ActionResult DetailsBuy(int? id)
        {
            return View();
        }
    }
}