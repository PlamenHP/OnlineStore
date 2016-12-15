namespace OnlineStore.Web.ViewModels.Category
{
    using OnlineStore.Models;
    using System.Collections.Generic;

    public class CategoryViewModel
    {
        public ICollection<Product> products;

        public int Id { get; set; }

        public string Name { get; set; }
    }
}