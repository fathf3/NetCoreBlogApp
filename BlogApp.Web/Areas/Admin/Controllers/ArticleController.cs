using AutoMapper;
using BlogApp.Entity.DTOs.Articles;
using BlogApp.Entity.Entities;
using BlogApp.Service.Services.Abstractions;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using BlogApp.Web.ResultMessages.Article;
using Microsoft.AspNetCore.Authorization;
using BlogApp.Web.Consts;

namespace BlogApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    public class ArticleController : Controller
    {
        private readonly IArticleService articleService;
        private readonly IMapper mapper;
        private readonly ICategoryService categoryService;
        private readonly IValidator<Article> validator;
        private readonly IToastNotification toastNotification;

        public ArticleController(IArticleService articleService, IMapper mapper, ICategoryService categoryService, IValidator<Article> validator, IToastNotification toastNotification)
        {
            this.articleService = articleService;
            this.mapper = mapper;
            this.categoryService = categoryService;
            this.validator = validator;
            this.toastNotification = toastNotification;
        }
        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Admin}, {RoleConsts.Superadmin}, {RoleConsts.User}")]
        public async Task<IActionResult> Index()
        {
            var articles = await articleService.GetAllArticleWithCategoryNoneDeletedAsync();
            
            return View(articles);
        }
        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Admin}, {RoleConsts.Superadmin}")]
        public async Task<IActionResult> DeletedArticles()
        {
            var articles = await articleService.GetAllArticleWithCategoryDeletedAsync();

            return View(articles);
        }


        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Admin}, {RoleConsts.Superadmin}")]
        public async Task<IActionResult> Add()
        {
            var categories = await categoryService.GetAllCategoriesNonDeleted();
            return View(new ArticleAddDTO {Categories = categories });
        }
        [HttpPost]
        [Authorize(Roles = $"{RoleConsts.Admin}, {RoleConsts.Superadmin}")]
        public async Task<IActionResult> Add(ArticleAddDTO articleAddDTO)
        {
            var map = mapper.Map<Article>(articleAddDTO);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {

                await articleService.CreateArticleAsync(articleAddDTO);
                toastNotification.AddSuccessToastMessage(Messages.Article.Add(articleAddDTO.Title));
                return RedirectToAction("Index", "Article");
                
            }
                
            else
            {
                result.AddToModelState(this.ModelState);
                var categories = await categoryService.GetAllCategoriesNonDeleted();
                return View(new ArticleAddDTO { Categories = categories });
            }
            

        }
        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Admin}, {RoleConsts.Superadmin}")]
        public async Task<IActionResult> Update(Guid articleId)
        {
            var article = await articleService.GetArticleWithCategoryNonDeletedAsync(articleId);
            var categories = await categoryService.GetAllCategoriesNonDeleted();

            var articleUpdateDTO = mapper.Map<ArticleUpdateDTO>(article);
            articleUpdateDTO.Categories = categories;

            return View(articleUpdateDTO);
        }

        [HttpPost]
        [Authorize(Roles = $"{RoleConsts.Admin}, {RoleConsts.Superadmin}")]
        public async Task<IActionResult> Update(ArticleUpdateDTO articleUpdateDTO)
        {
            var map = mapper.Map<Article>(articleUpdateDTO);
            var result = await validator.ValidateAsync(map);


            if(result.IsValid)
            {
                var title = await articleService.UpdateArticleAsync(articleUpdateDTO);
                toastNotification.AddSuccessToastMessage(Messages.Article.Update(title));
                return RedirectToAction("Index", "Article", new { Area = "Admin" });
            }
            else
            {
                result.AddToModelState(this.ModelState);
            }
            
            var categories = await categoryService.GetAllCategoriesNonDeleted();
            articleUpdateDTO.Categories = categories;
            return View(articleUpdateDTO);
        }
        [Authorize(Roles = $"{RoleConsts.Admin}, {RoleConsts.Superadmin}")]
        public async Task<IActionResult> Delete(Guid articleId)
        {
            var title = await articleService.SafeDeletArticleAsync(articleId);
            toastNotification.AddSuccessToastMessage(Messages.Article.Delete(title));
            return RedirectToAction("Index", "Article" , new {Area ="Admin"});
        }
        [Authorize(Roles = $"{RoleConsts.Superadmin}")]
        public async Task<IActionResult> UndoDelete(Guid articleId)
        {
            var title = await articleService.UndoDeletArticleAsync(articleId);
            toastNotification.AddSuccessToastMessage(Messages.Article.UndoDelete(title));
            return RedirectToAction("Index", "Article", new { Area = "Admin" });
        }


    }
}
