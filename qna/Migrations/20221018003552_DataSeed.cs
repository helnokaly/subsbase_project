using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace qna.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthId", "Password", "Username" },
                values: new object[] { 1, "536fa4c1-bd09-4d71-9621-ea73d4e86bf3", "origin_of_species", "charles_darwin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthId", "Password", "Username" },
                values: new object[] { 2, "e95b5712-1904-48c7-8658-3e76af36b280", "free_software", "richard_stallman" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthId", "Password", "Username" },
                values: new object[] { 3, "65dc1da2-6124-4b80-9bcf-c5941bbf7406", "penicillin", "alexander_fleming" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthId", "Password", "Username" },
                values: new object[] { 4, "2596c58b-591c-4422-a1da-82f3d4130c51", "unix", "ken_thompson" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthId", "Password", "Username" },
                values: new object[] { 5, "64b3ebc6-1cd5-4c27-9332-813bff01e936", "wonderland", "alice" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Description", "UserId" },
                values: new object[] { 1, "Who is the president of the USA?", 1 });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Description", "UserId" },
                values: new object[] { 2, "What is the captial of Egypt?", 2 });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "Description", "QuestionId", "UserId" },
                values: new object[] { 1, "Joe Biden", 1, 3 });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "Description", "QuestionId", "UserId" },
                values: new object[] { 2, "Cairo", 2, 4 });

            migrationBuilder.InsertData(
                table: "Votes",
                columns: new[] { "Id", "AnswerId", "UserId", "Value" },
                values: new object[] { 1, 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Votes",
                columns: new[] { "Id", "AnswerId", "UserId", "Value" },
                values: new object[] { 2, 2, 2, -1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Votes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Votes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
