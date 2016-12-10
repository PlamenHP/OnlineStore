namespace OnlineStore.Models
{
    using OnlineStore.Common.Models;
    using System.ComponentModel.DataAnnotations;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("Category")]
        public virtual int  Category{ get; set; }
    }
}
