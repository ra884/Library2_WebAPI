using System.ComponentModel.DataAnnotations;

namespace Library2_WebAPI.DTOs.UserDTO
{
    public class RegisterDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
