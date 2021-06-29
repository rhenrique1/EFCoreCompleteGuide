using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class ChangeFluentBookTableToFluentBooksx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FluentBook_FluentBookDetail_BookDetailId",
                table: "FluentBook");

            migrationBuilder.DropForeignKey(
                name: "FK_FluentBook_FluentPublishers_PublisherId",
                table: "FluentBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FluentBookDetail",
                table: "FluentBookDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FluentBook",
                table: "FluentBook");

            migrationBuilder.RenameTable(
                name: "FluentBookDetail",
                newName: "FluentBookDetails");

            migrationBuilder.RenameTable(
                name: "FluentBook",
                newName: "FluentBooks");

            migrationBuilder.RenameIndex(
                name: "IX_FluentBook_PublisherId",
                table: "FluentBooks",
                newName: "IX_FluentBooks_PublisherId");

            migrationBuilder.RenameIndex(
                name: "IX_FluentBook_BookDetailId",
                table: "FluentBooks",
                newName: "IX_FluentBooks_BookDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FluentBookDetails",
                table: "FluentBookDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FluentBooks",
                table: "FluentBooks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBooks_FluentBookDetails_BookDetailId",
                table: "FluentBooks",
                column: "BookDetailId",
                principalTable: "FluentBookDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBooks_FluentPublishers_PublisherId",
                table: "FluentBooks",
                column: "PublisherId",
                principalTable: "FluentPublishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FluentBooks_FluentBookDetails_BookDetailId",
                table: "FluentBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_FluentBooks_FluentPublishers_PublisherId",
                table: "FluentBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FluentBooks",
                table: "FluentBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FluentBookDetails",
                table: "FluentBookDetails");

            migrationBuilder.RenameTable(
                name: "FluentBooks",
                newName: "FluentBook");

            migrationBuilder.RenameTable(
                name: "FluentBookDetails",
                newName: "FluentBookDetail");

            migrationBuilder.RenameIndex(
                name: "IX_FluentBooks_PublisherId",
                table: "FluentBook",
                newName: "IX_FluentBook_PublisherId");

            migrationBuilder.RenameIndex(
                name: "IX_FluentBooks_BookDetailId",
                table: "FluentBook",
                newName: "IX_FluentBook_BookDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FluentBook",
                table: "FluentBook",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FluentBookDetail",
                table: "FluentBookDetail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBook_FluentBookDetail_BookDetailId",
                table: "FluentBook",
                column: "BookDetailId",
                principalTable: "FluentBookDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBook_FluentPublishers_PublisherId",
                table: "FluentBook",
                column: "PublisherId",
                principalTable: "FluentPublishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
