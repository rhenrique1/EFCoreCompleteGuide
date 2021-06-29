using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class AddManyToManyBookAndAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthors_FluentAuthors_FluentAuthorId",
                table: "BookAuthors");

            migrationBuilder.DropIndex(
                name: "IX_BookAuthors_FluentAuthorId",
                table: "BookAuthors");

            migrationBuilder.DropColumn(
                name: "FluentAuthorId",
                table: "BookAuthors");

            migrationBuilder.CreateTable(
                name: "FluentBookAuthor",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    AuthorId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FluentBookAuthor", x => new { x.AuthorId, x.BookId });
                    table.ForeignKey(
                        name: "FK_FluentBookAuthor_FluentAuthors_AuthorId1",
                        column: x => x.AuthorId1,
                        principalTable: "FluentAuthors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FluentBookAuthor_FluentBooks_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "FluentBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FluentBookAuthor_AuthorId1",
                table: "FluentBookAuthor",
                column: "AuthorId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FluentBookAuthor");

            migrationBuilder.AddColumn<int>(
                name: "FluentAuthorId",
                table: "BookAuthors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_FluentAuthorId",
                table: "BookAuthors",
                column: "FluentAuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthors_FluentAuthors_FluentAuthorId",
                table: "BookAuthors",
                column: "FluentAuthorId",
                principalTable: "FluentAuthors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
