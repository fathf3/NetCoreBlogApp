using AutoMapper;
using BlogApp.Entity.DTOs.Users;
using BlogApp.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Web.Areas.Admin.ViewComponents
{
    public class DashboardHeaderViewComponent : ViewComponent
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IMapper mapper;

        public DashboardHeaderViewComponent(UserManager<AppUser> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loggedUser = await userManager.GetUserAsync(HttpContext.User);
            var map = mapper.Map<UserDTO>(loggedUser);

            var role = string.Join("", await userManager.GetRolesAsync(loggedUser));
            map.Role = role;

            return View(map);

        }

    }
}
