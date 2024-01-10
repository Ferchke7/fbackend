using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fbackend.Migrations
{
    /// <inheritdoc />
    public partial class ChangeOfRoutineModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoutineList",
                table: "Routines",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoutineList",
                table: "Routines");
        }
    }
}
