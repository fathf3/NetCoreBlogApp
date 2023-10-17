using AutoMapper;
using BlogApp.Data.UnitOfWorks;
using BlogApp.Entity.DTOs.Articles;
using BlogApp.Entity.DTOs.Users;
using BlogApp.Entity.Entities;
using BlogApp.Entity.Enums;
using BlogApp.Service.Extensions;
using BlogApp.Service.Helpers.Images;
using BlogApp.Service.Services.Abstractions;
using BlogApp.Web.ResultMessages.User;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using static BlogApp.Web.ResultMessages.User.Messages;

namespace BlogApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserService userService;
       
        private readonly IMapper mapper;
        private readonly IToastNotification toastNotification;
        private readonly IValidator<AppUser> validator;

        public UserController(IUserService userService, IMapper mapper, IToastNotification toastNotification, IValidator<AppUser> validator)
        {
            this.userService = userService;
            this.mapper = mapper;
            this.toastNotification = toastNotification;
            this.validator = validator;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await userService.GetAllUsersWithRoleAsync();
            return View(result);
        }
        
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var roles = await userService.GetAllRolesAsync();

            return View(new UserAddDTO { Roles = roles });
        }
        
        [HttpPost]
        public async Task<IActionResult> Add(UserAddDTO userAddDTO)
        {
            var map = mapper.Map<AppUser>(userAddDTO);
            var validation = await validator.ValidateAsync(map);
            var roles = await userService.GetAllRolesAsync();
            if (ModelState.IsValid)
            {
                var result = await userService.CreateUserAsync(userAddDTO);
                if (result.Succeeded)
                {
                    toastNotification.AddSuccessToastMessage(Messages.User.Add(userAddDTO.Email));
                    return RedirectToAction("Index", "User", new { Area = "Admin" });

                }
                else
                {
                    result.AddToIdentityModelState(this.ModelState);
                    validation.AddToModelState(this.ModelState);
                    return View();
                }
            }
            return View();


        }
        
        [HttpGet]
        public async Task<IActionResult> Update(Guid userId)
        {
            var user = await userService.GetAppUserByIdAsync(userId);
            var roles = await userService.GetAllRolesAsync();

            var map = mapper.Map<UserUpdateDTO>(user);

            map.Roles = roles;

            return View(map);
        }
        
        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateDTO userUpdateDTO)
        {
            var user = await userService.GetAppUserByIdAsync(userUpdateDTO.Id);

            if (user != null)
            {
                var roles = await userService.GetAllRolesAsync();


                if (ModelState.IsValid)
                {
                    var map = mapper.Map(userUpdateDTO, user);
                    var validation = await validator.ValidateAsync(map);
                    if (validation.IsValid)
                    {


                        user.UserName = userUpdateDTO.Email;
                        user.SecurityStamp = Guid.NewGuid().ToString();
                        var result = await userService.UpdateUserAsync(userUpdateDTO);

                        if (result.Succeeded)
                        {

                            toastNotification.AddSuccessToastMessage(Messages.User.Update(userName: userUpdateDTO.Email));
                            return RedirectToAction("Index", "User", new { Area = "Admin" });
                        }
                        else
                        {
                            result.AddToIdentityModelState(this.ModelState);
                            return View(new UserUpdateDTO { Roles = roles });
                        }
                    }
                    else
                    {
                        validation.AddToModelState(this.ModelState);
                        return View(new UserUpdateDTO { Roles = roles });
                    }
                }
            }

            return NotFound();
        }
        
        [HttpGet]
        public async Task<IActionResult> Delete(Guid userId)
        {

            var result = await userService.DeleteUserAsync(userId);
            if (result.identityResult.Succeeded)
            {
                toastNotification.AddSuccessToastMessage(Messages.User.Delete(result.email));
                return RedirectToAction("Index", "User", new { Area = "Admin" });
            }
            else
            {
                result.identityResult.AddToIdentityModelState(this.ModelState);
            }
            return NotFound();
        }
        
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var profile = await userService.GetUserProfileAsync();
            return View(profile);
        }
        
        [HttpPost]
        public async Task<IActionResult> Profile(UserProfileDTO userProfileDto)
        {
            
            if (ModelState.IsValid && userProfileDto.CurrentPassword != null)
            {

                var result = await userService.UserProfileUpdateAsync(userProfileDto);

                if (result)
                {
                    toastNotification.AddSuccessToastMessage(Messages.User.Update(userProfileDto.Email));
                    return RedirectToAction("Index", "Home", new { Area = "Admin" });
                }
                else
                {
                    var profile = await userService.GetUserProfileAsync();
                    toastNotification.AddErrorToastMessage("Güncelleme işlemi başarısız oldu");
                    return View(profile);
                }
            }
            else if (userProfileDto.CurrentPassword == null)
            {
                var profile = await userService.GetUserProfileAsync();
                toastNotification.AddWarningToastMessage("Lütfen şifrenizi giriniz");
                return View(profile);
            }

            
            else
            {
                return NotFound();
            }
                  
            
        }
    }
}
