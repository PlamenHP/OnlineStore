namespace OnlineStore.Data.UnitOfWork
{
    using Common.Repositories;
    using Models;

    public interface IStoreDb
    {
        IRepository<ApplicationUser> Users { get;}

        IDeletableEntityRepository<Product> Products { get;}

        IRepository<Category> Categories { get;}
        
        void SaveChanges();
    }
}
