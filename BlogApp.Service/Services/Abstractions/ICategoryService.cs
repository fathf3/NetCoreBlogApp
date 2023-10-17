using BlogApp.Entity.DTOs.Categories;
using BlogApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Service.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> GetAllCategoriesNonDeleted();
        Task<List<CategoryDTO>> GetAllCategoriesDeleted();
        Task<List<CategoryDTO>> GetAllCategoriesNoneDeletedTake15();
        Task CreateCategoryAsync(CategoryAddDTO categoryAddDTO);
        Task<Category> GetCategoryByGuid(Guid id);
        Task<string> UpdateCategoryAsync(CategoryUpdateDTO categoryUpdateDTO);
        Task<string> SafeDeletArticleAsync(Guid categoryId);
        Task<string> UndoDeletArticleAsync(Guid categoryId);


    }
}
