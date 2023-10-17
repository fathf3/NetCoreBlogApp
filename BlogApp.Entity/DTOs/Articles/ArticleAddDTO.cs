using BlogApp.Entity.DTOs.Categories;
using Microsoft.AspNetCore.Http;

namespace BlogApp.Entity.DTOs.Articles
{
    public class ArticleAddDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid CategoryId { get; set; }

        public IFormFile Photo { get; set; }

        public IList<CategoryDTO> Categories { get; set; }
    }
}
