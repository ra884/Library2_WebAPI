using AutoMapper;
using Library2_WebAPI.DTOs.MemberDTO;
using Library2_WebAPI.Models;

namespace Library2_WebAPI.Mapping
{
    public class MemberProfile:Profile
    {
        public MemberProfile()
        {
            CreateMap<Member,CreateMemberDTO>().ReverseMap();
            CreateMap<Member,TopMembersDTO>().ReverseMap();
            CreateMap<Member,GetMemberDTO>().ReverseMap();
        }
    }
}
