using BlogApp.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogApp.Data.Mappings
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(150);

            builder.HasData(new Article
            {
                Id = Guid.Parse("415EB209-E5DE-4CF7-B420-F4096488E006"),
                Title = "ASP.NET CORE 6 Egitim",
                ViewCount = 12,
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras sit amet aliquam tortor, et tincidunt metus. Donec a magna tempus, facilisis erat ut, laoreet massa. Cras finibus libero purus, ac fringilla nunc hendrerit sed. ",
                CategoryId = Guid.Parse("E3E8C34A-3536-4F48-8E48-E14B33ACACFE"),
                ImageId = Guid.Parse("FCCB9C4F-E389-4ADC-8D22-D7AC483020C4"),
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now.AddDays(-2),
                IsDeleted = false,
                UserId = Guid.Parse("44F8E767-19E2-4A7E-A60A-B32D583BDD9F"),

            },
            new Article
            {
                Id = Guid.Parse("55C9F789-10CF-48C1-A121-A5F7A55352B9"),
                Title = "Python Diziler",
                ViewCount = 12,
                Content = "Duis lobortis turpis augue, a suscipit diam elementum non. Vivamus in sodales purus, eget tincidunt massa. Praesent sed laoreet ipsum. ",
                CategoryId = Guid.Parse("E85FE282-3469-4922-857F-6CEA0D8BCE78"),
                ImageId = Guid.Parse("A1FDF4C4-5681-44F5-8D06-982F3708BACF"),
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                UserId = Guid.Parse("44F8E767-19E2-4A7E-A60A-B32D583BDD9F"),
            }) ;
        }
    }
}
