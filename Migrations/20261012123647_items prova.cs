using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyRepair.Migrations
{
    /// <inheritdoc />
    public partial class itemsprova : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Tipo" },
                values: new object[] { "Batteria s23", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Tipo" },
                values: new object[] { "Samsung S21", 0 });
        }
    }
}
