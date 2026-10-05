using AutoMapper;
using Library2_WebAPI.Data;
using Library2_WebAPI.DTOs.MemberDTO;
using Library2_WebAPI.Repos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Library2_WebAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Library2_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public MemberController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateMember(CreateMemberDTO memberDTO)
        {
            if (memberDTO == null)
            {
                return BadRequest("Member data is null.");
            }
            var member = mapper.Map<Member>(memberDTO);
            unitOfWork.members.CreateEntity(member);
            unitOfWork.Save();
            return Created();

        }

        [HttpGet("{id}")]
        public IActionResult GetMember(int id)
        {
            var member=unitOfWork.members.GetStatisticsDTO(id);
            return Ok(member);
        }

        [HttpGet("top-readers")]
        public IActionResult TopMembers()
        {
            var members=unitOfWork.members.TopMembers();
            var membersDTO=mapper.Map<ICollection<TopMembersDTO>>(members);
            return Ok(membersDTO);
        }
    }
}
