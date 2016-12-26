namespace OnlineStore.Web.Controllers
{
    using Services;
    using System.Net;
    using System.Web.Mvc;
    using Data.UnitOfWork;
    using ViewModels.Product;

    public class ProductController : BaseController
    {
        public ProductController(IStoreDb data) 
            : base(data)
        {
        }

        // GET: Product details
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //decode the id
            var decriptedId = new IdentifierProvider().DecodeId(id);

            var product = Data.Products.GetById(decriptedId);
            var detailsViewModel = Mapper.Map<DetailsViewModel>(product);
            return View(detailsViewModel);
        }
    }
}