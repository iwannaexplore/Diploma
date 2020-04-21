using Microsoft.EntityFrameworkCore.Migrations;

namespace Diploma.Migrations
{
    public partial class AddedContractType2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "1e28b5db-bc45-468d-829d-73a717d766b8");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "b5fdf5fb-6477-4173-9b3a-a0f586e0e234");
        }
    }
}
