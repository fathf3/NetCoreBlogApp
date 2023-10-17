using BlogApp.Entity.DTOs.Categories;
using BlogApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ArticleDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string CreatedBy { get; set; }
    public int ViewCount { get; set; }
    public Image Image { get; set; }
    public AppUser User { get; set; }
    public CategoryDTO Category { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool IsDeleted { get; set; }
    
}

