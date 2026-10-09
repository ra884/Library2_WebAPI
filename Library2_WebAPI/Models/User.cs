using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Library2_WebAPI.Models
{
    [Index(nameof(UserName),IsUnique =true)]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
