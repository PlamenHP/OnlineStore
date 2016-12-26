namespace OnlineStore.Web.ViewModels.Product
{
    using _Common;
    using AutoMapper;
    using Extensions;
    using Infrastructure.Mapping;
    using OnlineStore.Models;

    public class DetailsViewModel: Product_T, IMapFrom<Product>, IHaveCustomMappings
    {
        public string Description { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Product, DetailsViewModel>()
            .ForMember(x => x.ImageToView, opt => opt.MapFrom(x => x.Image.ToStringImage()));
        }
    }
}