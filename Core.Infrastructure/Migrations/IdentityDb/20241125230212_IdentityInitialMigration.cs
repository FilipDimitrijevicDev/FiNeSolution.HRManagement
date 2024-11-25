using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Core.Infrastructure.Migrations.IdentityDb
{
    /// <inheritdoc />
    public partial class IdentityInitialMigration : Migration
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
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2499bc5a-0f33-4f67-b521-5829679ee7ff", 0, "512cf4b6-4b5f-4bb7-9ab4-ee719786fd8f", "filip.dimitrijevic@localhost.com", true, false, null, "FILIP.DIMITRIJEVIC@LOCALHOST.COM", "FILIP.DIMITRIJEVIC@LOCALHOST.COM", "AQAAAAIAAYagAAAAEApcdI06Zv75TOdd5DSjgd/P4rjVIP/MnQJlnBGHwLfxoPiJ4kCA4myxl3vNPPdvoA==", null, false, "452fc2eb-c0ba-419d-9995-6aed57a38b55", false, "filip.dimitrijevic@localhost.com" },
                    { "306627f3-c902-4d48-a6f3-d83db48df2c6", 0, "36194ca4-d13b-4b1c-aee4-28342476496e", "hr@localhost.com", true, false, null, "HR@LOCALHOST.COM", "HR@LOCALHOST.COM", "AQAAAAIAAYagAAAAENh8KQgRTk9h9F7St+UiP+scJaGa7eCpQapkOJXqqBEdYQtdifmId8OhLUq23UrSIA==", null, false, "3ba7a282-fa40-4a72-9e31-ba199b33a831", false, "hr@localhost.com" },
                    { "42df1250-85ef-4683-9046-6f2e5405ee3a", 0, "e4e058bc-4223-45ee-9982-be0786bca5d2", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAED+YZuc/3H4sib4v1ITXTs8j+dXbhiakkJgEvaChASaHawCb0s1YUZdOUNLw98Kf+Q==", null, false, "b296f64e-bb37-4b00-aefd-c7fbf310c0e6", false, "admin@localhost.com" },
                    { "48a3b0de-d24d-4879-a528-ddaf38580270", 0, "bfb9a6a0-ebeb-4132-81f4-1a367df4c5de", "naissuscompanyadmin@localhost.com", true, false, null, "NAISSUSCOMPANYADMIN@LOCALHOST.COM", "NAISSUSCOMPANYADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEN63iXou6lRrv9XzbguIsI1SpgyEBe3wJU6W10bIJD6uBgBeR8l0tq5N0P4OC9OSnw==", null, false, "27ef1998-f42b-48d8-b8c4-a47ee2aff8ba", false, "naissuscompanyadmin@localhost.com" },
                    { "88ea1648-4810-4e04-81f9-cfdff02bbd22", 0, "adbb6c0a-e464-4527-ad10-1f7b334c845d", "petar.markovic@localhost.com", true, false, null, "PETAR.MARKOVIC@LOCALHOST.COM", "PETAR.MARKOVIC@LOCALHOST.COM", "AQAAAAIAAYagAAAAEFUz+a0eqwBBRj45qzrCE6sYFTPHe/1NbhP4eDypFYjIoA2QZnXvl0Mfl++zrj0fXQ==", null, false, "2ce2d770-50a0-401c-b822-7eb115ffb530", false, "petar.markovic@localhost.com" },
                    { "985fe5c1-deb8-4082-863a-840037477bc5", 0, "60134e52-1978-4106-9f8f-3445d881053d", "sara.dimitrijevic@localhost.com", true, false, null, "SARA.DIMITRIJEVIC@LOCALHOST.COM", "SARA.DIMITRIJEVIC@LOCALHOST.COM", "AQAAAAIAAYagAAAAEFSR5oBgIHY5mdhhOBbSzJ/l9qYCffwgljWCe4ZMStvB6V0Nir0g0w871NegHkbqtg==", null, false, "6657fabf-3cb8-43f9-9e80-0ce268a3819a", false, "sara.dimitrijevic@localhost.com" },
                    { "e19c3b4a-b3ec-49a8-9790-5d15d9b8de96", 0, "9ccd66ce-08b8-4c94-abe4-000509593713", "marko.stoiljkovic@localhost.com", true, false, null, "MARKO.STOILJKOVIC@LOCALHOST.COM", "MARKO.STOILJKOVIC@LOCALHOST.COM", "AQAAAAIAAYagAAAAEE5ZHj1XzdPXoj1b5r5GLZacNQ66/kGkr5dS2nR28A+8uIiymvbz2f9bK/D7pLYkvQ==", null, false, "2c3f9b80-ac49-498b-be63-16ed81d23ce4", false, "marko.stoiljkovic@localhost.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "dd70f100-6753-494a-9382-1dd5ef51d4b6", "2499bc5a-0f33-4f67-b521-5829679ee7ff" },
                    { "2ed7c2e3-d4ad-4222-9439-1700379ea772", "306627f3-c902-4d48-a6f3-d83db48df2c6" },
                    { "995d5439-2b54-458a-b08d-e0f289255a96", "42df1250-85ef-4683-9046-6f2e5405ee3a" },
                    { "ebc687e2-03df-4448-b79e-32e3e39de6bc", "48a3b0de-d24d-4879-a528-ddaf38580270" },
                    { "dd70f100-6753-494a-9382-1dd5ef51d4b6", "88ea1648-4810-4e04-81f9-cfdff02bbd22" },
                    { "dd70f100-6753-494a-9382-1dd5ef51d4b6", "985fe5c1-deb8-4082-863a-840037477bc5" },
                    { "dd70f100-6753-494a-9382-1dd5ef51d4b6", "e19c3b4a-b3ec-49a8-9790-5d15d9b8de96" }
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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
