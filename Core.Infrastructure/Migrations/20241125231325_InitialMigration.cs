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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                });

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
                table: "Candidates",
                columns: new[] { "Id", "CVPath", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "Note", "Rating", "Seniority", "StackPosition", "Uid", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "/uploads/john_doe_cv.pdf", new DateTime(2024, 11, 25, 23, 13, 25, 393, DateTimeKind.Utc).AddTicks(6174), new DateOnly(1990, 5, 15), null, "john.doe@example.com", "John", "Doe", "Candidate shows strong skills in backend development.", 4, "Senior", "Backend", new Guid("5d4ea7d7-e413-4238-988e-463f00a4803f"), null },
                    { 2, "/uploads/alice_smith_cv.pdf", new DateTime(2024, 11, 25, 23, 13, 25, 393, DateTimeKind.Utc).AddTicks(6235), new DateOnly(1985, 12, 30), null, "alice.smith@example.com", "Alice", "Smith", "Experienced project manager with a strong background in Agile methodologies.", 5, "Senior", "Fullstack", new Guid("6a84f814-1a9b-4fed-ac7a-b7417fd51207"), null },
                    { 3, "/uploads/michael_johnson_cv.pdf", new DateTime(2024, 11, 25, 23, 13, 25, 393, DateTimeKind.Utc).AddTicks(6247), new DateOnly(1992, 4, 10), null, "michael.johnson@example.com", "Michael", "Johnson", "Front-end developer with expertise in React and Vue.js.", 3, "Junior", "Unknown", new Guid("73523c3d-77b6-4241-ae5f-e8368f0d9962"), null },
                    { 4, "/uploads/emma_williams_cv.pdf", new DateTime(2024, 11, 25, 23, 13, 25, 393, DateTimeKind.Utc).AddTicks(6252), new DateOnly(1988, 8, 25), null, "emma.williams@example.com", "Emma", "Williams", "Full-stack developer with strong skills in Node.js and .NET Core.", 4, "Junior", "Fullstack", new Guid("329798eb-c304-4db5-b57e-74e3fa5e84ff"), null },
                    { 5, "/uploads/david_brown_cv.pdf", new DateTime(2024, 11, 25, 23, 13, 25, 393, DateTimeKind.Utc).AddTicks(6254), new DateOnly(1995, 11, 15), null, "david.brown@example.com", "David", "Brown", "DevOps engineer with experience in CI/CD pipelines and containerization.", 5, "Mid", "DevOps", new Guid("ad39ac63-a4de-4618-afd5-b9cdac1af861"), null }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "Uid", "UpdatedDate" },
                values: new object[] { 1, new DateTime(2024, 11, 26, 0, 13, 25, 393, DateTimeKind.Local).AddTicks(7101), null, "Naissus Tech", new Guid("da4fdc93-facb-45e2-9170-cb94d01c42fb"), null });

            migrationBuilder.InsertData(
                table: "LeaveTypes",
                columns: new[] { "Id", "CreatedDate", "DefaultDays", "DeletedDate", "Name", "RequiresHRApproval", "Uid", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 26, 0, 13, 25, 393, DateTimeKind.Local).AddTicks(8622), 21, null, "Vacation", true, new Guid("694cc50e-2d8f-47e3-83e5-1e916856dd29"), null },
                    { 2, new DateTime(2024, 11, 26, 0, 13, 25, 393, DateTimeKind.Local).AddTicks(8638), 15, null, "Old Vacation", true, new Guid("e90d0853-e075-401e-ad09-d8fe5786256e"), null },
                    { 4, new DateTime(2024, 11, 26, 0, 13, 25, 393, DateTimeKind.Local).AddTicks(8641), 15, null, "Remote Work", true, new Guid("cc949ef4-89d4-4f1a-be9b-2858b8692d6f"), null },
                    { 5, new DateTime(2024, 11, 26, 0, 13, 25, 393, DateTimeKind.Local).AddTicks(8642), 365, null, "Sick Leave", false, new Guid("ca1c8bf6-c2c1-429a-a585-74c6ec925c93"), null }
                });

            migrationBuilder.InsertData(
                table: "TeamsUsers",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "TeamUid", "Uid", "UpdatedDate", "UserUid" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 25, 23, 13, 25, 394, DateTimeKind.Utc).AddTicks(1276), null, new Guid("9fe876b5-0429-42e0-a205-1f6d9c2a7cb5"), new Guid("ee4d9f7f-8b33-465a-ad8d-8f040f23a0fa"), null, new Guid("2499bc5a-0f33-4f67-b521-5829679ee7ff") },
                    { 2, new DateTime(2024, 11, 25, 23, 13, 25, 394, DateTimeKind.Utc).AddTicks(1293), null, new Guid("9fe876b5-0429-42e0-a205-1f6d9c2a7cb5"), new Guid("045b10e3-57e4-49a9-bc39-6be592f2d4ea"), null, new Guid("e19c3b4a-b3ec-49a8-9790-5d15d9b8de96") },
                    { 3, new DateTime(2024, 11, 25, 23, 13, 25, 394, DateTimeKind.Utc).AddTicks(1296), null, new Guid("67f55a17-fc74-4c83-ad93-e52937c2499c"), new Guid("f3dcfadf-109a-4b7e-83ae-3731080b8b4d"), null, new Guid("306627f3-c902-4d48-a6f3-d83db48df2c6") },
                    { 4, new DateTime(2024, 11, 25, 23, 13, 25, 394, DateTimeKind.Utc).AddTicks(1298), null, new Guid("bd7746a3-1385-4d0e-8fb7-3e19a0f360c1"), new Guid("8390152d-cff8-483d-8262-78145c74b2e2"), null, new Guid("985fe5c1-deb8-4082-863a-840037477bc5") },
                    { 5, new DateTime(2024, 11, 25, 23, 13, 25, 394, DateTimeKind.Utc).AddTicks(1355), null, new Guid("bd7746a3-1385-4d0e-8fb7-3e19a0f360c1"), new Guid("1b0b0630-c245-496b-9dba-651634f5f15c"), null, new Guid("88ea1648-4810-4e04-81f9-cfdff02bbd22") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CompanyEmail", "CompanyId", "CreatedDate", "DateOfBirth", "DateOfEmployment", "DedicatedHR", "DeletedDate", "FirstName", "IsTeamLead", "LastName", "ReligiousHolidayDay", "Seniority", "StackPosition", "TeamLeadUid", "Uid", "UpdatedDate" },
                values: new object[] { 1, "admin@localhost.com", null, new DateTime(2024, 11, 25, 23, 13, 25, 394, DateTimeKind.Utc).AddTicks(2098), new DateOnly(1, 1, 1), new DateOnly(1, 1, 1), null, null, "System", false, "Admin", null, "Unknown", "Unknown", null, new Guid("42df1250-85ef-4683-9046-6f2e5405ee3a"), null });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CompanyId", "CreatedDate", "DeletedDate", "LeadUid", "Name", "Uid", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 11, 26, 0, 13, 25, 394, DateTimeKind.Local).AddTicks(269), null, new Guid("306627f3-c902-4d48-a6f3-d83db48df2c6"), "GBI", new Guid("9fe876b5-0429-42e0-a205-1f6d9c2a7cb5"), null },
                    { 2, 1, new DateTime(2024, 11, 26, 0, 13, 25, 394, DateTimeKind.Local).AddTicks(293), null, new Guid("985fe5c1-deb8-4082-863a-840037477bc5"), "GOAT", new Guid("bd7746a3-1385-4d0e-8fb7-3e19a0f360c1"), null },
                    { 3, 1, new DateTime(2024, 11, 26, 0, 13, 25, 394, DateTimeKind.Local).AddTicks(297), null, new Guid("00000000-0000-0000-0000-000000000000"), "Support", new Guid("67f55a17-fc74-4c83-ad93-e52937c2499c"), null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CompanyEmail", "CompanyId", "CreatedDate", "DateOfBirth", "DateOfEmployment", "DedicatedHR", "DeletedDate", "FirstName", "IsTeamLead", "LastName", "ReligiousHolidayDay", "Seniority", "StackPosition", "TeamLeadUid", "Uid", "UpdatedDate" },
                values: new object[,]
                {
                    { 2, "naissuscompanyadmin@localhost.com", 1, new DateTime(2024, 11, 25, 23, 13, 25, 394, DateTimeKind.Utc).AddTicks(2108), new DateOnly(1, 1, 1), new DateOnly(1, 1, 1), null, null, "Company", false, "Admin", null, "Unknown", "Unknown", null, new Guid("48a3b0de-d24d-4879-a528-ddaf38580270"), null },
                    { 3, "filip.dimitrijevic@localhost.com", 1, new DateTime(2024, 11, 25, 23, 13, 25, 394, DateTimeKind.Utc).AddTicks(2111), new DateOnly(1995, 1, 14), new DateOnly(2021, 1, 10), new Guid("306627f3-c902-4d48-a6f3-d83db48df2c6"), null, "Filip", false, "Dimitrijevic", new DateOnly(1900, 1, 12), "Mid", "Backend", new Guid("e19c3b4a-b3ec-49a8-9790-5d15d9b8de96"), new Guid("2499bc5a-0f33-4f67-b521-5829679ee7ff"), null },
                    { 4, "hr@localhost.com", 1, new DateTime(2024, 11, 25, 23, 13, 25, 394, DateTimeKind.Utc).AddTicks(2118), new DateOnly(1990, 1, 1), new DateOnly(2022, 1, 1), null, null, "Bojana", false, "Stoiljkovic", null, "Mid", "HR", null, new Guid("306627f3-c902-4d48-a6f3-d83db48df2c6"), null },
                    { 5, "marko.stoiljkovic@localhost.com", 1, new DateTime(2024, 11, 25, 23, 13, 25, 394, DateTimeKind.Utc).AddTicks(2120), new DateOnly(1989, 1, 1), new DateOnly(2015, 1, 1), new Guid("306627f3-c902-4d48-a6f3-d83db48df2c6"), null, "Marko", true, "Stoiljkovic", new DateOnly(1900, 1, 12), "Lead", "ProjectManager", null, new Guid("e19c3b4a-b3ec-49a8-9790-5d15d9b8de96"), null },
                    { 6, "sara.dimitrijevic@localhost.com", 1, new DateTime(2024, 11, 25, 23, 13, 25, 394, DateTimeKind.Utc).AddTicks(2126), new DateOnly(1999, 2, 12), new DateOnly(2020, 1, 1), new Guid("306627f3-c902-4d48-a6f3-d83db48df2c6"), null, "Sara", true, "Dimitrijevic", new DateOnly(1900, 1, 12), "Mid", "ProjectManager", null, new Guid("985fe5c1-deb8-4082-863a-840037477bc5"), null },
                    { 7, "petar.markovic@localhost.com", 1, new DateTime(2024, 11, 25, 23, 13, 25, 394, DateTimeKind.Utc).AddTicks(2129), new DateOnly(1998, 12, 5), new DateOnly(2021, 1, 1), new Guid("306627f3-c902-4d48-a6f3-d83db48df2c6"), null, "Petar", false, "Markovic", new DateOnly(1900, 1, 12), "Senior", "Backend", new Guid("985fe5c1-deb8-4082-863a-840037477bc5"), new Guid("88ea1648-4810-4e04-81f9-cfdff02bbd22"), null }
                });

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
