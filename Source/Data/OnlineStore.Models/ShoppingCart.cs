﻿namespace OnlineStore.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ShoppingCart
    {
        private ICollection<Product> products;

        public ShoppingCart()
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

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
