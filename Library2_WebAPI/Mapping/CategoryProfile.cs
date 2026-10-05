using AutoMapper;
using Library2_WebAPI.DTOs.CategoryDTO;
using Library2_WebAPI.Models;

namespace Library2_WebAPI.Mapping
{
    public class CategoryRepo:Profile
    {
        public CategoryRepo()
        {
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category,GetCategoryDTO>().ReverseMap();
        }
    }
}
