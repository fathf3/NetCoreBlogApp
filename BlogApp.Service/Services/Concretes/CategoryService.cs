﻿using AutoMapper;
using BlogApp.Data.UnitOfWorks;
using BlogApp.Entity.DTOs.Categories;
using BlogApp.Entity.Entities;
using BlogApp.Service.Extensions;
using BlogApp.Service.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Service.Services.Concretes
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ClaimsPrincipal user;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.user = httpContextAccessor.HttpContext.User;
        }

        public async Task<List<CategoryDTO>> GetAllCategoriesNonDeleted()
        {
            var catagories = await unitOfWork.GetRepository<Category>().GetAllAsync(x=> !x.IsDeleted);
            var map = mapper.Map<List<CategoryDTO>>(catagories);
            return map;
        }

        public async Task CreateCategoryAsync(CategoryAddDTO categoryAddDTO)
        {
            
            var userEmail = user.GetLoggedInEmail();
            Category category = new(categoryAddDTO.Name, userEmail);
            await unitOfWork.GetRepository<Category>().AddAsync(category);
            await unitOfWork.SaveAsync();           
        }
        public async Task<Category> GetCategoryByGuid(Guid id)
        {
            var category = await unitOfWork.GetRepository<Category>().GetByGuidAsync(id);
            return category;
        }
        public async Task<string> UpdateCategoryAsync(CategoryUpdateDTO categoryUpdateDTO)
        {
            var category = await unitOfWork.GetRepository<Category>().GetAsync(x => !x.IsDeleted && x.Id == categoryUpdateDTO.Id);
            var userEmail = user.GetLoggedInEmail();

            category.Name = categoryUpdateDTO.Name;
            category.ModifiedBy = userEmail;
            category.ModifiedDate = DateTime.Now;
            await unitOfWork.GetRepository<Category>().UpdateAsync(category);
            await unitOfWork.SaveAsync();
            return category.Name;
        }

        public async Task<string> SafeDeletArticleAsync(Guid categoryId)
        {
            var userEmail = user.GetLoggedInEmail();
            var category = await unitOfWork.GetRepository<Category>().GetByGuidAsync(categoryId);
            category.IsDeleted = true;
            category.DeletedDate = DateTime.Now;
            category.DeletedBy = userEmail;
            await unitOfWork.GetRepository<Category>().UpdateAsync(category);
            await unitOfWork.SaveAsync();
            return category.Name;
        }

        public async Task<List<CategoryDTO>> GetAllCategoriesDeleted()
        {
            var catagories = await unitOfWork.GetRepository<Category>().GetAllAsync(x => x.IsDeleted);
            var map = mapper.Map<List<CategoryDTO>>(catagories);
            return map;
        }

        public async Task<string> UndoDeletArticleAsync(Guid categoryId)
        {
            var userEmail = user.GetLoggedInEmail();
            var category = await unitOfWork.GetRepository<Category>().GetByGuidAsync(categoryId);
            category.IsDeleted = false;
            category.DeletedDate = null;
            category.DeletedBy = null;
            await unitOfWork.GetRepository<Category>().UpdateAsync(category);
            await unitOfWork.SaveAsync();
            return category.Name;
        }

        public async Task<List<CategoryDTO>> GetAllCategoriesNoneDeletedTake15()
        {
            var catagories = await unitOfWork.GetRepository<Category>().GetAllAsync(x => !x.IsDeleted);
            var map = mapper.Map<List<CategoryDTO>>(catagories);
            
            return map.Take(15).ToList();
        }
    }
}
