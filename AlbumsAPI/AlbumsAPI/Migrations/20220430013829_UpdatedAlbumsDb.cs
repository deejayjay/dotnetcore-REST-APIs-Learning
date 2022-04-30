using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlbumsAPI.Migrations
{
    public partial class UpdatedAlbumsDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Secret",
                table: "Albums",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Secret",
                table: "Albums");
        }
    }
}
