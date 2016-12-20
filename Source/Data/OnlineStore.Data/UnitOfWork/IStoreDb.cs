namespace OnlineStore.Data.UnitOfWork
{
    using Common.Repositories;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public interface IStoreDb
    {
        IRepository<ApplicationUser> Users { get;}

        IDeletableEntityRepository<Product> Products { get;}

        IRepository<Category> Categories { get;}

        IRepository<ShoppingCart> ShoppingCarts { get; }

        IRepository<Order> Orders { get; }

        IRepository<IdentityRole> IdentityRoles { get; }

        void SaveChanges();
    }
}
