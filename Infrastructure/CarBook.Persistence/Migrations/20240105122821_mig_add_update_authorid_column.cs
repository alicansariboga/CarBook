using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_update_authorid_column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blog_Author_AuthorID1",
                table: "Blog");

            migrationBuilder.DropIndex(
                name: "IX_Blog_AuthorID1",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "AuthorID1",
                table: "Blog");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorID",
                table: "Blog",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_AuthorID",
                table: "Blog",
                column: "AuthorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_Author_AuthorID",
                table: "Blog",
                column: "AuthorID",
                principalTable: "Author",
                principalColumn: "AuthorID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blog_Author_AuthorID",
                table: "Blog");

            migrationBuilder.DropIndex(
                name: "IX_Blog_AuthorID",
                table: "Blog");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorID",
                table: "Blog",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AuthorID1",
                table: "Blog",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Blog_AuthorID1",
                table: "Blog",
                column: "AuthorID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_Author_AuthorID1",
                table: "Blog",
                column: "AuthorID1",
                principalTable: "Author",
                principalColumn: "AuthorID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
