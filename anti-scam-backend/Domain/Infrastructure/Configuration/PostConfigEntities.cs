using anti_scam_backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace anti_scam_backend.Domain.Infrastructure.Configuration
{
    public class PostConfigEntities : IEntityTypeConfiguration<Posts>
    {
        public void Configure(EntityTypeBuilder<Posts> builder)
        {
            builder.HasKey(i => i.Id);
            builder.HasMany(i => i.Comments)
                .WithOne(i => i.Posts)
                .HasForeignKey(i => i.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasMany(i => i.Images)
                .WithOne(i => i.Posts)
                .HasForeignKey(i => i.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(i => i.User)
                .WithMany(i => i.Posts)
                .HasForeignKey(i => i.CreatedById)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
