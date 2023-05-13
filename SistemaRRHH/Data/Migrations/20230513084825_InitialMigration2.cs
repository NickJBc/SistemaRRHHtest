using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaRRHH.Data.Migrations
{
    public partial class InitialMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Family_Worker_WorkerId",
                table: "Family");

            migrationBuilder.AlterColumn<int>(
                name: "WorkerId",
                table: "Family",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Family_Worker_WorkerId",
                table: "Family",
                column: "WorkerId",
                principalTable: "Worker",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Family_Worker_WorkerId",
                table: "Family");

            migrationBuilder.AlterColumn<int>(
                name: "WorkerId",
                table: "Family",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Family_Worker_WorkerId",
                table: "Family",
                column: "WorkerId",
                principalTable: "Worker",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
