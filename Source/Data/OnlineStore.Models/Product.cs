namespace OnlineStore.Models
{
    using OnlineStore.Common.Models;
    using System.ComponentModel.DataAnnotations;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        public Product()
        {
        }

        public Product(string name)
        {
            this.Name = name;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("Category")]
        public int  CategoryId{ get; set; }

        public virtual Category Category { get; set; }
    }
}
