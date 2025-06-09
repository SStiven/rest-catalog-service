using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestCatalogService.WebApi.Persistence.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Category 1" },
                    { new Guid("11111111-1111-1111-1111-111111111112"), "Category 2" },
                    { new Guid("11111111-1111-1111-1111-111111111113"), "Category 3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111112"));

            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111113"));
        }
    }
}
