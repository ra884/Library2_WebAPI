using Library2_WebAPI.Models;

namespace Library2_WebAPI.Repos.Interfaces
{
    public interface IUserRepo:IGenericRepo<User>
    {
        public User GetuserByName(string name);
    }
}
