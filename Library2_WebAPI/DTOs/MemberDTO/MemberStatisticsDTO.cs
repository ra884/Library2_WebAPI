namespace Library2_WebAPI.DTOs.MemberDTO
{
    public class MemberStatisticsDTO
    {
        public string MemberName { get; set; }
        public int TotalBorrowedBooks { get; set; }
        public int ReturnedBooks { get; set; }
        public int CurrentlyBorrowedBooks { get;set; }
    }
}
