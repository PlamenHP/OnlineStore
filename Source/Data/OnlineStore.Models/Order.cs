namespace OnlineStore.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Order
    {
        private ICollection<Product> products;

        public Order()
        {
            this.products = new HashSet<Product>();
        }

        [Key]
        public int Id { get; set; }

        public virtual ICollection<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }

        public virtual ApplicationUser User { get; set; }

        public bool Shipped { get; set; }
    }
}
