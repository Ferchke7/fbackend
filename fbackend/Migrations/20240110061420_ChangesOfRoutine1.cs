using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fbackend.Migrations
{
    /// <inheritdoc />
    public partial class ChangesOfRoutine1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoutineList",
                table: "Routines",
                newName: "Wednesday");

            migrationBuilder.AddColumn<string>(
                name: "Friday",
                table: "Routines",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Monday",
                table: "Routines",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Saturday",
                table: "Routines",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sunday",
                table: "Routines",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Thursday",
                table: "Routines",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tuesday",
                table: "Routines",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Friday",
                table: "Routines");

            migrationBuilder.DropColumn(
                name: "Monday",
                table: "Routines");

            migrationBuilder.DropColumn(
                name: "Saturday",
                table: "Routines");

            migrationBuilder.DropColumn(
                name: "Sunday",
                table: "Routines");

            migrationBuilder.DropColumn(
                name: "Thursday",
                table: "Routines");

            migrationBuilder.DropColumn(
                name: "Tuesday",
                table: "Routines");

            migrationBuilder.RenameColumn(
                name: "Wednesday",
                table: "Routines",
                newName: "RoutineList");
        }
    }
}
