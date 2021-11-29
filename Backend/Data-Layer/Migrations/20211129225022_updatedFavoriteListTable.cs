using Microsoft.EntityFrameworkCore.Migrations;

namespace Data_Layer.Migrations
{
    public partial class updatedFavoriteListTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AmazonVideo",
                table: "FavoriteLists",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DisneyPlus",
                table: "FavoriteLists",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HboMax",
                table: "FavoriteLists",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Hulu",
                table: "FavoriteLists",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "FavoriteLists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Netflix",
                table: "FavoriteLists",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmazonVideo",
                table: "FavoriteLists");

            migrationBuilder.DropColumn(
                name: "DisneyPlus",
                table: "FavoriteLists");

            migrationBuilder.DropColumn(
                name: "HboMax",
                table: "FavoriteLists");

            migrationBuilder.DropColumn(
                name: "Hulu",
                table: "FavoriteLists");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "FavoriteLists");

            migrationBuilder.DropColumn(
                name: "Netflix",
                table: "FavoriteLists");
        }
    }
}
