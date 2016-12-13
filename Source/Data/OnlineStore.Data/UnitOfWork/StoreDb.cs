
namespace OnlineStore.Data.UnitOfWork
{
    using Common.Repositories;
    using Models;
    using Repositories;

    public class StoreDb : IStoreDb
    {
        private readonly IApplicationDbContext dbContext;

        private IRepository<ApplicationUser> users;
        private IRepository<Product> products;
        private IRepository<Category> categories;

        public StoreDb()
            : this(new ApplicationDbContext())
        {
        }

        public StoreDb(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IRepository<Category> Categories => (categories ?? (this.categories = new GenericRepository<Category>(dbContext)));


        public IRepository<Product> Products => (products ?? (this.products = new DeletableEntityRepository<Product>(dbContext)));


        public IRepository<ApplicationUser> Users => (users ?? (this.users = new GenericRepository<ApplicationUser>(dbContext)));

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }
    }
}