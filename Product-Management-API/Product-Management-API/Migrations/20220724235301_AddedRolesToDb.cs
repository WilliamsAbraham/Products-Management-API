using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product_Management_API.Migrations
{
    public partial class AddedRolesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "11134aab-81b3-4a7d-9e32-c1f0d60db607", "910250c8-a161-4448-8f8a-706e2debefa9", "Staff", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4bfdc048-1abe-4095-ba56-b36b09aaaabb", "1c4ce606-c801-4d2a-becd-460a0fb8b934", "Manager", "MANAGER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11134aab-81b3-4a7d-9e32-c1f0d60db607");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4bfdc048-1abe-4095-ba56-b36b09aaaabb");
        }
    }
}
