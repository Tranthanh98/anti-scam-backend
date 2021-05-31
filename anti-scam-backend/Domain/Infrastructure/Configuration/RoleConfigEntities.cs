using anti_scam_backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace anti_scam_backend.Domain.Infrastructure.Configuration
{
    public class RoleConfigEntities : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(i => i.Id);

            builder.HasData(
                new Role() { Id = 1, Name = "SystemManager", Description ="Quản trị hệ thống" },
                new Role() { Id = 2, Name = "ContentManger", Description = "Quản trị nội dung" }
                );
        }
    }
}
