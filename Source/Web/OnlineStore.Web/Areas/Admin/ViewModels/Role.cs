using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models
{
    public class Role
    {
        [Key]
        public string Name { get; set; }

        public bool IsSelected { get; set; }
    }
}
