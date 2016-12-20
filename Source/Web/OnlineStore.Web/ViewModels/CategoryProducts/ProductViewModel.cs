namespace OnlineStore.Web.ViewModels.Category
{
    using AutoMapper;
    using Extensions;
    using Infrastructure.Mapping;
    using OnlineStore.Models;
    using System;

    public class ProductViewModel : IMapFrom<Product>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageToView { get; set; }

        public string Description { get; set; }

        public Decimal Price { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Product, ProductViewModel>()
            .ForMember(x => x.ImageToView, opt => opt.MapFrom(x => x.Image.ToStringImage()));
        }
    }
}