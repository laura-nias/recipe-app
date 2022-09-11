using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeVault.Migrations
{
    public partial class changemodelname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "image_id",
                table: "Recipes",
                newName: "image");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "image",
                table: "Recipes",
                newName: "image_id");
        }
    }
}
