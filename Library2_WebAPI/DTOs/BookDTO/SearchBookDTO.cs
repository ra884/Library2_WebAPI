using System.ComponentModel.DataAnnotations;

namespace Library2_WebAPI.DTOs.BookDTO
{
    public class SearchBookDTO
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
    }
}
