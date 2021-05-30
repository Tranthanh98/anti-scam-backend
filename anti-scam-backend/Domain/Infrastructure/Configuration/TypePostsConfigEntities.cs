using anti_scam_backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace anti_scam_backend.Domain.Infrastructure.Configuration
{
    public class TypePostsConfigEntities : IEntityTypeConfiguration<TypePost>
    {
        public void Configure(EntityTypeBuilder<TypePost> builder)
        {
            builder.HasKey(i => i.Id);
            builder.HasOne(i => i.Posts)
                .WithMany(i => i.TypePosts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasForeignKey(i => i.PostId);

            builder.HasOne(i => i.Type)
                .WithMany(i => i.TypePosts)
                .HasForeignKey(i => i.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
