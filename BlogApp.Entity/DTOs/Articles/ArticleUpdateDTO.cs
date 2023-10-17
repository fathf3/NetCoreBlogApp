using BlogApp.Entity.DTOs.Categories;
using BlogApp.Entity.Entities;
using Microsoft.AspNetCore.Http;

public class ArticleUpdateDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public Image Image { get; set; }
    public IFormFile Photo { get; set; }
    public Guid CategoryId { get; set; }
    public IList<CategoryDTO> Categories { get; set; }
}

