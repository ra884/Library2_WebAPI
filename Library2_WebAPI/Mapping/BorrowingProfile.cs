using AutoMapper;
using Library2_WebAPI.DTOs.BorrowingDTO;
using Library2_WebAPI.Models;

namespace Library2_WebAPI.Mapping
{
    public class BorrowingProfile:Profile
    {
        public BorrowingProfile()
        {
            CreateMap<Borrowing,CreateBorrowingDTO>().ReverseMap();
            CreateMap<Borrowing,GetBorrowingsDTO>().ReverseMap();
        }
    }
}
