using Library2_WebAPI.DTOs.BookDTO;
using Library2_WebAPI.DTOs.MemberDTO;

namespace Library2_WebAPI.DTOs.BorrowingDTO
{
    public class GetBorrowingsDTO
    {
        public DateTime BorrowedDate { get; set; }
        public GetMemberDTO Member { get; set; }
        public GetBookDTO Book { get; set; }
        
    }
}
