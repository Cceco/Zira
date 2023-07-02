using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zira.RazorPages.Data.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "OutputType");

            migrationBuilder.RenameColumn(
                name: "Multilanguage",
                table: "FactSheet",
                newName: "MultiLanguage");

            migrationBuilder.AddColumn<string>(
                name: "OutputType",
                table: "FactSheet",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OutputType",
                table: "FactSheet");

            migrationBuilder.RenameColumn(
                name: "MultiLanguage",
                table: "FactSheet",
                newName: "Multilanguage");

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactSheetId = table.Column<int>(type: "int", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Document_FactSheet_FactSheetId",
                        column: x => x.FactSheetId,
                        principalTable: "FactSheet",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OutputType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactSheetId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutputType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutputType_FactSheet_FactSheetId",
                        column: x => x.FactSheetId,
                        principalTable: "FactSheet",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Document_FactSheetId",
                table: "Document",
                column: "FactSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_OutputType_FactSheetId",
                table: "OutputType",
                column: "FactSheetId");
        }
    }
}
