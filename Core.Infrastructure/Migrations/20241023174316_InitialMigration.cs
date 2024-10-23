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
                    StackPosition = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Seniority = table.Column<int>(type: "int", nullable: false),
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
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    DateRequested = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestStatus = table.Column<int>(type: "int", nullable: false),
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
                    { 1, "/uploads/john_doe_cv.pdf", new DateTime(2024, 10, 23, 17, 43, 14, 792, DateTimeKind.Utc).AddTicks(6761), new DateOnly(1990, 5, 15), null, "john.doe@example.com", "John", "Doe", "Candidate shows strong skills in backend development.", 4, 3, 1, new Guid("b6ecd90f-6b11-4956-a78b-85d9d9394a61"), null },
                    { 2, "/uploads/alice_smith_cv.pdf", new DateTime(2024, 10, 23, 17, 43, 14, 792, DateTimeKind.Utc).AddTicks(6805), new DateOnly(1985, 12, 30), null, "alice.smith@example.com", "Alice", "Smith", "Experienced project manager with a strong background in Agile methodologies.", 5, 3, 2, new Guid("999c40ca-41d0-4692-a0ca-6bbc4a9d06b9"), null },
                    { 3, "/uploads/michael_johnson_cv.pdf", new DateTime(2024, 10, 23, 17, 43, 14, 792, DateTimeKind.Utc).AddTicks(6842), new DateOnly(1992, 4, 10), null, "michael.johnson@example.com", "Michael", "Johnson", "Front-end developer with expertise in React and Vue.js.", 3, 1, 0, new Guid("93e64d52-1135-4da1-92cc-aa2ee856c78d"), null },
                    { 4, "/uploads/emma_williams_cv.pdf", new DateTime(2024, 10, 23, 17, 43, 14, 792, DateTimeKind.Utc).AddTicks(6847), new DateOnly(1988, 8, 25), null, "emma.williams@example.com", "Emma", "Williams", "Full-stack developer with strong skills in Node.js and .NET Core.", 4, 1, 2, new Guid("be64a8f1-dc22-40f1-8f06-91dc3f08b27d"), null },
                    { 5, "/uploads/david_brown_cv.pdf", new DateTime(2024, 10, 23, 17, 43, 14, 792, DateTimeKind.Utc).AddTicks(6849), new DateOnly(1995, 11, 15), null, "david.brown@example.com", "David", "Brown", "DevOps engineer with experience in CI/CD pipelines and containerization.", 5, 2, 4, new Guid("d0b9eddd-398f-40d6-81cc-e440291cea55"), null }
                });

            migrationBuilder.InsertData(
                table: "LeaveTypes",
                columns: new[] { "Id", "CreatedDate", "DefaultDays", "DeletedDate", "Name", "RequiresHRApproval", "Uid", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 23, 19, 43, 14, 792, DateTimeKind.Local).AddTicks(8258), 21, null, "Vacation", true, new Guid("b877bf7d-1082-4315-938e-40cf088d8bd4"), null },
                    { 2, new DateTime(2024, 10, 23, 19, 43, 14, 792, DateTimeKind.Local).AddTicks(8405), 15, null, "Old Vacation", true, new Guid("33b34e7c-b931-49ba-a2c8-fcd048f0761e"), null },
                    { 4, new DateTime(2024, 10, 23, 19, 43, 14, 792, DateTimeKind.Local).AddTicks(8410), 15, null, "Remote Work", true, new Guid("ac7ee7ec-c17d-4bb1-9d96-b9d85dac5e93"), null },
                    { 5, new DateTime(2024, 10, 23, 19, 43, 14, 792, DateTimeKind.Local).AddTicks(8413), 365, null, "Sick Leave", false, new Guid("9e1efa33-afd5-45dc-8ca3-017a177989b2"), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveDistributions_LeaveTypeId",
                table: "LeaveDistributions",
                column: "LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_LeaveTypeId",
                table: "LeaveRequests",
                column: "LeaveTypeId");
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
                name: "LeaveTypes");
        }
    }
}
