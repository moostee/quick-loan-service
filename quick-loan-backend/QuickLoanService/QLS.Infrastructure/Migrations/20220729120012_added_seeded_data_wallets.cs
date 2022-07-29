using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLS.Infrastructure.Migrations
{
    public partial class added_seeded_data_wallets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "LoanAmount",
                table: "Loans",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Loans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Password" },
                values: new object[] { new DateTime(2022, 7, 29, 12, 0, 12, 264, DateTimeKind.Utc).AddTicks(1140), "$2a$11$6pNNDGQOMiv6/rxLHK97ieXzXBS6AWEMn1DR1ct3NvGv4U8EpOQye" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "Password" },
                values: new object[] { new DateTime(2022, 7, 29, 12, 0, 12, 56, DateTimeKind.Utc).AddTicks(8360), "$2a$11$HzlcOy.zkbQlIgdYNAR64Oe4sMm.9/358rDY1rwvclNGAqH49kCgS" });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "AvailableBalance", "CreatedBy", "CreatedOn", "IsDeleted", "ModifiedBy", "ModifiedOn", "UserId" },
                values: new object[] { 1, 0m, null, new DateTime(2022, 7, 29, 12, 0, 12, 264, DateTimeKind.Utc).AddTicks(1680), false, null, null, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Loans");

            migrationBuilder.AlterColumn<int>(
                name: "LoanAmount",
                table: "Loans",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Password" },
                values: new object[] { new DateTime(2022, 7, 29, 7, 24, 7, 121, DateTimeKind.Utc).AddTicks(8470), "$2a$11$79LOnHkUzWiRBk9K51Kud.sO9nzQ5vqwA3AS7UDegyoizjwmyWQs2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "Password" },
                values: new object[] { new DateTime(2022, 7, 29, 7, 24, 7, 338, DateTimeKind.Utc).AddTicks(9630), "$2a$11$ujtj/v7WtcfWERJoAwQM3eFkWZ.c8S13S.BNlxmjw3wXdj/DxV5Xm" });
        }
    }
}
