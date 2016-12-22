namespace OnlineStore.Web.ViewModels.Cart
{
    using System;
    using _Common;
    using AutoMapper;
    using Infrastructure.Mapping;
    using OnlineStore.Models;
    using Extensions;

    public class CartItem : Product_T, IMapFrom<Product>, IHaveCustomMappings
    {
        public int Sum { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Product, CartItem>()
            .ForMember(x => x.ImageToView, opt => opt.MapFrom(x => x.Image.ToStringImage()));
        }
    }
}