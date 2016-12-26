namespace OnlineStore.Web.ViewModels.Cart
{
    using Cart;
    using OnlineStore.Models;
    using System.Collections.Generic;

    public class ContentViewModel
    {
        public ContentViewModel()
        {
            this.CartItems = new List<CartItem>();
        }

        public decimal Sum { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public List<CartItem> CartItems { get; set; }
    }
}