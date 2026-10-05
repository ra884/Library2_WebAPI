using Library2_WebAPI.Data;
using Library2_WebAPI.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library2_WebAPI.Repos.Implementations
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class 
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> db;
        public GenericRepo(AppDbContext context)
        {
            _context = context;
            db = _context.Set<T>();
        }
        public void CreateEntity(T entity)
        {
            db.Add(entity);
        }

        public void DeleteEntity(T entity)
        {
            db.Remove(entity);
        }

        public ICollection<T> GetAll()
        {
            return db.ToList();
        }

        public T GetById(int id)
        {
            return db.Find(id);
        }

        public void UpdateEntity(T entity)
        {
            db.Update(entity);
        }
    }
    
    
}
