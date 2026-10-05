using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Library2_WebAPI.Models
{
    [Index(nameof(Name), IsUnique = true)]  
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]  
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
