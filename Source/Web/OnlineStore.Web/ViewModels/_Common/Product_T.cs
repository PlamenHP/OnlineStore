namespace OnlineStore.Web.ViewModels._Common
{
    using Extensions;
    using Infrastructure.Mapping;
    using OnlineStore.Models;
    using System;
    using AutoMapper;

    public abstract class Product_T
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageToView { get; set; }

        public Decimal Price { get; set; }
    }
}