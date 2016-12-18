namespace OnlineStore.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Common.Models;
    using Migrations;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<ShoppingCart> ShoppingCarts { get; set; }

        public IDbSet<Order> Orders { get; set; }

        public IDbSet<ApplicationUser> ApplicationUsers { get; set; }

        public IDbSet<Role> UserRoles { get; set; }

        public override int SaveChanges()
        {
            ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        IDbSet<T> IApplicationDbContext.Set<T>()
        {
            return base.Set<T>();
        }
   }
}
    

