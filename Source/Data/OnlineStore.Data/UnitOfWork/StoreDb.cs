using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Common.Repositories;
using OnlineStore.Models;
using OnlineStore.Data.Repositories;

namespace OnlineStore.Data.UnitOfWork
{
    class StoreDb : IStoreDb
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

        public IRepository<Category> Categories
        {
            get
            {
                return categories ?? (this.categories = new GenericRepository<Category>(dbContext));
            }
        }

        public IRepository<Product> Products
        {
            get
            {
                return products ??( this.products = new GenericRepository<Product>(dbContext));
            }
        }

        public IRepository<ApplicationUser> Users
        {
            get
            {
                return users ?? (this.users = new GenericRepository<ApplicationUser>(dbContext));
            }
        }

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }
    }
}