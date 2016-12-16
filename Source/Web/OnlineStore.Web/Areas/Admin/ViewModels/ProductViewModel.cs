namespace OnlineStore.Web.Areas.Admin.ViewModels
{
    using Infrastructure.Mapping;
    using OnlineStore.Models;
    using System;
    using System.Collections.Generic;

    public class ProductViewModel: IMapFrom<Product>
    {
        public ICollection<Product> products;

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Decimal Price { get; set; }

        public string ImagePath { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}