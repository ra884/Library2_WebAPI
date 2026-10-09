using AutoMapper;
using Library2_WebAPI.DTOs.BookDTO;
using Library2_WebAPI.Models;
using Library2_WebAPI.Repos.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library2_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookController : ControllerBase
    {
        private IUnitOfWork UnitOfWork;
        private IMapper mapper;
        public BookController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        [HttpGet("most-expensive")]   
        public IActionResult GetBook()
        {
            var book=UnitOfWork.books.HighestPrice();
            if (book == null)
            {
                return NotFound("Book not found.");
            }
            var bookDTO=mapper.Map<SearchBookDTO>(book);
            return Ok(bookDTO);
        }

        [HttpGet("search")]
        public IActionResult search(string Keyword)
        {
            var books= UnitOfWork.books.Search(Keyword);
            var booksDTO=mapper.Map<ICollection<SearchBookDTO>>(books);
            return Ok(booksDTO);
        }

        [HttpPost]
        public IActionResult CreateBook(CreateBookDTO bookDTO)
        {
            if (bookDTO == null)
            {
                return BadRequest("Book data is null");
            }
            var book=mapper.Map<Book>(bookDTO); 
            UnitOfWork.books.CreateEntity(book);
            UnitOfWork.Save();
            return Created();
        }
    }
}
