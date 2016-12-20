namespace OnlineStore.Data.UnitOfWork
{
    using Common.Repositories;
    using Models;

    public interface IStoreDb
    {
        IRepository<ApplicationUser> Users { get;}

        IDeletableEntityRepository<Product> Products { get;}

        IRepository<Category> Categories { get;}

        IRepository<ShoppingCart> ShoppingCarts { get; }

        IRepository<Order> Orders { get; }

        void SaveChanges();
    }
}
