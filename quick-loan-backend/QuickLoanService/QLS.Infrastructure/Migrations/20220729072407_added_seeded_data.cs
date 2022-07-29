using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLS.Infrastructure.Migrations
{
    public partial class added_seeded_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Email", "IsDeleted", "ModifiedBy", "ModifiedOn", "Name", "Password", "Role" },
                values: new object[] { 1, null, new DateTime(2022, 7, 29, 7, 24, 7, 121, DateTimeKind.Utc).AddTicks(8470), "johndoe@gmail.com", false, null, null, "John Doe", "$2a$11$79LOnHkUzWiRBk9K51Kud.sO9nzQ5vqwA3AS7UDegyoizjwmyWQs2", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Email", "IsDeleted", "ModifiedBy", "ModifiedOn", "Name", "Password", "Role" },
                values: new object[] { 2, null, new DateTime(2022, 7, 29, 7, 24, 7, 338, DateTimeKind.Utc).AddTicks(9630), "janedoe@gmail.com", false, null, null, "Jane Doe", "$2a$11$ujtj/v7WtcfWERJoAwQM3eFkWZ.c8S13S.BNlxmjw3wXdj/DxV5Xm", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
