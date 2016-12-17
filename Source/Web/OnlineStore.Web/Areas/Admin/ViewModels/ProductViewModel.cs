namespace OnlineStore.Web.Areas.Admin.ViewModels
{
    using Infrastructure.Mapping;
    using OnlineStore.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ProductViewModel: IMapFrom<Product>, IMapTo<Product>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public Decimal Price { get; set; }

        [Required]
        public string ImagePath { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}