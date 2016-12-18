
namespace OnlineStore.Data.UnitOfWork
{
    using Common.Repositories;
    using Models;
    using Repositories;
    using System;

    public class StoreDb : IStoreDb
    {
        private readonly IApplicationDbContext dbContext;

        private IRepository<ApplicationUser> users;
        private IDeletableEntityRepository<Product> products;
        private IRepository<Category> categories;
        private IRepository<ShoppingCart> shoppingCarts;
        private IRepository<Order> orders;
        private IRepository<Role> userRoles;

        public StoreDb(IApplicationDbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentException("An instance of IApplicationDbContext is required to use this unit of work.", "dbContext");
            }

            this.dbContext = dbContext;
        }

        public IRepository<Category> Categories => (categories ?? (this.categories = new GenericRepository<Category>(dbContext)));

        public IDeletableEntityRepository<Product> Products => (products ?? (this.products = new DeletableEntityRepository<Product>(dbContext)));

        public IRepository<ApplicationUser> Users => (users ?? (this.users = new GenericRepository<ApplicationUser>(dbContext)));

        public IRepository<ShoppingCart> ShoppingCarts => (shoppingCarts ?? (this.shoppingCarts = new GenericRepository<ShoppingCart>(dbContext)));

        public IRepository<Order> Orders => (orders ?? (this.orders = new GenericRepository<Order>(dbContext)));

        public IRepository<Role> UserRoles => (userRoles ?? (this.userRoles = new GenericRepository<Role>(dbContext)));

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }
    }
}