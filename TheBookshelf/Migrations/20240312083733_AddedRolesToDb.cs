using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheBookshelf.Migrations
{
    public partial class AddedRolesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3644b31d-ea0c-4360-819a-2da2567ce46c", "21431c96-3def-4126-b259-50f12491574d", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3ca10a80-a8b4-4d4f-a5cd-cce45646ac30", "27e93c3b-19ae-47d0-bc42-d3a657bc4397", "Manager", "MANAGER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3644b31d-ea0c-4360-819a-2da2567ce46c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ca10a80-a8b4-4d4f-a5cd-cce45646ac30");
        }
    }
}
