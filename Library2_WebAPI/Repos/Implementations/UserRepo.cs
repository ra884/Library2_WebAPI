using Library2_WebAPI.Data;
using Library2_WebAPI.Models;
using Library2_WebAPI.Repos.Interfaces;

namespace Library2_WebAPI.Repos.Implementations
{
    
    public class UserRepo : GenericRepo<User>, IUserRepo
    {
        private readonly AppDbContext context;
        public UserRepo(AppDbContext context): base(context)
        {
            this.context = context;
        }
        public User GetuserByName(string name)
        {
            return context.Users.FirstOrDefault(u => u.UserName == name);
        }
    }
}
