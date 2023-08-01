using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zira.RazorPages.Data.Migrations
{
    public partial class Details : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Client");

            migrationBuilder.RenameColumn(
                name: "Details",
                table: "Client",
                newName: "Region");

            migrationBuilder.AddColumn<int>(
                name: "DetailsId",
                table: "Client",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FactSheet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentSlimFilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Frequency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Multilanguage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomFont = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomColorScheme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HardcodedSection = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NarrativeManager = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DetailsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactSheet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FactSheet_Details_DetailsId",
                        column: x => x.DetailsId,
                        principalTable: "Details",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FactSheetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_FactSheet_FactSheetId",
                        column: x => x.FactSheetId,
                        principalTable: "FactSheet",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FactSheetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contact_FactSheet_FactSheetId",
                        column: x => x.FactSheetId,
                        principalTable: "FactSheet",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CustomComponent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FactSheetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomComponent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomComponent_FactSheet_FactSheetId",
                        column: x => x.FactSheetId,
                        principalTable: "FactSheet",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FactSheetId = table.Column<int>(type: "int", nullable: true)
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
                name: "ExampleOutput",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FactSheetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExampleOutput", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExampleOutput_FactSheet_FactSheetId",
                        column: x => x.FactSheetId,
                        principalTable: "FactSheet",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InitialRPDImplementation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FactSheetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InitialRPDImplementation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InitialRPDImplementation_FactSheet_FactSheetId",
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FactSheetId = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "PRBProductionJob",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Frequency = table.Column<int>(type: "int", nullable: false),
                    FactSheetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRBProductionJob", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PRBProductionJob_FactSheet_FactSheetId",
                        column: x => x.FactSheetId,
                        principalTable: "FactSheet",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UDF",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExampleAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FactSheetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UDF", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UDF_FactSheet_FactSheetId",
                        column: x => x.FactSheetId,
                        principalTable: "FactSheet",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_DetailsId",
                table: "Client",
                column: "DetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_FactSheetId",
                table: "Account",
                column: "FactSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_FactSheetId",
                table: "Contact",
                column: "FactSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomComponent_FactSheetId",
                table: "CustomComponent",
                column: "FactSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_FactSheetId",
                table: "Document",
                column: "FactSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_ExampleOutput_FactSheetId",
                table: "ExampleOutput",
                column: "FactSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_FactSheet_DetailsId",
                table: "FactSheet",
                column: "DetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialRPDImplementation_FactSheetId",
                table: "InitialRPDImplementation",
                column: "FactSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_OutputType_FactSheetId",
                table: "OutputType",
                column: "FactSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_PRBProductionJob_FactSheetId",
                table: "PRBProductionJob",
                column: "FactSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_UDF_FactSheetId",
                table: "UDF",
                column: "FactSheetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Details_DetailsId",
                table: "Client",
                column: "DetailsId",
                principalTable: "Details",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_Details_DetailsId",
                table: "Client");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "CustomComponent");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "ExampleOutput");

            migrationBuilder.DropTable(
                name: "InitialRPDImplementation");

            migrationBuilder.DropTable(
                name: "OutputType");

            migrationBuilder.DropTable(
                name: "PRBProductionJob");

            migrationBuilder.DropTable(
                name: "UDF");

            migrationBuilder.DropTable(
                name: "FactSheet");

            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropIndex(
                name: "IX_Client_DetailsId",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "DetailsId",
                table: "Client");

            migrationBuilder.RenameColumn(
                name: "Region",
                table: "Client",
                newName: "Details");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
