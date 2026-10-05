using Library2_WebAPI.Data;
using Library2_WebAPI.Models;
using Library2_WebAPI.Repos.Interfaces;

namespace Library2_WebAPI.Repos.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;
        public IBookRepo books { get;}
        public ICategoryRepo categories { get;}
        public IMemberRepo members { get;}
        public IBorrowingRepo borrowings { get;}
        public UnitOfWork(AppDbContext context, IBookRepo bookRepo
            , ICategoryRepo categoryRepo, IMemberRepo members, IBorrowingRepo borrowings)
        {
            this.context = context;
            books = bookRepo;
            categories = categoryRepo;
            this.members = members;
            this.borrowings = borrowings;
        }

        public void Save()
        {
            context.SaveChanges();  
        }
    }
}
