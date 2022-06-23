using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kolokwium_poprawa.Migrations
{
    public partial class dodaniezawartoscidotabel3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "OrganizationID", "OrganizationDomain", "OrganizationName" },
                values: new object[] { 1, "PJATK", "PJATK" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamID", "OrganizationID", "TeamDescription", "TeamName" },
                values: new object[] { 1, 1, "Cool przedmiot", "APBD" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamID", "OrganizationID", "TeamDescription", "TeamName" },
                values: new object[] { 2, 1, "Nie taki coll jak APBD", "Wyklad" });

            migrationBuilder.InsertData(
                table: "Memberships",
                columns: new[] { "MemberID", "TeamID", "MembershipDate" },
                values: new object[] { 1, 1, new DateTime(2022, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Memberships",
                columns: new[] { "MemberID", "TeamID", "MembershipDate" },
                values: new object[] { 2, 1, new DateTime(2022, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Memberships",
                keyColumns: new[] { "MemberID", "TeamID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Memberships",
                keyColumns: new[] { "MemberID", "TeamID" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "OrganizationID",
                keyValue: 1);
        }
    }
}
