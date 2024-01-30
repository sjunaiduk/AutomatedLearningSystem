using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutomatedLearningSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAnswerForQuestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "AnswerForQuestion",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AnswerForQuestion_UserId",
                table: "AnswerForQuestion",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerForQuestion_User_UserId",
                table: "AnswerForQuestion",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerForQuestion_User_UserId",
                table: "AnswerForQuestion");

            migrationBuilder.DropIndex(
                name: "IX_AnswerForQuestion_UserId",
                table: "AnswerForQuestion");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AnswerForQuestion");
        }
    }
}
