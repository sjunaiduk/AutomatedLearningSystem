using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutomatedLearningSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LearningItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    Category = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Category = table.Column<int>(type: "INTEGER", nullable: false),
                    DifficultyLevel = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnswerForQuestion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    QuestionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Response = table.Column<int>(type: "INTEGER", nullable: false),
                    AddedDateTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerForQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerForQuestion_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LearningPath",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningPath", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LearningPath_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LearningItemLearningPath",
                columns: table => new
                {
                    LearningItemsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LearningPathId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningItemLearningPath", x => new { x.LearningItemsId, x.LearningPathId });
                    table.ForeignKey(
                        name: "FK_LearningItemLearningPath_LearningItem_LearningItemsId",
                        column: x => x.LearningItemsId,
                        principalTable: "LearningItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LearningItemLearningPath_LearningPath_LearningPathId",
                        column: x => x.LearningPathId,
                        principalTable: "LearningPath",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerForQuestion_QuestionId",
                table: "AnswerForQuestion",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_LearningItemLearningPath_LearningPathId",
                table: "LearningItemLearningPath",
                column: "LearningPathId");

            migrationBuilder.CreateIndex(
                name: "IX_LearningPath_UserId",
                table: "LearningPath",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerForQuestion");

            migrationBuilder.DropTable(
                name: "LearningItemLearningPath");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "LearningItem");

            migrationBuilder.DropTable(
                name: "LearningPath");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
