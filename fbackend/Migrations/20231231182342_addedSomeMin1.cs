using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fbackend.Migrations
{
    /// <inheritdoc />
    public partial class addedSomeMin1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostComments_Blogs_BlogId",
                table: "PostComments");

            migrationBuilder.AlterColumn<int>(
                name: "BlogId",
                table: "PostComments",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PostComments_Blogs_BlogId",
                table: "PostComments",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostComments_Blogs_BlogId",
                table: "PostComments");

            migrationBuilder.AlterColumn<int>(
                name: "BlogId",
                table: "PostComments",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_PostComments_Blogs_BlogId",
                table: "PostComments",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id");
        }
    }
}
