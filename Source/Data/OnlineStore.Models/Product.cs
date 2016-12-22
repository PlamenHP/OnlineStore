namespace OnlineStore.Models
{
    using Common.Models;
    using System.ComponentModel.DataAnnotations;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;

    public class Product:IDeletableEntity
    {
        private ICollection<ShoppingCart> shoppingCart;

        private ICollection<Order> order;

        public Product()
        {
            this.shoppingCart = new HashSet<ShoppingCart>();
            this.order = new HashSet<Order>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public Decimal Price { get; set; }

        public byte[] Image { get; set; }

        [ForeignKey("Category")]
        public int  CategoryId{ get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<ShoppingCart> ShoppingCart
        {
            get { return this.shoppingCart; }
            set { this.shoppingCart = value; }
        }

        public virtual ICollection<Order> Order
        {
            get { return this.order; }
            set { this.order = value; }
        }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
