using BlogApp.Entity.DTOs.Articles;


namespace BlogApp.Service.Services.Abstractions
{
    public interface IArticleService
    {
        Task<List<ArticleDTO>> GetAllArticleWithCategoryNoneDeletedAsync(); 
        Task<List<ArticleDTO>> GetAllArticleWithCategoryDeletedAsync(); 
        Task CreateArticleAsync(ArticleAddDTO articleAddDTO);
        Task<ArticleDTO> GetArticleWithCategoryNonDeletedAsync(Guid articleId);
        Task<string> UpdateArticleAsync(ArticleUpdateDTO articleUpdateDTO);
        Task<string> SafeDeletArticleAsync(Guid articleId);
        Task<string> UndoDeletArticleAsync(Guid articleId);
        Task<ArticleListDTO> GetAllByPagingAsync(Guid? categoryId, int currentPage = 1, int pageSize = 3,
         bool isAscending = false);
        Task<ArticleListDTO> SearchAsync(string keyword, int currentPage = 1, int pageSize = 3,
                bool isAscending = false);
    }
}
