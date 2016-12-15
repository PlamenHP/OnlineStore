namespace OnlineStore.Web.ViewModels.Home
{
    using Infrastructure.Mapping;
    using OnlineStore.Models;

    public class CategoryViewModel: IMapFrom<Category>
    {
        public CategoryViewModel()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}