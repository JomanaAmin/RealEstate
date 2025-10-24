using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RealEstate.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedingPropertyTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_properties_PropertyType_PropertyTypeId",
                table: "properties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PropertyType",
                table: "PropertyType");

            migrationBuilder.RenameTable(
                name: "PropertyType",
                newName: "propertyTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_propertyTypes",
                table: "propertyTypes",
                column: "Id");

            migrationBuilder.InsertData(
                table: "propertyTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { -3, "D3", "TownHouse" },
                    { -2, "D2", "Villa" },
                    { -1, "D1", "Flat" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_properties_propertyTypes_PropertyTypeId",
                table: "properties",
                column: "PropertyTypeId",
                principalTable: "propertyTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_properties_propertyTypes_PropertyTypeId",
                table: "properties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_propertyTypes",
                table: "propertyTypes");

            migrationBuilder.DeleteData(
                table: "propertyTypes",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "propertyTypes",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "propertyTypes",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.RenameTable(
                name: "propertyTypes",
                newName: "PropertyType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PropertyType",
                table: "PropertyType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_properties_PropertyType_PropertyTypeId",
                table: "properties",
                column: "PropertyTypeId",
                principalTable: "PropertyType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
