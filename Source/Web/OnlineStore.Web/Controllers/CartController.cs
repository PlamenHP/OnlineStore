namespace OnlineStore.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data.UnitOfWork;
    using System.Net;
    using ViewModels;
    using ViewModels.Cart;

    public class CartController : BaseController
    {
        public CartController(IStoreDb data) 
            : base(data)
        {
        }

        // GET: Cart
        public ActionResult Index()
        {
            return RedirectToAction(nameof(Content));
        }

        // GET: List
        public ActionResult Content()
        {
            // get the cart from session
            var contentViewModel = (ContentViewModel)Session["Cart"];

            if (contentViewModel == null)
            {
                contentViewModel = new ContentViewModel();
            }

            // put the cart back to session
            Session["Cart"] = contentViewModel;

            return View(contentViewModel);
        }

        // GET: Buuy
        public ActionResult BuyItem(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = Data.Products.GetById(id);

            if (product == null)
            {
                return HttpNotFound();
            }

            // get the cart from session
            var contentViewModel = (ContentViewModel)Session["Cart"];

            if (contentViewModel == null)
            {
                contentViewModel = new ContentViewModel();       
            }

            // add the item
            var item = Mapper.Map<CartItem>(product);
            contentViewModel.Items.Add(item);
            contentViewModel.Sum = contentViewModel.Items.Select(x => x.Price).Sum();

            // put the cart back to session
            Session["Cart"] = contentViewModel;

            // Return the view
            return RedirectToAction(nameof(Content));
        }

        // GET: Remove
        public ActionResult RemoveItem(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var contentViewModel = (ContentViewModel)Session["Cart"];

            if (contentViewModel == null)
            {
                return HttpNotFound();
            }

            contentViewModel.Items.Remove(contentViewModel.Items.Where(x=>x.Id==id).FirstOrDefault());
            contentViewModel.Sum = contentViewModel.Items.Select(x => x.Price).Sum();

            // put the cart back to session
            Session["Cart"] = contentViewModel;

            // Return the view
            return RedirectToAction(nameof(Content));
        }
    }
}