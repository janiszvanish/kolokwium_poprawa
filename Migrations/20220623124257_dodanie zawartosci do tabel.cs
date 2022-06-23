using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kolokwium_poprawa.Migrations
{
    public partial class dodaniezawartoscidotabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberID", "MemberName", "MemberNickName", "MemberSurname", "OrganizationID" },
                values: new object[,]
                {
                    { 1, "Jan", "Kowal", "Kowalski", 0 },
                    { 2, "Monika", "Monoia", "Nowak", 0 },
                    { 3, "Mikołaj", "Cool gosciu", "Gitara", 0 }
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "OrganizationID", "OrganizationDomain", "OrganizationName" },
                values: new object[] { 1, "PJATK", "Polsko-Japońska Akademia Technik Komputerowych" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamID", "OrganizationID", "TeamDescription", "TeamName" },
                values: new object[,]
                {
                    { 1, 0, "Cool przedmiot", "APBD" },
                    { 2, 0, "Nie taki coll jak APBD", "Wyklad" }
                });

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
                table: "Members",
                keyColumn: "MemberID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Memberships",
                keyColumns: new[] { "MemberID", "TeamID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Memberships",
                keyColumns: new[] { "MemberID", "TeamID" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "OrganizationID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamID",
                keyValue: 1);
        }
    }
}
