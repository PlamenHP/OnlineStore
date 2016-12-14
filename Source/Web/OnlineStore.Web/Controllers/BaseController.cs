namespace OnlineStore.Web.Controllers
{
    using Data.UnitOfWork;
    using OnlineStore.Models;
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;

    public abstract class BaseController : Controller
    {
        private IStoreDb data;
        private ApplicationUser userProfile;

        public BaseController(IStoreDb data)
        {
            if (data == null)
            {
                throw new ArgumentException("An instance of IStoreDb is required to use this controller.", "data");
            }

            this.Data = data;
        }

        public BaseController(IStoreDb data, ApplicationUser userProfile)
            : this(data)
        {
            if (userProfile == null)
            {
                throw new ArgumentException("An instance of ApplicationUser is required to use this controller.", "data");
            }

            this.UserProfile = userProfile;
        }

        protected IStoreDb Data { get; private set; }

        public ApplicationUser UserProfile { get; private set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var userName = requestContext.HttpContext.User.Identity.Name;
                var user = this.Data.Users.All().FirstOrDefault(x => x.UserName == userName);
                this.UserProfile = user;
            }

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}