using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 150, nullable: false),
                    LastName = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 150, nullable: false),
                    Description = table.Column<string>(maxLength: 2500, nullable: true),
                    AuthorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { new Guid("b9383602-01fc-4281-8ead-c451e1be8f94"), "George", "R R Martin" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { new Guid("0b5a6cd6-c441-4c08-8ea5-514d37f516eb"), "Stephan", "Fry" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { new Guid("85ab217f-2701-4c6b-b712-8473e01c7603"), "Douglas", "Adams" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("5dabb349-e361-49c1-8bf1-5b38e7371a4b"), new Guid("b9383602-01fc-4281-8ead-c451e1be8f94"), "George RR Martin is the author", "The winds of winter" },
                    { new Guid("77c77e7d-dcad-41a4-ae79-c1933805975a"), new Guid("b9383602-01fc-4281-8ead-c451e1be8f94"), "Game of thrones description", "Game of thrones" },
                    { new Guid("794dc277-533b-4fd0-b4ea-1b3f44475242"), new Guid("0b5a6cd6-c441-4c08-8ea5-514d37f516eb"), "A book by stepahane fry", "AutoBioraphy by stephan fry" },
                    { new Guid("a7285ffa-47d4-441f-b137-8865417d2d9b"), new Guid("85ab217f-2701-4c6b-b712-8473e01c7603"), "A book by Douglas adams", "Book of fire" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
