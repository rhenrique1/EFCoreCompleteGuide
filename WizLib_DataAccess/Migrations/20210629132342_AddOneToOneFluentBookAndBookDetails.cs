using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class AddOneToOneFluentBookAndBookDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookDetailId",
                table: "FluentBook",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FluentBook_BookDetailId",
                table: "FluentBook",
                column: "BookDetailId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBook_FluentBookDetails_BookDetailId",
                table: "FluentBook",
                column: "BookDetailId",
                principalTable: "FluentBookDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FluentBook_FluentBookDetails_BookDetailId",
                table: "FluentBook");

            migrationBuilder.DropIndex(
                name: "IX_FluentBook_BookDetailId",
                table: "FluentBook");

            migrationBuilder.DropColumn(
                name: "BookDetailId",
                table: "FluentBook");
        }
    }
}
