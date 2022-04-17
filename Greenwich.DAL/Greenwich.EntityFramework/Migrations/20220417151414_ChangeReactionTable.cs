using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Greenwich.EntityFramework.Migrations
{
    public partial class ChangeReactionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLike",
                table: "Reactions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsUnlike",
                table: "Reactions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLike",
                table: "Reactions");

            migrationBuilder.DropColumn(
                name: "IsUnlike",
                table: "Reactions");
        }
    }
}
