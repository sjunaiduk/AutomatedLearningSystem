using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutomatedLearningSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateUserLearningItemForLearningPath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LearningItemLearningPath");

            migrationBuilder.CreateTable(
                name: "UserLearningItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    LearningItemId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Completed = table.Column<bool>(type: "INTEGER", nullable: false),
                    LearningPathId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLearningItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLearningItem_LearningItem_LearningItemId",
                        column: x => x.LearningItemId,
                        principalTable: "LearningItem",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserLearningItem_LearningPath_LearningPathId",
                        column: x => x.LearningPathId,
                        principalTable: "LearningPath",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserLearningItem_LearningItemId",
                table: "UserLearningItem",
                column: "LearningItemId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLearningItem_LearningPathId",
                table: "UserLearningItem",
                column: "LearningPathId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLearningItem");

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
                name: "IX_LearningItemLearningPath_LearningPathId",
                table: "LearningItemLearningPath",
                column: "LearningPathId");
        }
    }
}
