namespace OnlineStore.Web.ViewModels.CategoryProducts
{
    using AutoMapper;
    using Extensions;
    using Infrastructure.Mapping;
    using OnlineStore.Models;

    public class DetailsViewModel: CategoryProduct, IMapFrom<Product>, IHaveCustomMappings
    {
        public override void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Product, DetailsViewModel>()
            .ForMember(x => x.ImageToView, opt => opt.MapFrom(x => x.Image.ToStringImage()));
        }
    }
}