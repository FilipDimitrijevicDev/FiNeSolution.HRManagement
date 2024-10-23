﻿// <auto-generated />
using System;
using Core.Infrastructure.Identity.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Core.Infrastructure.Migrations.IdentityDb
{
    [DbContext(typeof(IdentityDbContext))]
    partial class IdentityDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Domain.Candidate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CVPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("Seniority")
                        .HasColumnType("int");

                    b.Property<int>("StackPosition")
                        .HasColumnType("int");

                    b.Property<Guid>("Uid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Candidate");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CVPath = "/uploads/john_doe_cv.pdf",
                            CreatedDate = new DateTime(2024, 10, 23, 18, 6, 33, 405, DateTimeKind.Utc).AddTicks(3605),
                            DateOfBirth = new DateOnly(1990, 5, 15),
                            Email = "john.doe@example.com",
                            FirstName = "John",
                            LastName = "Doe",
                            Note = "Candidate shows strong skills in backend development.",
                            Rating = 4,
                            Seniority = 3,
                            StackPosition = 1,
                            Uid = new Guid("3402484c-8383-48ff-a35e-ca4df1995a35")
                        },
                        new
                        {
                            Id = 2,
                            CVPath = "/uploads/alice_smith_cv.pdf",
                            CreatedDate = new DateTime(2024, 10, 23, 18, 6, 33, 405, DateTimeKind.Utc).AddTicks(3664),
                            DateOfBirth = new DateOnly(1985, 12, 30),
                            Email = "alice.smith@example.com",
                            FirstName = "Alice",
                            LastName = "Smith",
                            Note = "Experienced project manager with a strong background in Agile methodologies.",
                            Rating = 5,
                            Seniority = 3,
                            StackPosition = 2,
                            Uid = new Guid("2c7939a3-1a4c-4fe9-9eda-90ffda2009c1")
                        },
                        new
                        {
                            Id = 3,
                            CVPath = "/uploads/michael_johnson_cv.pdf",
                            CreatedDate = new DateTime(2024, 10, 23, 18, 6, 33, 405, DateTimeKind.Utc).AddTicks(3681),
                            DateOfBirth = new DateOnly(1992, 4, 10),
                            Email = "michael.johnson@example.com",
                            FirstName = "Michael",
                            LastName = "Johnson",
                            Note = "Front-end developer with expertise in React and Vue.js.",
                            Rating = 3,
                            Seniority = 1,
                            StackPosition = 0,
                            Uid = new Guid("5d65be7b-c223-48c2-a9d4-49e140def2b6")
                        },
                        new
                        {
                            Id = 4,
                            CVPath = "/uploads/emma_williams_cv.pdf",
                            CreatedDate = new DateTime(2024, 10, 23, 18, 6, 33, 405, DateTimeKind.Utc).AddTicks(3686),
                            DateOfBirth = new DateOnly(1988, 8, 25),
                            Email = "emma.williams@example.com",
                            FirstName = "Emma",
                            LastName = "Williams",
                            Note = "Full-stack developer with strong skills in Node.js and .NET Core.",
                            Rating = 4,
                            Seniority = 1,
                            StackPosition = 2,
                            Uid = new Guid("eb619ca0-0cc3-46ee-b52a-faa88b9f6b17")
                        },
                        new
                        {
                            Id = 5,
                            CVPath = "/uploads/david_brown_cv.pdf",
                            CreatedDate = new DateTime(2024, 10, 23, 18, 6, 33, 405, DateTimeKind.Utc).AddTicks(3700),
                            DateOfBirth = new DateOnly(1995, 11, 15),
                            Email = "david.brown@example.com",
                            FirstName = "David",
                            LastName = "Brown",
                            Note = "DevOps engineer with experience in CI/CD pipelines and containerization.",
                            Rating = 5,
                            Seniority = 2,
                            StackPosition = 4,
                            Uid = new Guid("81d41adc-6b3f-4b4b-a1fd-cef466b0f8e1")
                        });
                });

            modelBuilder.Entity("Core.Domain.LeaveType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DefaultDays")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("RequiresHRApproval")
                        .HasColumnType("bit");

                    b.Property<Guid>("Uid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("LeaveType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 10, 23, 20, 6, 33, 406, DateTimeKind.Local).AddTicks(4173),
                            DefaultDays = 21,
                            Name = "Vacation",
                            RequiresHRApproval = true,
                            Uid = new Guid("c13d5926-2d3d-4f95-a90e-728914094c9a")
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2024, 10, 23, 20, 6, 33, 406, DateTimeKind.Local).AddTicks(4334),
                            DefaultDays = 15,
                            Name = "Old Vacation",
                            RequiresHRApproval = true,
                            Uid = new Guid("c9edbebf-6ece-4c95-85c5-dc4324fb624e")
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2024, 10, 23, 20, 6, 33, 406, DateTimeKind.Local).AddTicks(4337),
                            DefaultDays = 15,
                            Name = "Remote Work",
                            RequiresHRApproval = true,
                            Uid = new Guid("2c4fb57a-8fc6-42c7-9000-f0d827f273a0")
                        },
                        new
                        {
                            Id = 5,
                            CreatedDate = new DateTime(2024, 10, 23, 20, 6, 33, 406, DateTimeKind.Local).AddTicks(4339),
                            DefaultDays = 365,
                            Name = "Sick Leave",
                            RequiresHRApproval = false,
                            Uid = new Guid("58d21e95-9478-4732-a973-3ab477500818")
                        });
                });

            modelBuilder.Entity("Core.Infrastructure.Identity.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "42df1250-85ef-4683-9046-6f2e5405ee3a",
                            AccessFailedCount = 0,
                            CompanyName = "System",
                            ConcurrencyStamp = "01133198-250b-4ba9-bf9e-6e65f58b987a",
                            DateOfBirth = new DateOnly(1995, 1, 14),
                            Email = "admin@localhost.com",
                            EmailConfirmed = true,
                            FirstName = "System",
                            LastName = "Admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@LOCALHOST.COM",
                            NormalizedUserName = "ADMIN@LOCALHOST.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEIzlmTaiZXls81f7x+aePMkDL2yDBWuQNoc/nbQxN6/obLZH82cr53CthESaHHosgw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7f7e3680-ed8c-484f-a77a-1624571d0d0f",
                            TwoFactorEnabled = false,
                            UserName = "admin@localhost.com"
                        },
                        new
                        {
                            Id = "48a3b0de-d24d-4879-a528-ddaf38580270",
                            AccessFailedCount = 0,
                            CompanyName = "System",
                            ConcurrencyStamp = "e21d5737-fced-4aaa-96ed-28f7c931c6db",
                            DateOfBirth = new DateOnly(1995, 1, 14),
                            Email = "companyadmin@localhost.com",
                            EmailConfirmed = true,
                            FirstName = "Company",
                            LastName = "Admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "COMPANYADMIN@LOCALHOST.COM",
                            NormalizedUserName = "COMPANYADMIN@LOCALHOST.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEBrAXDJ8xDY8DETzxlLIXopp4lYeSwGifs/OGHfubczaF0+eSEodh1ws+ff1MplXMg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "c8a0a664-e4d3-4334-83ff-75b4a2c82cb4",
                            TwoFactorEnabled = false,
                            UserName = "companyadmin@localhost.com"
                        },
                        new
                        {
                            Id = "2499bc5a-0f33-4f67-b521-5829679ee7ff",
                            AccessFailedCount = 0,
                            CompanyName = "System",
                            ConcurrencyStamp = "e049fc8f-ffef-470f-9622-610835b7d0b4",
                            DateOfBirth = new DateOnly(1995, 1, 14),
                            Email = "user@localhost.com",
                            EmailConfirmed = true,
                            FirstName = "System",
                            LastName = "User",
                            LockoutEnabled = false,
                            NormalizedEmail = "USER@LOCALHOST.COM",
                            NormalizedUserName = "USER@LOCALHOST.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEIt4TFDYLGhMXk9b3WnFofTb5BCi7zJ4zFLcXREQnll0HNOGBAfT8FPXSfQQryDmtw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "9014f7a6-6007-429b-ae5f-66831c18740d",
                            TwoFactorEnabled = false,
                            UserName = "user@localhost.com"
                        },
                        new
                        {
                            Id = "306627f3-c902-4d48-a6f3-d83db48df2c6",
                            AccessFailedCount = 0,
                            CompanyName = "System",
                            ConcurrencyStamp = "c0345cc1-870a-4ed7-9b58-33503bc3f5e2",
                            DateOfBirth = new DateOnly(1995, 1, 14),
                            Email = "hr@localhost.com",
                            EmailConfirmed = true,
                            FirstName = "Hr",
                            LastName = "Hr",
                            LockoutEnabled = false,
                            NormalizedEmail = "HR@LOCALHOST.COM",
                            NormalizedUserName = "HR@LOCALHOST.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEGJIGzs7yhNRr+gm3+RQZaVrb6EgJJpo12Qk1MqtZ3GBjsre90U9pAGJsD1OatYk0Q==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "a9f73efb-268a-4f43-9012-ac8fbd57e8c5",
                            TwoFactorEnabled = false,
                            UserName = "hr@localhost.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "995d5439-2b54-458a-b08d-e0f289255a96",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "ebc687e2-03df-4448-b79e-32e3e39de6bc",
                            Name = "Company Administrator",
                            NormalizedName = "COMPANY ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "2ed7c2e3-d4ad-4222-9439-1700379ea772",
                            Name = "HR",
                            NormalizedName = "HR"
                        },
                        new
                        {
                            Id = "dd70f100-6753-494a-9382-1dd5ef51d4b6",
                            Name = "Employee",
                            NormalizedName = "EMPLOYEE"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "42df1250-85ef-4683-9046-6f2e5405ee3a",
                            RoleId = "995d5439-2b54-458a-b08d-e0f289255a96"
                        },
                        new
                        {
                            UserId = "2499bc5a-0f33-4f67-b521-5829679ee7ff",
                            RoleId = "dd70f100-6753-494a-9382-1dd5ef51d4b6"
                        },
                        new
                        {
                            UserId = "306627f3-c902-4d48-a6f3-d83db48df2c6",
                            RoleId = "2ed7c2e3-d4ad-4222-9439-1700379ea772"
                        },
                        new
                        {
                            UserId = "48a3b0de-d24d-4879-a528-ddaf38580270",
                            RoleId = "ebc687e2-03df-4448-b79e-32e3e39de6bc"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Core.Infrastructure.Identity.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Core.Infrastructure.Identity.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Infrastructure.Identity.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Core.Infrastructure.Identity.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
