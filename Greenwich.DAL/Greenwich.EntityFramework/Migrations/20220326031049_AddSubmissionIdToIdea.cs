using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Greenwich.EntityFramework.Migrations
{
    public partial class AddSubmissionIdToIdea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubmissionId",
                table: "Ideas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubmissionId",
                table: "Ideas");
        }
    }
}
