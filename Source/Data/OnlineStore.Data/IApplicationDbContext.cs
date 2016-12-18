namespace OnlineStore.Data
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IApplicationDbContext : IDisposable
    {
        IDbSet<Product> Products { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<ApplicationUser> Users { get; set; }

        IDbSet<ShoppingCart> ShoppingCarts { get; set; }

        IDbSet<Order> Orders { get; set; }

        IDbSet<Role> UserRoles { get; set; }

        int SaveChanges();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;
    }
}
