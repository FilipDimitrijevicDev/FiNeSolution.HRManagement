using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Core.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeaveTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DefaultDays = table.Column<int>(type: "int", nullable: false),
                    RequiresHRApproval = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamsUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamsUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StackPosition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Seniority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CVPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidates_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LeadUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyEmail = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    DateOfEmployment = table.Column<DateOnly>(type: "date", nullable: false),
                    StackPosition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seniority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsTeamLead = table.Column<bool>(type: "bit", nullable: false),
                    TeamLeadUid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DedicatedHR = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReligiousHolidayDay = table.Column<DateOnly>(type: "date", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LeaveDistributions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RemainingDays = table.Column<int>(type: "int", nullable: false),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    Period = table.Column<int>(type: "int", nullable: false),
                    EmployeeUid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveDistributions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveDistributions_LeaveTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "LeaveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Duration_Start = table.Column<DateOnly>(type: "date", nullable: false),
                    Duration_End = table.Column<DateOnly>(type: "date", nullable: false),
                    Duration_LengthInDays = table.Column<int>(type: "int", nullable: false),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    DateRequested = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReserveOnly = table.Column<bool>(type: "bit", nullable: false),
                    RequestingEmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_LeaveTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "LeaveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "Uid", "UpdatedDate" },
                values: new object[] { 1, new DateTime(2024, 11, 26, 20, 20, 39, 225, DateTimeKind.Local).AddTicks(4066), null, "Naissus Tech", new Guid("da4fdc93-facb-45e2-9170-cb94d01c42fb"), null });

            migrationBuilder.InsertData(
                table: "LeaveTypes",
                columns: new[] { "Id", "CreatedDate", "DefaultDays", "DeletedDate", "Name", "RequiresHRApproval", "Uid", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 26, 20, 20, 39, 225, DateTimeKind.Local).AddTicks(5439), 21, null, "Vacation", true, new Guid("3034d942-0fee-467f-a288-d680fce6aa00"), null },
                    { 2, new DateTime(2024, 11, 26, 20, 20, 39, 225, DateTimeKind.Local).AddTicks(5454), 15, null, "Old Vacation", true, new Guid("10ec6094-46a4-4963-8a44-d68c6052048d"), null },
                    { 4, new DateTime(2024, 11, 26, 20, 20, 39, 225, DateTimeKind.Local).AddTicks(5456), 15, null, "Remote Work", true, new Guid("54d970f8-bdb4-47bc-b932-3588b80637db"), null },
                    { 5, new DateTime(2024, 11, 26, 20, 20, 39, 225, DateTimeKind.Local).AddTicks(5458), 365, null, "Sick Leave", false, new Guid("0b70c087-5333-4705-8617-fca6b4851f4a"), null }
                });

            migrationBuilder.InsertData(
                table: "TeamsUsers",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "TeamUid", "Uid", "UpdatedDate", "UserUid" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 26, 19, 20, 39, 225, DateTimeKind.Utc).AddTicks(7980), null, new Guid("9fe876b5-0429-42e0-a205-1f6d9c2a7cb5"), new Guid("abc93719-bbcf-4a3d-9e79-39703e4f529a"), null, new Guid("2499bc5a-0f33-4f67-b521-5829679ee7ff") },
                    { 2, new DateTime(2024, 11, 26, 19, 20, 39, 225, DateTimeKind.Utc).AddTicks(7992), null, new Guid("9fe876b5-0429-42e0-a205-1f6d9c2a7cb5"), new Guid("2b92261b-0ea0-478f-987a-fcc02ab4554a"), null, new Guid("e19c3b4a-b3ec-49a8-9790-5d15d9b8de96") },
                    { 3, new DateTime(2024, 11, 26, 19, 20, 39, 225, DateTimeKind.Utc).AddTicks(7995), null, new Guid("67f55a17-fc74-4c83-ad93-e52937c2499c"), new Guid("8eb7d426-dc9c-4fc5-9685-5409033d926c"), null, new Guid("306627f3-c902-4d48-a6f3-d83db48df2c6") },
                    { 4, new DateTime(2024, 11, 26, 19, 20, 39, 225, DateTimeKind.Utc).AddTicks(7999), null, new Guid("bd7746a3-1385-4d0e-8fb7-3e19a0f360c1"), new Guid("21c00174-7f5f-4364-bb02-3c69abb64cbb"), null, new Guid("985fe5c1-deb8-4082-863a-840037477bc5") },
                    { 5, new DateTime(2024, 11, 26, 19, 20, 39, 225, DateTimeKind.Utc).AddTicks(8006), null, new Guid("bd7746a3-1385-4d0e-8fb7-3e19a0f360c1"), new Guid("2bc07398-ca94-4274-98a6-33041ea66b19"), null, new Guid("88ea1648-4810-4e04-81f9-cfdff02bbd22") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CompanyEmail", "CompanyId", "CreatedDate", "DateOfBirth", "DateOfEmployment", "DedicatedHR", "DeletedDate", "FirstName", "IsTeamLead", "LastName", "PhoneNumber", "ReligiousHolidayDay", "Seniority", "StackPosition", "TeamLeadUid", "Uid", "UpdatedDate" },
                values: new object[] { 1, "admin@localhost.com", null, new DateTime(2024, 11, 26, 19, 20, 39, 225, DateTimeKind.Utc).AddTicks(8917), new DateOnly(1, 1, 1), new DateOnly(1, 1, 1), null, null, "System", false, "Admin", null, null, "Unknown", "Unknown", null, new Guid("42df1250-85ef-4683-9046-6f2e5405ee3a"), null });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "CVPath", "CompanyId", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "Note", "PhoneNumber", "Rating", "Seniority", "StackPosition", "Uid", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "/uploads/john_doe_cv.pdf", 1, new DateTime(2024, 11, 26, 19, 20, 39, 225, DateTimeKind.Utc).AddTicks(2539), new DateOnly(1990, 5, 15), null, "john.doe@example.com", "John", "Doe", "Candidate shows strong skills in backend development.", null, 4, "Senior", "Backend", new Guid("afc65760-c53a-4188-9c37-65461d53977e"), null },
                    { 2, "/uploads/alice_smith_cv.pdf", 1, new DateTime(2024, 11, 26, 19, 20, 39, 225, DateTimeKind.Utc).AddTicks(2569), new DateOnly(1985, 12, 30), null, "alice.smith@example.com", "Alice", "Smith", "Experienced project manager with a strong background in Agile methodologies.", null, 5, "Senior", "Fullstack", new Guid("c90cb5c7-10d2-4a24-b485-52c448bf4f46"), null },
                    { 3, "/uploads/michael_johnson_cv.pdf", 1, new DateTime(2024, 11, 26, 19, 20, 39, 225, DateTimeKind.Utc).AddTicks(2570), new DateOnly(1992, 4, 10), null, "michael.johnson@example.com", "Michael", "Johnson", "Front-end developer with expertise in React and Vue.js.", null, 3, "Junior", "Unknown", new Guid("1d549dd0-4d19-490c-afd7-e3feb2c565f2"), null },
                    { 4, "/uploads/emma_williams_cv.pdf", 1, new DateTime(2024, 11, 26, 19, 20, 39, 225, DateTimeKind.Utc).AddTicks(2574), new DateOnly(1988, 8, 25), null, "emma.williams@example.com", "Emma", "Williams", "Full-stack developer with strong skills in Node.js and .NET Core.", null, 4, "Junior", "Fullstack", new Guid("ca7facd0-23a7-46b7-833e-8c69992fa234"), null },
                    { 5, "/uploads/david_brown_cv.pdf", 1, new DateTime(2024, 11, 26, 19, 20, 39, 225, DateTimeKind.Utc).AddTicks(2576), new DateOnly(1995, 11, 15), null, "david.brown@example.com", "David", "Brown", "DevOps engineer with experience in CI/CD pipelines and containerization.", null, 5, "Mid", "DevOps", new Guid("8f80e5fb-51c7-4f7c-ba05-3a4e7aab0d7e"), null }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CompanyId", "CreatedDate", "DeletedDate", "LeadUid", "Name", "Uid", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 11, 26, 20, 20, 39, 225, DateTimeKind.Local).AddTicks(7038), null, new Guid("306627f3-c902-4d48-a6f3-d83db48df2c6"), "GBI", new Guid("9fe876b5-0429-42e0-a205-1f6d9c2a7cb5"), null },
                    { 2, 1, new DateTime(2024, 11, 26, 20, 20, 39, 225, DateTimeKind.Local).AddTicks(7062), null, new Guid("985fe5c1-deb8-4082-863a-840037477bc5"), "GOAT", new Guid("bd7746a3-1385-4d0e-8fb7-3e19a0f360c1"), null },
                    { 3, 1, new DateTime(2024, 11, 26, 20, 20, 39, 225, DateTimeKind.Local).AddTicks(7067), null, new Guid("00000000-0000-0000-0000-000000000000"), "Support", new Guid("67f55a17-fc74-4c83-ad93-e52937c2499c"), null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CompanyEmail", "CompanyId", "CreatedDate", "DateOfBirth", "DateOfEmployment", "DedicatedHR", "DeletedDate", "FirstName", "IsTeamLead", "LastName", "PhoneNumber", "ReligiousHolidayDay", "Seniority", "StackPosition", "TeamLeadUid", "Uid", "UpdatedDate" },
                values: new object[,]
                {
                    { 2, "naissuscompanyadmin@localhost.com", 1, new DateTime(2024, 11, 26, 19, 20, 39, 225, DateTimeKind.Utc).AddTicks(8924), new DateOnly(1, 1, 1), new DateOnly(1, 1, 1), null, null, "Company", false, "Admin", null, null, "Unknown", "Unknown", null, new Guid("48a3b0de-d24d-4879-a528-ddaf38580270"), null },
                    { 3, "filip.dimitrijevic@localhost.com", 1, new DateTime(2024, 11, 26, 19, 20, 39, 225, DateTimeKind.Utc).AddTicks(8927), new DateOnly(1995, 1, 14), new DateOnly(2021, 1, 10), new Guid("306627f3-c902-4d48-a6f3-d83db48df2c6"), null, "Filip", false, "Dimitrijevic", "0692509999", new DateOnly(1900, 1, 12), "Mid", "Backend", new Guid("e19c3b4a-b3ec-49a8-9790-5d15d9b8de96"), new Guid("2499bc5a-0f33-4f67-b521-5829679ee7ff"), null },
                    { 4, "hr@localhost.com", 1, new DateTime(2024, 11, 26, 19, 20, 39, 225, DateTimeKind.Utc).AddTicks(8933), new DateOnly(1990, 1, 1), new DateOnly(2022, 1, 1), null, null, "Bojana", false, "Stoiljkovic", null, null, "Mid", "HR", null, new Guid("306627f3-c902-4d48-a6f3-d83db48df2c6"), null },
                    { 5, "marko.stoiljkovic@localhost.com", 1, new DateTime(2024, 11, 26, 19, 20, 39, 225, DateTimeKind.Utc).AddTicks(8935), new DateOnly(1989, 1, 1), new DateOnly(2015, 1, 1), new Guid("306627f3-c902-4d48-a6f3-d83db48df2c6"), null, "Marko", true, "Stoiljkovic", "0638888888", new DateOnly(1900, 1, 12), "Lead", "ProjectManager", null, new Guid("e19c3b4a-b3ec-49a8-9790-5d15d9b8de96"), null },
                    { 6, "sara.dimitrijevic@localhost.com", 1, new DateTime(2024, 11, 26, 19, 20, 39, 225, DateTimeKind.Utc).AddTicks(8938), new DateOnly(1999, 2, 12), new DateOnly(2020, 1, 1), new Guid("306627f3-c902-4d48-a6f3-d83db48df2c6"), null, "Sara", true, "Dimitrijevic", "0623333344", new DateOnly(1900, 1, 12), "Mid", "ProjectManager", null, new Guid("985fe5c1-deb8-4082-863a-840037477bc5"), null },
                    { 7, "petar.markovic@localhost.com", 1, new DateTime(2024, 11, 26, 19, 20, 39, 225, DateTimeKind.Utc).AddTicks(8940), new DateOnly(1998, 12, 5), new DateOnly(2021, 1, 1), new Guid("306627f3-c902-4d48-a6f3-d83db48df2c6"), null, "Petar", false, "Markovic", null, new DateOnly(1900, 1, 12), "Senior", "Backend", new Guid("985fe5c1-deb8-4082-863a-840037477bc5"), new Guid("88ea1648-4810-4e04-81f9-cfdff02bbd22"), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_CompanyId",
                table: "Candidates",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveDistributions_LeaveTypeId",
                table: "LeaveDistributions",
                column: "LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_LeaveTypeId",
                table: "LeaveRequests",
                column: "LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CompanyId",
                table: "Teams",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CompanyId",
                table: "Users",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "LeaveDistributions");

            migrationBuilder.DropTable(
                name: "LeaveRequests");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "TeamsUsers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "LeaveTypes");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
