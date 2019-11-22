using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppWork.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proekt",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectName = table.Column<string>(nullable: false),
                    NumberOfWorkers = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proekt", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Programist",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ManageWork",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProektId = table.Column<int>(nullable: false),
                    ProgramistId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManageWork", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ManageWork_Proekt_ProektId",
                        column: x => x.ProektId,
                        principalTable: "Proekt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManageWork_Programist_ProgramistId",
                        column: x => x.ProgramistId,
                        principalTable: "Programist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ManageWork_ProektId",
                table: "ManageWork",
                column: "ProektId");

            migrationBuilder.CreateIndex(
                name: "IX_ManageWork_ProgramistId",
                table: "ManageWork",
                column: "ProgramistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManageWork");

            migrationBuilder.DropTable(
                name: "Proekt");

            migrationBuilder.DropTable(
                name: "Programist");
        }
    }
}
