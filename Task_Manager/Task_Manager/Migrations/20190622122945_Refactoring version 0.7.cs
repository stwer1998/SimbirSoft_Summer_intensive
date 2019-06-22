using Microsoft.EntityFrameworkCore.Migrations;

namespace Task_Manager.Migrations
{
    public partial class Refactoringversion07 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDone",
                table: "TaskForDates");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Childs",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDone",
                table: "TaskForDates",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Childs",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);
        }
    }
}
