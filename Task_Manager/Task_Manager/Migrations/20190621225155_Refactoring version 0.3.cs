using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Task_Manager.Migrations
{
    public partial class Refactoringversion03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaskTypeId",
                table: "TaskModels",
                newName: "ChildId");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "TaskModels",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "TaskModels");

            migrationBuilder.RenameColumn(
                name: "ChildId",
                table: "TaskModels",
                newName: "TaskTypeId");
        }
    }
}
