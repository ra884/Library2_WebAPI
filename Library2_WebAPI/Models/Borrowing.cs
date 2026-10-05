using System.ComponentModel.DataAnnotations;

namespace Library2_WebAPI.Models
{
    public class Borrowing
    {
        [Key]
        public int BorrowingId { get; set; }
        [Required]
        public DateOnly BorrowedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public Member Member { get; set; }
        public int MemberId { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }
    }
}
