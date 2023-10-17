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
    public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("AspNetUserRoles");

            builder.HasData(new AppUserRole
            {
                UserId = Guid.Parse("DF7ECD49-19A0-4E79-BB3A-EDB17D382675"),
                RoleId = Guid.Parse("E91AB1A9-ED39-4B3D-8941-5A104E625B69")

            },
            new AppUserRole
            {
                UserId = Guid.Parse("44F8E767-19E2-4A7E-A60A-B32D583BDD9F"),
                RoleId = Guid.Parse("0C950313-876B-4F94-8B8B-D5D6705087BA")
            });
        }
    }
}
