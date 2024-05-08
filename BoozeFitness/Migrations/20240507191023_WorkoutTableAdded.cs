using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoozeFitness.Migrations
{
    /// <inheritdoc />
    public partial class WorkoutTableAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GroupTargeted = table.Column<int>(type: "INTEGER", nullable: false),
                    Difficulty = table.Column<int>(type: "INTEGER", nullable: false),
                    Duration = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.UserID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Workouts");
        }
    }
}
