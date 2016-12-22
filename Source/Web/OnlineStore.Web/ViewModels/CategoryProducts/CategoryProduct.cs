namespace OnlineStore.Web.ViewModels.CategoryProducts
{
    using System;
    using AutoMapper;
    using OnlineStore.Infrastructure.Mapping;
    using OnlineStore.Models;
    using OnlineStore.Web.ViewModels._Common;
    using Extensions;

    public class CategoryProduct : Product_T, IMapFrom<Product>, IHaveCustomMappings
    {
        public string Description { get; set; }

        public virtual void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Product, CategoryProduct>()
            .ForMember(x => x.ImageToView, opt => opt.MapFrom(x => x.Image.ToStringImage()));
        }
    }
}