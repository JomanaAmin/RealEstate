using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstate.DAL.Migrations
{
    /// <inheritdoc />
    public partial class propertyImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyImage_properties_PropertyId",
                table: "PropertyImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PropertyImage",
                table: "PropertyImage");

            migrationBuilder.RenameTable(
                name: "PropertyImage",
                newName: "propertyImages");

            migrationBuilder.RenameIndex(
                name: "IX_PropertyImage_PropertyId",
                table: "propertyImages",
                newName: "IX_propertyImages_PropertyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_propertyImages",
                table: "propertyImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_propertyImages_properties_PropertyId",
                table: "propertyImages",
                column: "PropertyId",
                principalTable: "properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_propertyImages_properties_PropertyId",
                table: "propertyImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_propertyImages",
                table: "propertyImages");

            migrationBuilder.RenameTable(
                name: "propertyImages",
                newName: "PropertyImage");

            migrationBuilder.RenameIndex(
                name: "IX_propertyImages_PropertyId",
                table: "PropertyImage",
                newName: "IX_PropertyImage_PropertyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PropertyImage",
                table: "PropertyImage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyImage_properties_PropertyId",
                table: "PropertyImage",
                column: "PropertyId",
                principalTable: "properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
