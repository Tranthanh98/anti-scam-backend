using anti_scam_backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace anti_scam_backend.Domain.Infrastructure.Configuration
{
    public class RoleAdminConfigEntities : IEntityTypeConfiguration<RoleAdmin>
    {
        public void Configure(EntityTypeBuilder<RoleAdmin> builder)
        {
            builder.HasKey(i => new { i.UserId, i.RoldId });

            builder.HasOne(i => i.User)
                .WithMany(i => i.RoleAdmins)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(i => i.Role)
                .WithMany(i => i.RoleAdmins)
                .HasForeignKey(i => i.RoldId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasData(
                new RoleAdmin()
                {
                    RoldId = 1,
                    UserId = Settings.UserId,
                },
                new RoleAdmin()
                {
                    RoldId = 2,
                    UserId = Settings.UserId,
                },
                new RoleAdmin()
                {
                    RoldId = 1,
                    UserId = Settings.UserIdAdmin,
                },
                new RoleAdmin()
                {
                    RoldId = 2,
                    UserId = Settings.UserIdAdmin,
                });
        }
    }
}
