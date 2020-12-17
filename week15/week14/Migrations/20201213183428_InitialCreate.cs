using Microsoft.EntityFrameworkCore.Migrations;

namespace week14.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursus",
                columns: table => new
                {
                    cursusId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    cursusNaam = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursus", x => x.cursusId);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    studentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    studentNaam = table.Column<string>(type: "TEXT", nullable: true),
                    lengte = table.Column<int>(type: "INTEGER", nullable: false),
                    leeftijd = table.Column<int>(type: "INTEGER", nullable: true),
                    cursusId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.studentId);
                    table.ForeignKey(
                        name: "FK_Student_Cursus_cursusId",
                        column: x => x.cursusId,
                        principalTable: "Cursus",
                        principalColumn: "cursusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_cursusId",
                table: "Student",
                column: "cursusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Cursus");
        }
    }
}
