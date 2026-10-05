using Library2_WebAPI.Models;
using Library2_WebAPI.Data;
using Library2_WebAPI.DTOs.MemberDTO;
using Library2_WebAPI.Repos.Interfaces;


namespace Library2_WebAPI.Repos.Implementations
{
    public class MemberRepo : GenericRepo<Member>, IMemberRepo
    {
        private readonly AppDbContext context;
        public MemberRepo(AppDbContext context): base(context) 
        {
            this.context = context;
        }
        public MemberStatisticsDTO GetStatisticsDTO(int id)
        {
            var member = context.Members.Where(m=>m.MemberId==id).Select(m=> new MemberStatisticsDTO
            {
                MemberName=m.FullName,
                TotalBorrowedBooks=m.Borrowings.Count(),
                ReturnedBooks=m.Borrowings.Where(b=>b.ReturnedDate!=null).Count(),
                CurrentlyBorrowedBooks=m.Borrowings.Where(b=>b.ReturnedDate==null).Count()
            }).First();
            return member;
        }

        public ICollection<Member> TopMembers()
        {
            var members=context.Members.OrderByDescending(m=>m.Borrowings.Count())
                .Take(5).ToList();
            return members;
        }
    }
}
