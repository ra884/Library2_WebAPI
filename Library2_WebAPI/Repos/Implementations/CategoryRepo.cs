using Library2_WebAPI.Data;
using Library2_WebAPI.DTOs.CategoryDTO;
using Library2_WebAPI.Models;
using Library2_WebAPI.Repos.Interfaces;

namespace Library2_WebAPI.Repos.Implementations
{
    public class CategoryRepo : GenericRepo<Category>, ICategoryRepo
    {
        private readonly AppDbContext context;

        public CategoryRepo(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public ICollection<GetCategoryDTO> GetCategories()
        {
            var categories = context.Categories.Select(c => new GetCategoryDTO
            {
                Name = c.Name,
                BooksCount = c.Books.Count()
            }).ToList();
            return categories;
        }



    }
            
        

}
