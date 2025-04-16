using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.api.Data.migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateOnly(2001, 11, 15));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "GOTY", "ReleaseDate" },
                values: new object[] { true, new DateOnly(2015, 5, 19) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                column: "ReleaseDate",
                value: new DateOnly(2014, 9, 2));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                column: "ReleaseDate",
                value: new DateOnly(2016, 10, 21));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateOnly(1, 1, 1));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "GOTY", "ReleaseDate" },
                values: new object[] { false, new DateOnly(1, 1, 1) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                column: "ReleaseDate",
                value: new DateOnly(1, 1, 1));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                column: "ReleaseDate",
                value: new DateOnly(1, 1, 1));
        }
    }
}
