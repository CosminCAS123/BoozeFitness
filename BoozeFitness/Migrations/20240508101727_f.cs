using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoozeFitness.Migrations
{
    /// <inheritdoc />
    public partial class f : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Workouts",
                table: "Workouts");

            migrationBuilder.RenameTable(
                name: "Workouts",
                newName: "Workout");

            migrationBuilder.AlterColumn<string>(
                name: "Duration",
                table: "Workout",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Workout",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Workout",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workout",
                table: "Workout",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Workout_UserID",
                table: "Workout",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Workout_Users_UserID",
                table: "Workout",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workout_Users_UserID",
                table: "Workout");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Workout",
                table: "Workout");

            migrationBuilder.DropIndex(
                name: "IX_Workout_UserID",
                table: "Workout");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Workout");

            migrationBuilder.RenameTable(
                name: "Workout",
                newName: "Workouts");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Workouts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "Duration",
                table: "Workouts",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workouts",
                table: "Workouts",
                column: "UserID");
        }
    }
}
