﻿namespace OnlineStore.Web.ViewModels.Home
{
    using Infrastructure.Mapping;
    using OnlineStore.Models;
    using System.Collections.Generic;
    using AutoMapper;
    using System;
    using Extensions;

    public class ListCategoriesViewModel: IMapFrom<Category>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageToView { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Category, ListCategoriesViewModel>()
            .ForMember(x => x.ImageToView, opt => opt.MapFrom(x => x.Image.ToStringImage()));
        }
    }
}