namespace OnlineStore.Web.ViewModels.Category
{
    using Infrastructure.Mapping;
    using OnlineStore.Models;
    using System.Collections.Generic;

    public class CategoryViewModel: IMapFrom<Category>
    {
        public ICollection<Product> products;

        public int Id { get; set; }

        public string Name { get; set; }
    }
}