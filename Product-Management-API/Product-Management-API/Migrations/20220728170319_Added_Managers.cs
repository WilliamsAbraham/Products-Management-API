using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product_Management_API.Migrations
{
    public partial class Added_Managers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c78bd2a-d5be-4b27-8513-aa7ec3641137");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7d0208d-a2e6-469c-843d-f36c09fa4c2b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1bd6f452-4165-4347-a3ab-e65936ad087b", "a209aac0-33ef-49bc-8d3c-3b01198fece1", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "42569b1e-b43a-46cb-9361-79dabfafe33a", "49410f72-3e0d-4051-b038-e806143c9754", "Staff", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bd6f452-4165-4347-a3ab-e65936ad087b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42569b1e-b43a-46cb-9361-79dabfafe33a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5c78bd2a-d5be-4b27-8513-aa7ec3641137", "ab5a2630-5f9b-4d06-a15d-93af4b6b378b", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c7d0208d-a2e6-469c-843d-f36c09fa4c2b", "f9be8a4d-e878-44ca-a860-7194ced5cf4b", "Staff", "ADMINISTRATOR" });
        }
    }
}
