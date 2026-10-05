using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Library2_WebAPI.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class Member
    {
        [Key]
        public int MemberId { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        public ICollection<Borrowing> Borrowings { get; set; } = new List<Borrowing>();
    }
}
