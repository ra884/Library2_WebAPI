using Library2_WebAPI.Models;

namespace Library2_WebAPI.Repos.Interfaces
{
    public interface IUnitOfWork
    {
        IBookRepo books { get; }
        ICategoryRepo categories { get; }
        void Save();
    }
}
