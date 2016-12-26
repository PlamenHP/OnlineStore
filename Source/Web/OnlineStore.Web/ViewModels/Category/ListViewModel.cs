namespace OnlineStore.Web.ViewModels.Category
{
    using Infrastructure.Mapping;
    using System.Collections.Generic;
    using AutoMapper;

    public class ListViewModel: IMapFrom<OnlineStore.Models.Category>, IHaveCustomMappings
    {
        public ListViewModel()
        {
            this.CategoryItems = new HashSet<CategoryItem>();
        }
        
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<CategoryItem> CategoryItems { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<OnlineStore.Models.Category, ListViewModel>()
            .ForMember(x => x.CategoryItems, opt => opt.MapFrom(x => x.Products));
        }
    }
}