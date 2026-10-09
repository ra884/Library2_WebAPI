using AutoMapper;
using Library2_WebAPI.Data;
using Library2_WebAPI.DTOs.CategoryDTO;
using Library2_WebAPI.Models;
using Library2_WebAPI.Repos.Implementations;
using Library2_WebAPI.Repos.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library2_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;   
            this.mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDTO categoryDTO)
        {
            if (categoryDTO == null)
            {
                return BadRequest("Category data is null.");
            }
            var Category = mapper.Map<Category>(categoryDTO);
            unitOfWork.categories.CreateEntity(Category);
            unitOfWork.Save();
            return Created();
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = unitOfWork.categories.GetCategories();
            if (categories == null)
            {
                return NotFound("No categoris found");
            }
            return Ok(categories);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategories(int id)
        {
            var category=unitOfWork.categories.GetById(id);
            unitOfWork.categories.DeleteEntity(category);
            unitOfWork.Save();
            return NoContent();
        }
    }
}
