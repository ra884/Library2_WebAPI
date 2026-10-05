using AutoMapper;
using Library2_WebAPI.DTOs.BookDTO;
using Library2_WebAPI.Models;

namespace Library2_WebAPI.Mapping
{
    public class BookProfile:Profile
    {
        public BookProfile() {
            CreateMap<Book,SearchBookDTO>().ReverseMap();   
            CreateMap<Book,GetBookBYPriceDTO>().ReverseMap();
            CreateMap<Book,CreateBookDTO>().ReverseMap();
        }

    }
}
