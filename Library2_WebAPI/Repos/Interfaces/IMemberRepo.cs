using Library2_WebAPI.Models;
using Library2_WebAPI.DTOs.MemberDTO;

namespace Library2_WebAPI.Repos.Interfaces
{
    public interface IMemberRepo:IGenericRepo<Member>
    {
        public ICollection<Member> TopMembers();
        public MemberStatisticsDTO GetStatisticsDTO(int id);

    }
}
