using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedToCandidatesCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Candidates",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CompanyId", "CreatedDate", "Uid" },
                values: new object[] { 1, new DateTime(2024, 11, 25, 23, 32, 36, 331, DateTimeKind.Utc).AddTicks(2660), new Guid("8f39dd6e-6316-48bb-9107-d0239329cc57") });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CompanyId", "CreatedDate", "Uid" },
                values: new object[] { 1, new DateTime(2024, 11, 25, 23, 32, 36, 331, DateTimeKind.Utc).AddTicks(2698), new Guid("3e42ea11-19a8-4344-b7f4-c036102efb22") });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CompanyId", "CreatedDate", "Uid" },
                values: new object[] { 1, new DateTime(2024, 11, 25, 23, 32, 36, 331, DateTimeKind.Utc).AddTicks(2700), new Guid("72801d43-78e2-4571-ae2a-c7481f3eccda") });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CompanyId", "CreatedDate", "Uid" },
                values: new object[] { 1, new DateTime(2024, 11, 25, 23, 32, 36, 331, DateTimeKind.Utc).AddTicks(2703), new Guid("3f0943d0-50f6-4fbe-bcc0-70d7de852ef4") });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CompanyId", "CreatedDate", "Uid" },
                values: new object[] { 1, new DateTime(2024, 11, 25, 23, 32, 36, 331, DateTimeKind.Utc).AddTicks(2705), new Guid("596a7762-ed58-4e54-bd58-a31095dd911e") });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 26, 0, 32, 36, 331, DateTimeKind.Local).AddTicks(3541));

            migrationBuilder.UpdateData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Uid" },
                values: new object[] { new DateTime(2024, 11, 26, 0, 32, 36, 331, DateTimeKind.Local).AddTicks(5160), new Guid("b5b674a6-0f22-424f-92a0-a206daeb385c") });

            migrationBuilder.UpdateData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Uid" },
                values: new object[] { new DateTime(2024, 11, 26, 0, 32, 36, 331, DateTimeKind.Local).AddTicks(5173), new Guid("887f46af-cbe5-46f0-908b-7b086cb57ccf") });

            migrationBuilder.UpdateData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Uid" },
                values: new object[] { new DateTime(2024, 11, 26, 0, 32, 36, 331, DateTimeKind.Local).AddTicks(5186), new Guid("31095778-f45a-4505-ae6e-5516ee2f32aa") });

            migrationBuilder.UpdateData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "Uid" },
                values: new object[] { new DateTime(2024, 11, 26, 0, 32, 36, 331, DateTimeKind.Local).AddTicks(5188), new Guid("e4c95136-ec9c-4892-99d2-eff806f61bb3") });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 26, 0, 32, 36, 331, DateTimeKind.Local).AddTicks(6752));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 26, 0, 32, 36, 331, DateTimeKind.Local).AddTicks(6772));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 26, 0, 32, 36, 331, DateTimeKind.Local).AddTicks(6778));

            migrationBuilder.UpdateData(
                table: "TeamsUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Uid" },
                values: new object[] { new DateTime(2024, 11, 25, 23, 32, 36, 331, DateTimeKind.Utc).AddTicks(7821), new Guid("cd96d88b-9a54-4a70-b8bc-9b49c56b3ba8") });

            migrationBuilder.UpdateData(
                table: "TeamsUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Uid" },
                values: new object[] { new DateTime(2024, 11, 25, 23, 32, 36, 331, DateTimeKind.Utc).AddTicks(7834), new Guid("6046269d-7248-42c0-9799-d793987b8c5d") });

            migrationBuilder.UpdateData(
                table: "TeamsUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Uid" },
                values: new object[] { new DateTime(2024, 11, 25, 23, 32, 36, 331, DateTimeKind.Utc).AddTicks(7837), new Guid("3a47687c-1119-46be-b2df-78185fd2f13d") });

            migrationBuilder.UpdateData(
                table: "TeamsUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Uid" },
                values: new object[] { new DateTime(2024, 11, 25, 23, 32, 36, 331, DateTimeKind.Utc).AddTicks(7838), new Guid("0e2fb292-3f7b-44e9-8e74-a3e1466ecb79") });

            migrationBuilder.UpdateData(
                table: "TeamsUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "Uid" },
                values: new object[] { new DateTime(2024, 11, 25, 23, 32, 36, 331, DateTimeKind.Utc).AddTicks(7840), new Guid("67cb7503-7296-481e-a48a-e44049d26feb") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 25, 23, 32, 36, 331, DateTimeKind.Utc).AddTicks(8683));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 25, 23, 32, 36, 331, DateTimeKind.Utc).AddTicks(8691));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 25, 23, 32, 36, 331, DateTimeKind.Utc).AddTicks(8694));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 25, 23, 32, 36, 331, DateTimeKind.Utc).AddTicks(8701));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 25, 23, 32, 36, 331, DateTimeKind.Utc).AddTicks(8703));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 25, 23, 32, 36, 331, DateTimeKind.Utc).AddTicks(8705));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 25, 23, 32, 36, 331, DateTimeKind.Utc).AddTicks(8708));

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_CompanyId",
                table: "Candidates",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Companies_CompanyId",
                table: "Candidates",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Companies_CompanyId",
                table: "Candidates");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_CompanyId",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Candidates");

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Uid" },
                values: new object[] { new DateTime(2024, 11, 25, 23, 13, 25, 393, DateTimeKind.Utc).AddTicks(6174), new Guid("5d4ea7d7-e413-4238-988e-463f00a4803f") });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Uid" },
                values: new object[] { new DateTime(2024, 11, 25, 23, 13, 25, 393, DateTimeKind.Utc).AddTicks(6235), new Guid("6a84f814-1a9b-4fed-ac7a-b7417fd51207") });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Uid" },
                values: new object[] { new DateTime(2024, 11, 25, 23, 13, 25, 393, DateTimeKind.Utc).AddTicks(6247), new Guid("73523c3d-77b6-4241-ae5f-e8368f0d9962") });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Uid" },
                values: new object[] { new DateTime(2024, 11, 25, 23, 13, 25, 393, DateTimeKind.Utc).AddTicks(6252), new Guid("329798eb-c304-4db5-b57e-74e3fa5e84ff") });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "Uid" },
                values: new object[] { new DateTime(2024, 11, 25, 23, 13, 25, 393, DateTimeKind.Utc).AddTicks(6254), new Guid("ad39ac63-a4de-4618-afd5-b9cdac1af861") });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 26, 0, 13, 25, 393, DateTimeKind.Local).AddTicks(7101));

            migrationBuilder.UpdateData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Uid" },
                values: new object[] { new DateTime(2024, 11, 26, 0, 13, 25, 393, DateTimeKind.Local).AddTicks(8622), new Guid("694cc50e-2d8f-47e3-83e5-1e916856dd29") });

            migrationBuilder.UpdateData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Uid" },
                values: new object[] { new DateTime(2024, 11, 26, 0, 13, 25, 393, DateTimeKind.Local).AddTicks(8638), new Guid("e90d0853-e075-401e-ad09-d8fe5786256e") });

            migrationBuilder.UpdateData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Uid" },
                values: new object[] { new DateTime(2024, 11, 26, 0, 13, 25, 393, DateTimeKind.Local).AddTicks(8641), new Guid("cc949ef4-89d4-4f1a-be9b-2858b8692d6f") });

            migrationBuilder.UpdateData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "Uid" },
                values: new object[] { new DateTime(2024, 11, 26, 0, 13, 25, 393, DateTimeKind.Local).AddTicks(8642), new Guid("ca1c8bf6-c2c1-429a-a585-74c6ec925c93") });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 26, 0, 13, 25, 394, DateTimeKind.Local).AddTicks(269));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 26, 0, 13, 25, 394, DateTimeKind.Local).AddTicks(293));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 26, 0, 13, 25, 394, DateTimeKind.Local).AddTicks(297));

            migrationBuilder.UpdateData(
                table: "TeamsUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Uid" },
                values: new object[] { new DateTime(2024, 11, 25, 23, 13, 25, 394, DateTimeKind.Utc).AddTicks(1276), new Guid("ee4d9f7f-8b33-465a-ad8d-8f040f23a0fa") });

            migrationBuilder.UpdateData(
                table: "TeamsUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Uid" },
                values: new object[] { new DateTime(2024, 11, 25, 23, 13, 25, 394, DateTimeKind.Utc).AddTicks(1293), new Guid("045b10e3-57e4-49a9-bc39-6be592f2d4ea") });

            migrationBuilder.UpdateData(
                table: "TeamsUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Uid" },
                values: new object[] { new DateTime(2024, 11, 25, 23, 13, 25, 394, DateTimeKind.Utc).AddTicks(1296), new Guid("f3dcfadf-109a-4b7e-83ae-3731080b8b4d") });

            migrationBuilder.UpdateData(
                table: "TeamsUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Uid" },
                values: new object[] { new DateTime(2024, 11, 25, 23, 13, 25, 394, DateTimeKind.Utc).AddTicks(1298), new Guid("8390152d-cff8-483d-8262-78145c74b2e2") });

            migrationBuilder.UpdateData(
                table: "TeamsUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "Uid" },
                values: new object[] { new DateTime(2024, 11, 25, 23, 13, 25, 394, DateTimeKind.Utc).AddTicks(1355), new Guid("1b0b0630-c245-496b-9dba-651634f5f15c") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 25, 23, 13, 25, 394, DateTimeKind.Utc).AddTicks(2098));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 25, 23, 13, 25, 394, DateTimeKind.Utc).AddTicks(2108));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 25, 23, 13, 25, 394, DateTimeKind.Utc).AddTicks(2111));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 25, 23, 13, 25, 394, DateTimeKind.Utc).AddTicks(2118));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 25, 23, 13, 25, 394, DateTimeKind.Utc).AddTicks(2120));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 25, 23, 13, 25, 394, DateTimeKind.Utc).AddTicks(2126));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 25, 23, 13, 25, 394, DateTimeKind.Utc).AddTicks(2129));
        }
    }
}
