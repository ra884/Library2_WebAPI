namespace Library2_WebAPI.DTOs.UserDTO
{
    public class LoginResponseDTO
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
