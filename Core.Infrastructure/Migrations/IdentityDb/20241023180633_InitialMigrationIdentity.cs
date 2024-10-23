using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Core.Infrastructure.Migrations.IdentityDb
{
    /// <inheritdoc />
    public partial class InitialMigrationIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Candidate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StackPosition = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Seniority = table.Column<int>(type: "int", nullable: false),
                    CVPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeaveType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DefaultDays = table.Column<int>(type: "int", nullable: false),
                    RequiresHRApproval = table.Column<bool>(type: "bit", nullable: false),
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2ed7c2e3-d4ad-4222-9439-1700379ea772", null, "HR", "HR" },
                    { "995d5439-2b54-458a-b08d-e0f289255a96", null, "Administrator", "ADMINISTRATOR" },
                    { "dd70f100-6753-494a-9382-1dd5ef51d4b6", null, "Employee", "EMPLOYEE" },
                    { "ebc687e2-03df-4448-b79e-32e3e39de6bc", null, "Company Administrator", "COMPANY ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyName", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2499bc5a-0f33-4f67-b521-5829679ee7ff", 0, "System", "e049fc8f-ffef-470f-9622-610835b7d0b4", new DateOnly(1995, 1, 14), "user@localhost.com", true, "System", "User", false, null, "USER@LOCALHOST.COM", "USER@LOCALHOST.COM", "AQAAAAIAAYagAAAAEIt4TFDYLGhMXk9b3WnFofTb5BCi7zJ4zFLcXREQnll0HNOGBAfT8FPXSfQQryDmtw==", null, false, "9014f7a6-6007-429b-ae5f-66831c18740d", false, "user@localhost.com" },
                    { "306627f3-c902-4d48-a6f3-d83db48df2c6", 0, "System", "c0345cc1-870a-4ed7-9b58-33503bc3f5e2", new DateOnly(1995, 1, 14), "hr@localhost.com", true, "Hr", "Hr", false, null, "HR@LOCALHOST.COM", "HR@LOCALHOST.COM", "AQAAAAIAAYagAAAAEGJIGzs7yhNRr+gm3+RQZaVrb6EgJJpo12Qk1MqtZ3GBjsre90U9pAGJsD1OatYk0Q==", null, false, "a9f73efb-268a-4f43-9012-ac8fbd57e8c5", false, "hr@localhost.com" },
                    { "42df1250-85ef-4683-9046-6f2e5405ee3a", 0, "System", "01133198-250b-4ba9-bf9e-6e65f58b987a", new DateOnly(1995, 1, 14), "admin@localhost.com", true, "System", "Admin", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEIzlmTaiZXls81f7x+aePMkDL2yDBWuQNoc/nbQxN6/obLZH82cr53CthESaHHosgw==", null, false, "7f7e3680-ed8c-484f-a77a-1624571d0d0f", false, "admin@localhost.com" },
                    { "48a3b0de-d24d-4879-a528-ddaf38580270", 0, "System", "e21d5737-fced-4aaa-96ed-28f7c931c6db", new DateOnly(1995, 1, 14), "companyadmin@localhost.com", true, "Company", "Admin", false, null, "COMPANYADMIN@LOCALHOST.COM", "COMPANYADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEBrAXDJ8xDY8DETzxlLIXopp4lYeSwGifs/OGHfubczaF0+eSEodh1ws+ff1MplXMg==", null, false, "c8a0a664-e4d3-4334-83ff-75b4a2c82cb4", false, "companyadmin@localhost.com" }
                });

            migrationBuilder.InsertData(
                table: "Candidate",
                columns: new[] { "Id", "CVPath", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "Note", "Rating", "Seniority", "StackPosition", "Uid", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "/uploads/john_doe_cv.pdf", new DateTime(2024, 10, 23, 18, 6, 33, 405, DateTimeKind.Utc).AddTicks(3605), new DateOnly(1990, 5, 15), null, "john.doe@example.com", "John", "Doe", "Candidate shows strong skills in backend development.", 4, 3, 1, new Guid("3402484c-8383-48ff-a35e-ca4df1995a35"), null },
                    { 2, "/uploads/alice_smith_cv.pdf", new DateTime(2024, 10, 23, 18, 6, 33, 405, DateTimeKind.Utc).AddTicks(3664), new DateOnly(1985, 12, 30), null, "alice.smith@example.com", "Alice", "Smith", "Experienced project manager with a strong background in Agile methodologies.", 5, 3, 2, new Guid("2c7939a3-1a4c-4fe9-9eda-90ffda2009c1"), null },
                    { 3, "/uploads/michael_johnson_cv.pdf", new DateTime(2024, 10, 23, 18, 6, 33, 405, DateTimeKind.Utc).AddTicks(3681), new DateOnly(1992, 4, 10), null, "michael.johnson@example.com", "Michael", "Johnson", "Front-end developer with expertise in React and Vue.js.", 3, 1, 0, new Guid("5d65be7b-c223-48c2-a9d4-49e140def2b6"), null },
                    { 4, "/uploads/emma_williams_cv.pdf", new DateTime(2024, 10, 23, 18, 6, 33, 405, DateTimeKind.Utc).AddTicks(3686), new DateOnly(1988, 8, 25), null, "emma.williams@example.com", "Emma", "Williams", "Full-stack developer with strong skills in Node.js and .NET Core.", 4, 1, 2, new Guid("eb619ca0-0cc3-46ee-b52a-faa88b9f6b17"), null },
                    { 5, "/uploads/david_brown_cv.pdf", new DateTime(2024, 10, 23, 18, 6, 33, 405, DateTimeKind.Utc).AddTicks(3700), new DateOnly(1995, 11, 15), null, "david.brown@example.com", "David", "Brown", "DevOps engineer with experience in CI/CD pipelines and containerization.", 5, 2, 4, new Guid("81d41adc-6b3f-4b4b-a1fd-cef466b0f8e1"), null }
                });

            migrationBuilder.InsertData(
                table: "LeaveType",
                columns: new[] { "Id", "CreatedDate", "DefaultDays", "DeletedDate", "Name", "RequiresHRApproval", "Uid", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 23, 20, 6, 33, 406, DateTimeKind.Local).AddTicks(4173), 21, null, "Vacation", true, new Guid("c13d5926-2d3d-4f95-a90e-728914094c9a"), null },
                    { 2, new DateTime(2024, 10, 23, 20, 6, 33, 406, DateTimeKind.Local).AddTicks(4334), 15, null, "Old Vacation", true, new Guid("c9edbebf-6ece-4c95-85c5-dc4324fb624e"), null },
                    { 4, new DateTime(2024, 10, 23, 20, 6, 33, 406, DateTimeKind.Local).AddTicks(4337), 15, null, "Remote Work", true, new Guid("2c4fb57a-8fc6-42c7-9000-f0d827f273a0"), null },
                    { 5, new DateTime(2024, 10, 23, 20, 6, 33, 406, DateTimeKind.Local).AddTicks(4339), 365, null, "Sick Leave", false, new Guid("58d21e95-9478-4732-a973-3ab477500818"), null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "dd70f100-6753-494a-9382-1dd5ef51d4b6", "2499bc5a-0f33-4f67-b521-5829679ee7ff" },
                    { "2ed7c2e3-d4ad-4222-9439-1700379ea772", "306627f3-c902-4d48-a6f3-d83db48df2c6" },
                    { "995d5439-2b54-458a-b08d-e0f289255a96", "42df1250-85ef-4683-9046-6f2e5405ee3a" },
                    { "ebc687e2-03df-4448-b79e-32e3e39de6bc", "48a3b0de-d24d-4879-a528-ddaf38580270" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Candidate");

            migrationBuilder.DropTable(
                name: "LeaveType");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
