using Library2_WebAPI.DTOs.CategoryDTO;
using Library2_WebAPI.Models;

namespace Library2_WebAPI.Repos.Interfaces
{
    public interface ICategoryRepo:IGenericRepo<Category>
    {
        public ICollection<GetCategoryDTO> GetCategories();
    }
}
