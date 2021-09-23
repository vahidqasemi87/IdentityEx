using Microsoft.EntityFrameworkCore.Migrations;

namespace Part01.Models.Migrations
{
    public partial class init02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "BlackLists");

            migrationBuilder.AddColumn<string>(
                name: "SNN",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SNN",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "BlackLists",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
