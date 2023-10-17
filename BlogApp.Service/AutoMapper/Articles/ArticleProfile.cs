using AutoMapper;
using BlogApp.Entity.DTOs.Articles;
using BlogApp.Entity.Entities;

namespace BlogApp.Service.AutoMapper.Articles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<Article, ArticleDTO>().ReverseMap();
            CreateMap<Article, ArticleUpdateDTO>().ReverseMap();
            CreateMap<Article,ArticleAddDTO>().ReverseMap();
            CreateMap<ArticleDTO, ArticleListDTO>().ReverseMap(); 
            CreateMap<ArticleDTO, ArticleUpdateDTO> ().ReverseMap();
        }
    }
}
