using Library2_WebAPI.Data;
using Library2_WebAPI.Models;
using Library2_WebAPI.Repos.Interfaces;

namespace Library2_WebAPI.Repos.Implementations
{
    public class BookRepo : GenericRepo<Models.Book>, IBookRepo
    {
        private readonly AppDbContext context;
        public BookRepo(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public Book HighestPrice()
        {
            var book=context.Books.OrderByDescending(b => b.Price).FirstOrDefault();
            return book;    
        }

        public ICollection<Book> Search(string Keyword)
        {
           var books=context.Books.Where(b => b.Title
           .Contains(Keyword) || b.Author.Contains(Keyword))
                .OrderByDescending(b=>b.Title).ToList();
            return books;
        }
    }
}
