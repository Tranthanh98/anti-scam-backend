using anti_scam_backend.Domain.Entities;
using anti_scam_backend.Domain.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace anti_scam_backend.Domain.Infrastructure
{
    public class AntiScamContext: DbContext
    {
        public AntiScamContext() { }
        public AntiScamContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Posts> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Entities.Type> Types { get; set; }
        public DbSet<TypePost> TypePosts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<FileAttachment> FileAttachments { get; set; }
        public DbSet<FileAttachmentData> FileAttachmentDatas { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleAdmin> RoleAdmins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostConfigEntities());
            modelBuilder.ApplyConfiguration(new CommentConfigEntities());
            modelBuilder.ApplyConfiguration(new TypeConfigEntities());
            modelBuilder.ApplyConfiguration(new TypePostsConfigEntities());
            modelBuilder.ApplyConfiguration(new UserConfigEntities());
            modelBuilder.ApplyConfiguration(new FileAttachmentConfigEntities());

            modelBuilder.ApplyConfiguration(new RoleAdminConfigEntities());
            modelBuilder.ApplyConfiguration(new RoleConfigEntities());


            modelBuilder.Entity<FileAttachmentData>(option =>
                option.HasKey(i => i.FileId)
            );
        }

    }
}
