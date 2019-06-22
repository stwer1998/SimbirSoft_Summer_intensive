using Microsoft.EntityFrameworkCore.Migrations;

namespace Task_Manager.Migrations
{
    public partial class Refactoringverson06 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "StatusTask",
                table: "TaskForDates",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StatusTask",
                table: "TaskForDates",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
