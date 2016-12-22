namespace OnlineStore.Web.ViewModels
{
    using Cart;
    using OnlineStore.Models;
    using System.Collections.Generic;

    public class CartViewModel
    {
        public CartViewModel()
        {
            this.Items = new List<CartItem>();
        }

        public decimal Sum { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public List<CartItem> Items { get; set; }
    }
}