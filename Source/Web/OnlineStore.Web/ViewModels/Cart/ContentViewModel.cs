namespace OnlineStore.Web.ViewModels.Cart
{
    using Cart;
    using OnlineStore.Models;
    using System.Collections.Generic;

    public class ContentViewModel
    {
        public ContentViewModel()
        {
            this.Items = new List<CartItem>();
        }

        public decimal Sum { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public List<CartItem> Items { get; set; }
    }
}