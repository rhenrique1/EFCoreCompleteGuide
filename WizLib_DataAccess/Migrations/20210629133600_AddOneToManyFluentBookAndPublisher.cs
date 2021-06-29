using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class AddOneToManyFluentBookAndPublisher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PublisherId",
                table: "FluentBook",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FluentBook_PublisherId",
                table: "FluentBook",
                column: "PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBook_FluentPublishers_PublisherId",
                table: "FluentBook",
                column: "PublisherId",
                principalTable: "FluentPublishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FluentBook_FluentPublishers_PublisherId",
                table: "FluentBook");

            migrationBuilder.DropIndex(
                name: "IX_FluentBook_PublisherId",
                table: "FluentBook");

            migrationBuilder.DropColumn(
                name: "PublisherId",
                table: "FluentBook");
        }
    }
}
