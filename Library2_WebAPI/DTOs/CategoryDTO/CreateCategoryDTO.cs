using System.ComponentModel.DataAnnotations;

namespace Library2_WebAPI.DTOs.CategoryDTO
{
    public class CreateCategoryDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
