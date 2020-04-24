using Microsoft.EntityFrameworkCore.Migrations;

namespace Diploma.Migrations
{
    public partial class PromotionHistoryChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PromotionHistories_AspNetUsers_EmployeeId",
                table: "PromotionHistories");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "PromotionHistories",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "9c487d01-7573-405b-bd3f-ffb5d7fcd314");

            migrationBuilder.AddForeignKey(
                name: "FK_PromotionHistories_AspNetUsers_EmployeeId",
                table: "PromotionHistories",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PromotionHistories_AspNetUsers_EmployeeId",
                table: "PromotionHistories");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "PromotionHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "e7b1b60b-7c32-424d-a688-ecf06977519c");

            migrationBuilder.AddForeignKey(
                name: "FK_PromotionHistories_AspNetUsers_EmployeeId",
                table: "PromotionHistories",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
