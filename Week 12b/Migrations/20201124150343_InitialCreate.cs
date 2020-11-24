using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Week_12b.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VoorNaam = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    AchterNaam = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Inschrijving = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Opleiding = table.Column<string>(type: "TEXT", nullable: false),
                    LeerJaar = table.Column<int>(type: "INTEGER", nullable: false),
                    HoogsteCijfer = table.Column<double>(type: "REAL", nullable: false),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentId",
                table: "Students",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
