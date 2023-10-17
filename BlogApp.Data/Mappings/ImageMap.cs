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
    public class ImageMap : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasData(new Image
            {
                Id = Guid.Parse("FCCB9C4F-E389-4ADC-8D22-D7AC483020C4"),
                FileType = "jpg",
                FileName = "image/image",
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now.AddDays(-2),
                IsDeleted = false,

            },
            new Image{
                Id = Guid.Parse("A1FDF4C4-5681-44F5-8D06-982F3708BACF"),
                FileType = "jpg",
                FileName = "image/image2",
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            });
        }
    }
}
