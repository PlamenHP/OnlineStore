using OnlineStore.Data.UnitOfWork;
using OnlineStore.Models;
using System.Web.Mvc;

namespace OnlineStore.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        private IStoreDb data;
        private ApplicationUser userProfile;
        public BaseController(IStoreDb data)
        {
            this.Data = data;
        }

        public BaseController(IStoreDb data, ApplicationUser userProfile)
            : this(data)
        {
            this.UserProfile = userProfile;
        }

        protected IStoreDb Data { get; set; }

        public ApplicationUser UserProfile { get; set; }
    }
}