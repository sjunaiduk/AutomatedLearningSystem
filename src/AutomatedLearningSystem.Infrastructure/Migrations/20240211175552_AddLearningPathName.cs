using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutomatedLearningSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddLearningPathName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "LearningPath",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "LearningPath");
        }
    }
}
