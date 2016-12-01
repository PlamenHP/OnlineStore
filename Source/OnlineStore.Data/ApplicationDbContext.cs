
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineStore.Model;
using System.Data.Entity;

namespace OnlineStore.Data
{
    public class OnlineStoreDbContext : IdentityDbContext<ApplicationUser>
    {
        public OnlineStoreDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static OnlineStoreDbContext Create()
        {
            return new OnlineStoreDbContext();
        }

        public IDbSet<Product> Products { get; set; }
    }
}
