using OnlineStore.Common.Repositories;
using OnlineStore.Models;

namespace OnlineStore.Data.UnitOfWork
{
    public interface IStoreDb
    {
        IRepository<ApplicationUser> Users { get;}

        IRepository<Product> Products { get;}

        IRepository<Category> Categories { get;}
        
        void SaveChanges();
    }
}
