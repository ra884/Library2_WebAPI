using Library2_WebAPI.Data;
using Library2_WebAPI.Models;
using Library2_WebAPI.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library2_WebAPI.Repos.Implementations
{
    public class BorrowingRepo : GenericRepo<Borrowing>, IBorrowingRepo
    {
        private readonly AppDbContext context;

        public BorrowingRepo(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public ICollection<Borrowing> GetBorrowings()
        {
            return context.Borrowings
                .Include(b=>b.Member)
                .Include(b=>b.Book)
                .OrderByDescending(b=>b.BorrowedDate)
                .ToList();
        }

        public Borrowing GetBorrowingWithBook(int id)
        {
            return context.Borrowings
                .Include(b => b.Book)
                .FirstOrDefault(b => b.BorrowingId == id);
        }


    }
}
