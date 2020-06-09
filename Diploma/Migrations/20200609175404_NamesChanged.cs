using Microsoft.EntityFrameworkCore.Migrations;

namespace Diploma.Migrations
{
    public partial class NamesChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                table: "Degrees",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Contracts",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "dcc0a718-296d-4cbe-b087-c39e4244256a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 2, "dbf5e1ed-5a59-4ab7-a8db-8039fa6d63b9", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                table: "Degrees",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Contracts",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "9c487d01-7573-405b-bd3f-ffb5d7fcd314");
        }
    }
}
