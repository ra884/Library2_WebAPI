using System.ComponentModel.DataAnnotations;

namespace Library2_WebAPI.DTOs.MemberDTO
{
    public class CreateMemberDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
