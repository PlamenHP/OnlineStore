namespace OnlineStore.Web.ViewModels.Category
{
    using Infrastructure.Mapping;
    using OnlineStore.Models;
    using System.Collections.Generic;

    public class ListCategoryProductsViewModel: IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ProductViewModel> Products { get; set; }
    }
}