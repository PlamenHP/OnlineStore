namespace OnlineStore.Web.ViewModels.CategoryProducts
{
    using Infrastructure.Mapping;
    using OnlineStore.Models;
    using System.Collections.Generic;

    public class ListViewModel: IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<CategoryProduct> Products { get; set; }
    }
}