namespace OnlineStore.Model
{
    using OnlineStore.Common.Models;
    using System.ComponentModel.DataAnnotations;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product: AuditInfo, IDeletableEntity , IAuditInfo
    {
        public DateTime? DeletedOn { get; set; }

        [Key]
        public int Id { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public string Name { get; set; }
    }
}
