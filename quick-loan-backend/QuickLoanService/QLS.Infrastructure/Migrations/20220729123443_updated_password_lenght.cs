using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLS.Infrastructure.Migrations
{
    public partial class updated_password_lenght : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Password" },
                values: new object[] { new DateTime(2022, 7, 29, 12, 34, 42, 584, DateTimeKind.Utc).AddTicks(8030), "$2a$11$skzXhGcZkwkeAbHsk2izSeA3LwdefnnNMwlVSQe2rb.DPlylhSic." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "Password" },
                values: new object[] { new DateTime(2022, 7, 29, 12, 34, 42, 321, DateTimeKind.Utc).AddTicks(7080), "$2a$11$pqKqzyUH8CCTOwee9uBipewtLkh6Ldi05UW5yM6DaDpbbHswAnRsO" });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 7, 29, 12, 34, 42, 584, DateTimeKind.Utc).AddTicks(8760));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Password" },
                values: new object[] { new DateTime(2022, 7, 29, 12, 3, 26, 729, DateTimeKind.Utc).AddTicks(5580), "$2a$11$5mM9x7.XXf1PBLp6RoLET.GT5oeFJ6WPe6UtasMbZ./.xFEb0DFbS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "Password" },
                values: new object[] { new DateTime(2022, 7, 29, 12, 3, 26, 526, DateTimeKind.Utc).AddTicks(2890), "$2a$11$5Vym5MZRgBH4wE/XrF3KFeE6Ims0ukb8zyWICLCmmQJraRH.1ex3q" });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 7, 29, 12, 3, 26, 729, DateTimeKind.Utc).AddTicks(6130));
        }
    }
}
