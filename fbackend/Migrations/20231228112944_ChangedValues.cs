using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fbackend.Migrations
{
    /// <inheritdoc />
    public partial class ChangedValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "PostCommentsReplies",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "PostCommentsReplies",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "BlogId",
                table: "PostComments",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "PostComments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "PostComments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Blogs",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Blogs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Blogs",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_PostComments_BlogId",
                table: "PostComments",
                column: "BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostComments_Blogs_BlogId",
                table: "PostComments",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostComments_Blogs_BlogId",
                table: "PostComments");

            migrationBuilder.DropIndex(
                name: "IX_PostComments_BlogId",
                table: "PostComments");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "PostCommentsReplies");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "PostCommentsReplies");

            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "PostComments");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "PostComments");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "PostComments");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Blogs");
        }
    }
}
