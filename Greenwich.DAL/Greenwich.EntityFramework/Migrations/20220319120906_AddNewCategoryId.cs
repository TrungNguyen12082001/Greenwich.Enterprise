using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Greenwich.EntityFramework.Migrations
{
    public partial class AddNewCategoryId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLiked",
                table: "Ideas");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Ideas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Ideas");

            migrationBuilder.AddColumn<bool>(
                name: "IsLiked",
                table: "Ideas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
