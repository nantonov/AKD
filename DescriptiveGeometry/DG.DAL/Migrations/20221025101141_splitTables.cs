using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DG.DAL.Migrations
{
    public partial class splitTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescriptionPhotoLink",
                table: "Drawings");

            migrationBuilder.DropColumn(
                name: "Points",
                table: "Drawings");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Drawings");

            migrationBuilder.CreateTable(
                name: "DrawingDescription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Points = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionPhotoLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrawingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrawingDescription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrawingDescription_Drawings_Id",
                        column: x => x.Id,
                        principalTable: "Drawings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrawingDescription");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionPhotoLink",
                table: "Drawings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Points",
                table: "Drawings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Drawings",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
