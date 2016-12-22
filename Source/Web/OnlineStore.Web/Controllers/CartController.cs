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
            return RedirectToAction(nameof(Cart));
        }

        // GET: List
        public ActionResult Cart()
        {

            // get the cart from session
            var cartViewModel = (CartViewModel)Session["Cart"];
            return View(cartViewModel);
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
            var cartViewModel = (CartViewModel)Session["Cart"];

            if (cartViewModel == null)
            {
                cartViewModel = new CartViewModel();       
            }

            // add the item
            var item = Mapper.Map<CartItem>(product);
            cartViewModel.Items.Add(item);
            cartViewModel.Sum = cartViewModel.Items.Select(x => x.Price).Sum();

            // put the cart back to session
            Session["Cart"] = cartViewModel;

            // Return the view
            return RedirectToAction(nameof(Cart));
        }

        // GET: Remove
        public ActionResult RemoveItem(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var cartViewModel = (CartViewModel)Session["Cart"];

            if (cartViewModel == null)
            {
                return HttpNotFound();
            }

            cartViewModel.Items.Remove(cartViewModel.Items.Where(x=>x.Id==id).FirstOrDefault());
            cartViewModel.Sum = cartViewModel.Items.Select(x => x.Price).Sum();

            // put the cart back to session
            Session["Cart"] = cartViewModel;

            // Return the view
            return RedirectToAction(nameof(Cart));
        }
    }
}