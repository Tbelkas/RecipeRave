using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recipe.Persistence.Migrations
{
    public partial class AddBase64ImageToRecipeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Base64Image",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Base64Image",
                table: "Recipes");
        }
    }
}
