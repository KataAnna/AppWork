using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppWork.Migrations
{
    public partial class InitialOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ManageWork",
                table: "ManageWork");

            migrationBuilder.DropIndex(
                name: "IX_ManageWork_ProgramistId",
                table: "ManageWork");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "ManageWork",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ManageWork",
                table: "ManageWork",
                columns: new[] { "ProgramistId", "ProektId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ManageWork",
                table: "ManageWork");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "ManageWork",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ManageWork",
                table: "ManageWork",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_ManageWork_ProgramistId",
                table: "ManageWork",
                column: "ProgramistId");
        }
    }
}
