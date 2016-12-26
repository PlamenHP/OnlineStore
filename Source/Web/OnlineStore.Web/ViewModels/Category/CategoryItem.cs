namespace OnlineStore.Web.ViewModels.Category
{
    using AutoMapper;
    using Infrastructure.Mapping;
    using _Common;
    using Extensions;
    using Services;
    using OnlineStore.Models;

    public class CategoryItem : Product_T, IMapFrom<Product>, IHaveCustomMappings
    {
        public string Url
        {
            get
            {
                IIdentifierProvider identifier = new IdentifierProvider();
                var url = identifier.EncodeId(this.Id);
                return url;
            }
        }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Product, CategoryItem>()
            .ForMember(x => x.ImageToView, opt => opt.MapFrom(x => x.Image.ToStringImage()));
        }
    }
}