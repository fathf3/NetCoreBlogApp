using BlogApp.Entity.DTOs.Users;
using BlogApp.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Service.Services.Abstractions
{
    public interface IUserService
    {

        Task<List<UserDTO>> GetAllUsersWithRoleAsync();
        Task<List<AppRole>> GetAllRolesAsync();
        Task<IdentityResult> CreateUserAsync(UserAddDTO userAddDTO);
        Task<IdentityResult> UpdateUserAsync(UserUpdateDTO userUpdateDTO);
        Task<(IdentityResult identityResult, string? email)> DeleteUserAsync(Guid userId);
        Task<AppUser> GetAppUserByIdAsync(Guid userId);
        Task<string> GetUserRoleAsync(AppUser user);
        Task<UserProfileDTO> GetUserProfileAsync();
        Task<bool> UserProfileUpdateAsync(UserProfileDTO userProfileDTO);









    }
}
