using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class AddManyToManyBookAndAuthorCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FluentBookAuthor_FluentAuthors_AuthorId1",
                table: "FluentBookAuthor");

            migrationBuilder.DropForeignKey(
                name: "FK_FluentBookAuthor_FluentBooks_AuthorId",
                table: "FluentBookAuthor");

            migrationBuilder.DropIndex(
                name: "IX_FluentBookAuthor_AuthorId1",
                table: "FluentBookAuthor");

            migrationBuilder.DropColumn(
                name: "AuthorId1",
                table: "FluentBookAuthor");

            migrationBuilder.CreateIndex(
                name: "IX_FluentBookAuthor_BookId",
                table: "FluentBookAuthor",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBookAuthor_FluentAuthors_AuthorId",
                table: "FluentBookAuthor",
                column: "AuthorId",
                principalTable: "FluentAuthors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBookAuthor_FluentBooks_BookId",
                table: "FluentBookAuthor",
                column: "BookId",
                principalTable: "FluentBooks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FluentBookAuthor_FluentAuthors_AuthorId",
                table: "FluentBookAuthor");

            migrationBuilder.DropForeignKey(
                name: "FK_FluentBookAuthor_FluentBooks_BookId",
                table: "FluentBookAuthor");

            migrationBuilder.DropIndex(
                name: "IX_FluentBookAuthor_BookId",
                table: "FluentBookAuthor");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId1",
                table: "FluentBookAuthor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FluentBookAuthor_AuthorId1",
                table: "FluentBookAuthor",
                column: "AuthorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBookAuthor_FluentAuthors_AuthorId1",
                table: "FluentBookAuthor",
                column: "AuthorId1",
                principalTable: "FluentAuthors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBookAuthor_FluentBooks_AuthorId",
                table: "FluentBookAuthor",
                column: "AuthorId",
                principalTable: "FluentBooks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
