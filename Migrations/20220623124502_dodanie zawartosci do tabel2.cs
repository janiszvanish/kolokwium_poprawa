using Microsoft.EntityFrameworkCore.Migrations;

namespace kolokwium_poprawa.Migrations
{
    public partial class dodaniezawartoscidotabel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "OrganizationID",
                keyValue: 1,
                column: "OrganizationName",
                value: "PJATK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "OrganizationID",
                keyValue: 1,
                column: "OrganizationName",
                value: "Polsko-Japońska Akademia Technik Komputerowych");
        }
    }
}
