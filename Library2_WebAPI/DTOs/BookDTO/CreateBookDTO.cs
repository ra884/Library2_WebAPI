using System.ComponentModel.DataAnnotations;

namespace Library2_WebAPI.DTOs.BookDTO
{
    public class CreateBookDTO
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
