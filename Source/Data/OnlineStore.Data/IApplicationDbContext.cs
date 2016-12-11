using OnlineStore.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace OnlineStore.Data
{
    public interface IApplicationDbContext : IDisposable
    {
        IDbSet<Product> Products { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<ApplicationUser> Users { get; set; }

        int SaveChanges();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;
    }
}
