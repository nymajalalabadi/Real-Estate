using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstate_DataLayer.Migrations
{
    public partial class ChangeEstate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Estates");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Estates",
                type: "int",
                nullable: true);
        }
    }
}
