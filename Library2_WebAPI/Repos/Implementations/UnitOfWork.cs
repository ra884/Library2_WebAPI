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


        public UnitOfWork(AppDbContext context, IBookRepo bookRepo , ICategoryRepo categoryRepo)
        {
            this.context = context;
            books = bookRepo;
            categories = categoryRepo;
        }

        public void Save()
        {
            context.SaveChanges();  
        }
    }
}
