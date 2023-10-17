using BlogApp.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category
            {
                Id = Guid.Parse("E3E8C34A-3536-4F48-8E48-E14B33ACACFE"),
                Name = "ASP.NET Core",
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            },
            new Category
            {
                Id = Guid.Parse("E85FE282-3469-4922-857F-6CEA0D8BCE78"),
                Name = "Python Gelistirme",
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now.AddDays(-2),
                IsDeleted = false,
            }
            );
        }
    }
}
