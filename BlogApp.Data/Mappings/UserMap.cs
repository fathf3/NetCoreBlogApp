using BlogApp.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            // Primary key
            builder.HasKey(u => u.Id);

            // Indexes for "normalized" username and email, to allow efficient lookups
            builder.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
            builder.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");

            // Maps to the AspNetUsers table
            builder.ToTable("AspNetUsers");

            // A concurrency token for use with the optimistic concurrency checking
            builder.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

            // Limit the size of columns to use efficient database types
            builder.Property(u => u.UserName).HasMaxLength(256);
            builder.Property(u => u.NormalizedUserName).HasMaxLength(256);
            builder.Property(u => u.Email).HasMaxLength(256);
            builder.Property(u => u.NormalizedEmail).HasMaxLength(256);

            // The relationships between User and other entity types
            // Note that these relationships are configured with no navigation properties

            // Each User can have many UserClaims
            builder.HasMany<AppUserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

            // Each User can have many UserLogins
            builder.HasMany<AppUserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

            // Each User can have many UserTokens
            builder.HasMany<AppUserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

            // Each User can have many entries in the UserRole join table
            builder.HasMany<AppUserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();


            var superAdmin = new AppUser
            {
                Id = Guid.Parse("44F8E767-19E2-4A7E-A60A-B32D583BDD9F"),
                FirstName = "Fatih",
                LastName = "Mutlu",
                NormalizedUserName = "FATIH",
                Email = "fatih@hotmail.com",
                NormalizedEmail = "FATIH@HOTMAIL.COM",
                PhoneNumber = "1234567890",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                ImageId = Guid.Parse("FCCB9C4F-E389-4ADC-8D22-D7AC483020C4"),
            };
            superAdmin.PasswordHash = CreatePasswordHash(superAdmin, "123456");
            var admin = new AppUser
            {
                Id = Guid.Parse("DF7ECD49-19A0-4E79-BB3A-EDB17D382675"),
                FirstName = "İsmail",
                LastName = "Mutlu",
                NormalizedUserName = "ISMAIL",
                Email = "ismail@hotmail.com",
                NormalizedEmail = "ISMAIL@HOTMAIL.COM",
                PhoneNumber = "1204567890",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                ImageId = Guid.Parse("FCCB9C4F-E389-4ADC-8D22-D7AC483020C4"),
            };
            admin.PasswordHash = CreatePasswordHash(admin, "123456");
            builder.HasData(superAdmin, admin);
        }
        private string CreatePasswordHash(AppUser user, string password)
        {
            var passwordHasher = new PasswordHasher<AppUser>();
            return passwordHasher.HashPassword(user, password);
        }
    }
}
