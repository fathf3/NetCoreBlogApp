using AutoMapper;
using BlogApp.Entity.DTOs.Categories;
using BlogApp.Entity.Entities;
using BlogApp.Service.Services.Abstractions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using BlogApp.Web.ResultMessages.Category;
using FluentValidation.AspNetCore;
using BlogApp.Service.Services.Concretes;

namespace BlogApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IValidator<Category> validator;
        private readonly IMapper mapper;
        private readonly IToastNotification toastNotification;

        public CategoryController(ICategoryService categoryService, IValidator<Category> validator, IMapper mapper, IToastNotification toastNotification)
        {
            this.categoryService = categoryService;
            this.validator = validator;
            this.mapper = mapper;
            this.toastNotification = toastNotification;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await categoryService.GetAllCategoriesNonDeleted();
            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> DeletedCategory()
        {
            var categories = await categoryService.GetAllCategoriesDeleted();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddDTO categoryAddDTO)
        {
            var map = mapper.Map<Category>(categoryAddDTO);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {

                await categoryService.CreateCategoryAsync(categoryAddDTO);
                toastNotification.AddSuccessToastMessage(Messages.Category.Add(categoryAddDTO.Name));
                return RedirectToAction("Index", "Category");
            }


            result.AddToModelState(this.ModelState);
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> AddWithAjax([FromBody] CategoryAddDTO categoryAddDTO)
        {
            var map = mapper.Map<Category>(categoryAddDTO);
            var result = await validator.ValidateAsync(map);
            if (result.IsValid)
            {

                await categoryService.CreateCategoryAsync(categoryAddDTO);
                toastNotification.AddSuccessToastMessage(Messages.Category.Add(categoryAddDTO.Name));
                return Json(Messages.Category.Add(categoryAddDTO.Name));
                
            }
            else
            {
                toastNotification.AddErrorToastMessage(result.Errors.First().ErrorMessage);
                return Json(result.Errors.First().ErrorMessage);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid categoryId)
        {
            var category = await categoryService.GetCategoryByGuid(categoryId);
            var map = mapper.Map<Category, CategoryUpdateDTO>(category);
            return View(map);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateDTO categoryUpdateDTO)
        {
            var map = mapper.Map<Category>(categoryUpdateDTO);
            var result = await validator.ValidateAsync(map);
            if (result.IsValid)
            {
                var name = await categoryService.UpdateCategoryAsync(categoryUpdateDTO);
                toastNotification.AddSuccessToastMessage(Messages.Category.Update(name));
                return RedirectToAction("Index", "Category");
            }


            result.AddToModelState(this.ModelState);
            return View();
        }
        public async Task<IActionResult> Delete(Guid categoryId)
        {
            var name = await categoryService.SafeDeletArticleAsync(categoryId);
            toastNotification.AddSuccessToastMessage(Messages.Category.Delete(name));
            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }
        public async Task<IActionResult> UndoDelete(Guid categoryId)
        {
            var name = await categoryService.UndoDeletArticleAsync(categoryId);
            toastNotification.AddSuccessToastMessage(Messages.Category.Delete(name));
            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }
    }
}
