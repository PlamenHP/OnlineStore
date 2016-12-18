namespace OnlineStore.Web.Areas.Admin.ViewModels
{
    using AutoMapper;
    using Extensions;
    using Infrastructure.Mapping;
    using OnlineStore.Models;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public class CategoryViewModel: IMapFrom<Category>, IMapTo<Category>, IHaveCustomMappings
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public HttpPostedFileBase ImageFromView { get; set; }

        public string ImageToView { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<CategoryViewModel, Category>()
                .ForMember(x => x.Image, opt => opt.MapFrom(x => x.ImageFromView.ToByteArrayImage()));
            configuration.CreateMap<Category, CategoryViewModel>()
            .ForMember(x => x.ImageToView, opt => opt.MapFrom(x => x.Image.ToStringImage()));
        }
    }
}
