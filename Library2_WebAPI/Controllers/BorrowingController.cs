using AutoMapper;
using Library2_WebAPI.DTOs.BorrowingDTO;
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
    public class BorrowingController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public BorrowingController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateBorrowing(CreateBorrowingDTO borrowingDTO)
        {
            if (borrowingDTO == null)
            {
                return BadRequest("Borrowing data is null");
            }
            var SelectedBook=unitOfWork.books.GetById(borrowingDTO.BookId);
            if (SelectedBook.IsAvailable==false)
            {
                return BadRequest("Selected book not available!");
            }
            SelectedBook.IsAvailable=false;
            var borrowing = mapper.Map<Borrowing>(borrowingDTO);
            unitOfWork.borrowings.CreateEntity(borrowing);
            unitOfWork.Save();
            return Created();
        }

        [HttpGet]
        public IActionResult GetBorrowings()
        {
            var borrowings=unitOfWork.borrowings.GetBorrowings();
            if (borrowings == null)
            {
                return NotFound("No borrowings found.");
            }
            var borrowingsDTO=mapper.Map<ICollection<GetBorrowingsDTO>>(borrowings);
            return Ok(borrowingsDTO);
        }

        [HttpPut]
        public IActionResult UpdateBorrowing(int id)
        {
            var borrowing=unitOfWork.borrowings.GetBorrowingWithBook(id);
            if (borrowing == null)
            {
                return NotFound("Borrowing not found.");
            }
            borrowing.ReturnedDate = DateTime.Now;
            borrowing.Book.IsAvailable = true;
            unitOfWork.borrowings.UpdateEntity(borrowing);
            unitOfWork.Save();
            return NoContent();
        }
    }
}
