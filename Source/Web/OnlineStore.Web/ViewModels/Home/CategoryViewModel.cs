namespace OnlineStore.Web.ViewModels.Home
{
    using Infrastructure.Mapping;
    using OnlineStore.Models;
    using System.Collections.Generic;

    public class CategoryViewModel: IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Product> products;
    }
}