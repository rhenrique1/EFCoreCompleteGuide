using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class ChangeFluentBookTableToFluentBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FluentBook_FluentBookDetails_BookDetailId",
                table: "FluentBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FluentBookDetails",
                table: "FluentBookDetails");

            migrationBuilder.RenameTable(
                name: "FluentBookDetails",
                newName: "FluentBookDetail");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FluentBook_FluentBookDetail_BookDetailId",
                table: "FluentBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FluentBookDetail",
                table: "FluentBookDetail");

            migrationBuilder.RenameTable(
                name: "FluentBookDetail",
                newName: "FluentBookDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FluentBookDetails",
                table: "FluentBookDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBook_FluentBookDetails_BookDetailId",
                table: "FluentBook",
                column: "BookDetailId",
                principalTable: "FluentBookDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
