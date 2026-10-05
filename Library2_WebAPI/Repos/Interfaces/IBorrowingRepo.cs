using Library2_WebAPI.Models;

namespace Library2_WebAPI.Repos.Interfaces
{
    public interface IBorrowingRepo:IGenericRepo<Borrowing>
    {
        public ICollection<Borrowing> GetBorrowings();
        public Borrowing GetBorrowingWithBook(int id);
    }
}
