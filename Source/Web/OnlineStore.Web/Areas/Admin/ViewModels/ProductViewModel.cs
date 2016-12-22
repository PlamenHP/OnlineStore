namespace OnlineStore.Web.Areas.Admin.ViewModels
{
    using OnlineStore.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;
    using AutoMapper;
    using Extensions;
    using Infrastructure.Mapping;

    public class ProductViewModel : IMapFrom<Product>, IMapTo<Product>, IHaveCustomMappings
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        public Decimal Price { get; set; }

        public HttpPostedFileBase ImageFromView { get; set; }

        public string ImageToView { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<ProductViewModel, Product>()
                .ForMember(x => x.Image, opt => opt.MapFrom(x => x.ImageFromView.ToByteArrayImage()));

            configuration.CreateMap<Product, ProductViewModel>()
            .ForMember(x => x.ImageToView, opt => opt.MapFrom(x => x.Image.ToStringImage()));
        }
    }
}

