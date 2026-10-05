using Library2_WebAPI.Models;

namespace Library2_WebAPI.Repos.Interfaces
{
    public interface IBookRepo:IGenericRepo<Models.Book>    
    {

        public ICollection<Book> Search(string Keyword);
        public Book HighestPrice();
    }
}
