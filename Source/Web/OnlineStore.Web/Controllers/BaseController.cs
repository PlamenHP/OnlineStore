using OnlineStore.Data.UnitOfWork;
using OnlineStore.Models;
using System.Web.Mvc;

namespace OnlineStore.Web.Controllers
{
    abstract class BaseController : Controller
    {
        public BaseController(IStoreDb data)
        {
            this.Data = data;
        }

        public BaseController(IStoreDb data, ApplicationUser storeUser)
            : this(data)
        {
            this.StoreUser = storeUser;
        }

        protected IStoreDb Data { get; set; }

        protected ApplicationUser StoreUser { get; set; }
    }
}