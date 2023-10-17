using BlogApp.Data.Context;
using BlogApp.Data.Repositories.Abstractions;
using BlogApp.Data.Repositories.Concretes;
using BlogApp.Data.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogApp.Data.Extensions
{
    public static class DataLayerExtension
    {
        public static IServiceCollection LoadDataLayerExtension(this IServiceCollection services, IConfiguration configuration)
        {
            // Database baglanti
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString")));

            // DI - IoC
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork , UnitOfWork>();
           


            return services;

        }
    }
}
