using System.Drawing.Imaging;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Library2_WebAPI.DTOs.UserDTO;
using Library2_WebAPI.Models;
using Library2_WebAPI.Repos.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Library2_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IConfiguration configuration;
        public AuthController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            this.unitOfWork = unitOfWork;
            this.configuration = configuration;
        }

        [HttpPost("reg")]
        public IActionResult Register(RegisterDTO DTO)
        {
            var ExistingUser = unitOfWork.users.GetuserByName(DTO.UserName);
            if (ExistingUser != null)
            {
                return BadRequest("UserName Already Exists.");
            }
            var user = new User
            {
                UserName = DTO.UserName,
                Role = "Member",
            };
            var PasswordHasher = new PasswordHasher<User>();
            user.PasswordHash = PasswordHasher.HashPassword(user, DTO.Password);
            unitOfWork.users.CreateEntity(user);
            unitOfWork.Save();
            return Created();
        }

        [HttpPost]
        public IActionResult Login(LoginDTO DTO)
        {
            var user = unitOfWork.users.GetuserByName(DTO.UserName);
            if (user == null)
            {
                return BadRequest("UserName not found");
            }
            var PasswordHasher = new PasswordHasher<User>();
            var NotValidPassword = PasswordHasher.VerifyHashedPassword
                (user, user.PasswordHash, DTO.Password) == PasswordVerificationResult.Failed;

            if (NotValidPassword)
            {
                return Unauthorized("Invalid Password");
            }
            var TokenString = GenerateToken(user.UserName);
            var Response = new LoginResponseDTO
            {
                Token = TokenString,
                Expiration = DateTime.Now.AddMinutes(Convert
             .ToDouble(configuration["JWT:Duration"])),
            };
            return Ok(Response);

            
        }
        private string GenerateToken(string username)
        {
            var user = unitOfWork.users.GetuserByName(username);

            //Generate claims 
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier , user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.Role,user.Role)
            };

            //Get securityKey
            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(configuration["JWt:Key"]));

            //Generate Credentials
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //Generate Token
            var token = new JwtSecurityToken(
             issuer: configuration["JWT:Issuer"],
             audience: configuration["JWT:Audience"],
             claims: claims,
             expires: DateTime.Now.AddMinutes(Convert
             .ToDouble(configuration["JWT:Duration"])),
             signingCredentials: creds
             );

            //Convert Token To String
            var TokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return TokenString;

        }
    }
}
