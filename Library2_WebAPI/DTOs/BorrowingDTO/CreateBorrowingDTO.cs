using Library2_WebAPI.Models;

namespace Library2_WebAPI.DTOs.BorrowingDTO
{
    public class CreateBorrowingDTO
    {
        public DateTime BorrowedDate { get; set; }
        public int MemberId { get; set; }
        public int BookId { get; set; }
    }
}
