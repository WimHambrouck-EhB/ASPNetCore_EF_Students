using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPNetCore_EF_Students.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, ".NET Essentials" },
                    { 2, ".NET Advanced" },
                    { 3, "Programming Essentials" },
                    { 4, "Programming Advanced" },
                    { 5, "Data Essentials" },
                    { 6, "Data Advanced" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Wim" },
                    { 2, "Paul" },
                    { 3, "Marvin" },
                    { 4, "Michael" },
                    { 5, "Amber" },
                    { 6, "Anna" },
                    { 7, "Belle" },
                    { 8, "Carrie" }
                });

            migrationBuilder.InsertData(
                table: "Scores",
                columns: new[] { "Id", "CourseId", "Grade", "StudentId" },
                values: new object[] { 1, 1, 20, 1 });

            migrationBuilder.InsertData(
                table: "Scores",
                columns: new[] { "Id", "CourseId", "Grade", "StudentId" },
                values: new object[] { 2, 2, 20, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
