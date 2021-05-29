using anti_scam_backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace anti_scam_backend.Domain.Infrastructure.Configuration
{
    public class FileAttachmentConfigEntities : IEntityTypeConfiguration<FileAttachment>
    {
        public void Configure(EntityTypeBuilder<FileAttachment> builder)
        {
            builder.HasKey(i => i.Id);
            builder.HasOne(i => i.FileAttachmentData)
                .WithOne(i => i.FileAttachment)
                .HasForeignKey<FileAttachmentData>(p => p.FileId);

            builder.HasOne(i => i.User)
                .WithMany(i => i.FileAttachments)
                .HasForeignKey(i => i.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
