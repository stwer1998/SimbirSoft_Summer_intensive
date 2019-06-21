using Microsoft.EntityFrameworkCore.Migrations;

namespace Task_Manager.Migrations
{
    public partial class Refactoringversion04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskForDates_TaskModels_TaskElementId",
                table: "TaskForDates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskModels",
                table: "TaskModels");

            migrationBuilder.RenameTable(
                name: "TaskModels",
                newName: "TaskElements");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskElements",
                table: "TaskElements",
                column: "TaskElementId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskForDates_TaskElements_TaskElementId",
                table: "TaskForDates",
                column: "TaskElementId",
                principalTable: "TaskElements",
                principalColumn: "TaskElementId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskForDates_TaskElements_TaskElementId",
                table: "TaskForDates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskElements",
                table: "TaskElements");

            migrationBuilder.RenameTable(
                name: "TaskElements",
                newName: "TaskModels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskModels",
                table: "TaskModels",
                column: "TaskElementId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskForDates_TaskModels_TaskElementId",
                table: "TaskForDates",
                column: "TaskElementId",
                principalTable: "TaskModels",
                principalColumn: "TaskElementId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
