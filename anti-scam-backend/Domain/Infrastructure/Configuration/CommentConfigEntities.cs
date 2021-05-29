using anti_scam_backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace anti_scam_backend.Domain.Infrastructure.Configuration
{
    public class CommentConfigEntities : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(i => i.Id);

            builder.HasOne(i => i.User)
                .WithMany(i => i.Comments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasForeignKey(i => i.UserId);

        }
    }
}
