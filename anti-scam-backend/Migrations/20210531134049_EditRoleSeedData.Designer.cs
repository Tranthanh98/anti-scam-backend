﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using anti_scam_backend.Domain.Infrastructure;

namespace anti_scam_backend.Migrations
{
    [DbContext(typeof(AntiScamContext))]
    [Migration("20210531134049_EditRoleSeedData")]
    partial class EditRoleSeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("anti_scam_backend.Domain.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("anti_scam_backend.Domain.Entities.FileAttachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ext")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("PostId");

                    b.ToTable("FileAttachments");
                });

            modelBuilder.Entity("anti_scam_backend.Domain.Entities.FileAttachmentData", b =>
                {
                    b.Property<int>("FileId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Data")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("FileId");

                    b.ToTable("FileAttachmentDatas");
                });

            modelBuilder.Entity("anti_scam_backend.Domain.Entities.Posts", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsHighlight")
                        .HasColumnType("bit");

                    b.Property<int?>("KindOf")
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int?>("View")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("anti_scam_backend.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Quản trị hệ thống",
                            Name = "SystemManager"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Quản trị nội dung",
                            Name = "ContentManger"
                        });
                });

            modelBuilder.Entity("anti_scam_backend.Domain.Entities.RoleAdmin", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RoldId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoldId");

                    b.HasIndex("RoldId");

                    b.ToTable("RoleAdmins");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("3e9e260c-071a-4a9b-a8b7-2f1b880a5fa4"),
                            RoldId = 1
                        },
                        new
                        {
                            UserId = new Guid("3e9e260c-071a-4a9b-a8b7-2f1b880a5fa4"),
                            RoldId = 2
                        },
                        new
                        {
                            UserId = new Guid("0676c0ea-a020-4386-9094-5bb322c07181"),
                            RoldId = 1
                        },
                        new
                        {
                            UserId = new Guid("0676c0ea-a020-4386-9094-5bb322c07181"),
                            RoldId = 2
                        });
                });

            modelBuilder.Entity("anti_scam_backend.Domain.Entities.Type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Types");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Trang web"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Số tài khoản"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Tài khoản MXH"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Số điện thoại"
                        });
                });

            modelBuilder.Entity("anti_scam_backend.Domain.Entities.TypePost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Object")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("TypeId");

                    b.ToTable("TypePosts");
                });

            modelBuilder.Entity("anti_scam_backend.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CodeValidate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("JoinedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3e9e260c-071a-4a9b-a8b7-2f1b880a5fa4"),
                            CodeValidate = "123456",
                            Email = "Trantienthanh2412@gmail.com",
                            IsActive = true,
                            IsAdmin = true,
                            JoinedDate = new DateTimeOffset(new DateTime(2021, 5, 31, 13, 40, 48, 357, DateTimeKind.Unspecified).AddTicks(143), new TimeSpan(0, 0, 0, 0, 0)),
                            Password = "AQAAAAEAACcQAAAAEBAPlUdwTj0sci7gABciifU0cXR+sD/GUUtK99iAzlEcmqzuCE4Z8TflzHN9Nv6+KQ==",
                            Salt = "pscznq",
                            UserName = "Admin"
                        },
                        new
                        {
                            Id = new Guid("0676c0ea-a020-4386-9094-5bb322c07181"),
                            CodeValidate = "123456",
                            Email = "antiscam.contact@gmail.comm",
                            IsActive = true,
                            IsAdmin = true,
                            JoinedDate = new DateTimeOffset(new DateTime(2021, 5, 31, 13, 40, 48, 357, DateTimeKind.Unspecified).AddTicks(3623), new TimeSpan(0, 0, 0, 0, 0)),
                            Password = "AQAAAAEAACcQAAAAEBAPlUdwTj0sci7gABciifU0cXR+sD/GUUtK99iAzlEcmqzuCE4Z8TflzHN9Nv6+KQ==",
                            Salt = "pscznq",
                            UserName = "Admin"
                        });
                });

            modelBuilder.Entity("anti_scam_backend.Domain.Entities.Comment", b =>
                {
                    b.HasOne("anti_scam_backend.Domain.Entities.Posts", "Posts")
                        .WithMany("Comments")
                        .HasForeignKey("PostId");

                    b.HasOne("anti_scam_backend.Domain.Entities.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId");

                    b.Navigation("Posts");

                    b.Navigation("User");
                });

            modelBuilder.Entity("anti_scam_backend.Domain.Entities.FileAttachment", b =>
                {
                    b.HasOne("anti_scam_backend.Domain.Entities.User", "User")
                        .WithMany("FileAttachments")
                        .HasForeignKey("CreatedBy");

                    b.HasOne("anti_scam_backend.Domain.Entities.Posts", "Posts")
                        .WithMany("Images")
                        .HasForeignKey("PostId");

                    b.Navigation("Posts");

                    b.Navigation("User");
                });

            modelBuilder.Entity("anti_scam_backend.Domain.Entities.FileAttachmentData", b =>
                {
                    b.HasOne("anti_scam_backend.Domain.Entities.FileAttachment", "FileAttachment")
                        .WithOne("FileAttachmentData")
                        .HasForeignKey("anti_scam_backend.Domain.Entities.FileAttachmentData", "FileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FileAttachment");
                });

            modelBuilder.Entity("anti_scam_backend.Domain.Entities.Posts", b =>
                {
                    b.HasOne("anti_scam_backend.Domain.Entities.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("CreatedById");

                    b.Navigation("User");
                });

            modelBuilder.Entity("anti_scam_backend.Domain.Entities.RoleAdmin", b =>
                {
                    b.HasOne("anti_scam_backend.Domain.Entities.Role", "Role")
                        .WithMany("RoleAdmins")
                        .HasForeignKey("RoldId")
                        .IsRequired();

                    b.HasOne("anti_scam_backend.Domain.Entities.User", "User")
                        .WithMany("RoleAdmins")
                        .HasForeignKey("UserId")
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("anti_scam_backend.Domain.Entities.TypePost", b =>
                {
                    b.HasOne("anti_scam_backend.Domain.Entities.Posts", "Posts")
                        .WithMany("TypePosts")
                        .HasForeignKey("PostId")
                        .IsRequired();

                    b.HasOne("anti_scam_backend.Domain.Entities.Type", "Type")
                        .WithMany("TypePosts")
                        .HasForeignKey("TypeId")
                        .IsRequired();

                    b.Navigation("Posts");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("anti_scam_backend.Domain.Entities.FileAttachment", b =>
                {
                    b.Navigation("FileAttachmentData");
                });

            modelBuilder.Entity("anti_scam_backend.Domain.Entities.Posts", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Images");

                    b.Navigation("TypePosts");
                });

            modelBuilder.Entity("anti_scam_backend.Domain.Entities.Role", b =>
                {
                    b.Navigation("RoleAdmins");
                });

            modelBuilder.Entity("anti_scam_backend.Domain.Entities.Type", b =>
                {
                    b.Navigation("TypePosts");
                });

            modelBuilder.Entity("anti_scam_backend.Domain.Entities.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("FileAttachments");

                    b.Navigation("Posts");

                    b.Navigation("RoleAdmins");
                });
#pragma warning restore 612, 618
        }
    }
}
