using BlogApp.Service.FluentValidations;
using BlogApp.Service.Helpers.Images;
using BlogApp.Service.Services.Abstractions;
using BlogApp.Service.Services.Concretes;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Reflection;

namespace BlogApp.Service.Extensions
{
    public static class ServiceLayerExtension
    {
        public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services, IConfiguration configuration)
        {

            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assembly);

            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IImageHelper, ImageHelper>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDashboardService, DashboardService>();
            // Giris yapan kullanıcı bulmamıza yarıyor.
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            
            services.AddControllersWithViews().AddFluentValidation(opt => 
            {
                opt.RegisterValidatorsFromAssemblyContaining<ArticleValidator>();
                opt.DisableDataAnnotationsValidation = true;
                opt.ValidatorOptions.LanguageManager.Culture = new CultureInfo("tr");
            });
            
            

            return services;

        }
    }
}
