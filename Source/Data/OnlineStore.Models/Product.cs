﻿namespace OnlineStore.Models
{
    using Common.Models;
    using System.ComponentModel.DataAnnotations;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public class Product:IDeletableEntity
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

        [Required]
        public string Description { get; set; }

        [Required]
        public Decimal Price { get; set; }

        public byte[] Image { get; set; }

        [ForeignKey("Category")]
        public int  CategoryId{ get; set; }

        public virtual Category Category { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
