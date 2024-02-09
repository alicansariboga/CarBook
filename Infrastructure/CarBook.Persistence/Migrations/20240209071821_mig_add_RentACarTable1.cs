using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_RentACarTable1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentACars_Locations_PickUplocationID",
                table: "RentACars");

            migrationBuilder.RenameColumn(
                name: "PickUplocationID",
                table: "RentACars",
                newName: "LocationID");

            migrationBuilder.RenameIndex(
                name: "IX_RentACars_PickUplocationID",
                table: "RentACars",
                newName: "IX_RentACars_LocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_RentACars_Locations_LocationID",
                table: "RentACars",
                column: "LocationID",
                principalTable: "Locations",
                principalColumn: "LocationID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentACars_Locations_LocationID",
                table: "RentACars");

            migrationBuilder.RenameColumn(
                name: "LocationID",
                table: "RentACars",
                newName: "PickUplocationID");

            migrationBuilder.RenameIndex(
                name: "IX_RentACars_LocationID",
                table: "RentACars",
                newName: "IX_RentACars_PickUplocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_RentACars_Locations_PickUplocationID",
                table: "RentACars",
                column: "PickUplocationID",
                principalTable: "Locations",
                principalColumn: "LocationID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
