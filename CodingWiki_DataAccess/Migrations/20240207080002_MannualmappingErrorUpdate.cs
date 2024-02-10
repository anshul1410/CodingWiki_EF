using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MannualmappingErrorUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorBookAuthorMap");

            migrationBuilder.DropTable(
                name: "BookBookAuthorMap");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthorMap_Author_Id",
                table: "BookAuthorMap",
                column: "Author_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthorMap_Authors_Author_Id",
                table: "BookAuthorMap",
                column: "Author_Id",
                principalTable: "Authors",
                principalColumn: "Author_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthorMap_Books_Book_Id",
                table: "BookAuthorMap",
                column: "Book_Id",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthorMap_Authors_Author_Id",
                table: "BookAuthorMap");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthorMap_Books_Book_Id",
                table: "BookAuthorMap");

            migrationBuilder.DropIndex(
                name: "IX_BookAuthorMap_Author_Id",
                table: "BookAuthorMap");

            migrationBuilder.CreateTable(
                name: "AuthorBookAuthorMap",
                columns: table => new
                {
                    Author_Id = table.Column<int>(type: "int", nullable: false),
                    BookAuthorMapBook_Id = table.Column<int>(type: "int", nullable: false),
                    BookAuthorMapAuthor_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBookAuthorMap", x => new { x.Author_Id, x.BookAuthorMapBook_Id, x.BookAuthorMapAuthor_Id });
                    table.ForeignKey(
                        name: "FK_AuthorBookAuthorMap_Authors_Author_Id",
                        column: x => x.Author_Id,
                        principalTable: "Authors",
                        principalColumn: "Author_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBookAuthorMap_BookAuthorMap_BookAuthorMapBook_Id_BookAuthorMapAuthor_Id",
                        columns: x => new { x.BookAuthorMapBook_Id, x.BookAuthorMapAuthor_Id },
                        principalTable: "BookAuthorMap",
                        principalColumns: new[] { "Book_Id", "Author_Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookBookAuthorMap",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    BookAuthorMapBook_Id = table.Column<int>(type: "int", nullable: false),
                    BookAuthorMapAuthor_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBookAuthorMap", x => new { x.BookId, x.BookAuthorMapBook_Id, x.BookAuthorMapAuthor_Id });
                    table.ForeignKey(
                        name: "FK_BookBookAuthorMap_BookAuthorMap_BookAuthorMapBook_Id_BookAuthorMapAuthor_Id",
                        columns: x => new { x.BookAuthorMapBook_Id, x.BookAuthorMapAuthor_Id },
                        principalTable: "BookAuthorMap",
                        principalColumns: new[] { "Book_Id", "Author_Id" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookBookAuthorMap_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBookAuthorMap_BookAuthorMapBook_Id_BookAuthorMapAuthor_Id",
                table: "AuthorBookAuthorMap",
                columns: new[] { "BookAuthorMapBook_Id", "BookAuthorMapAuthor_Id" });

            migrationBuilder.CreateIndex(
                name: "IX_BookBookAuthorMap_BookAuthorMapBook_Id_BookAuthorMapAuthor_Id",
                table: "BookBookAuthorMap",
                columns: new[] { "BookAuthorMapBook_Id", "BookAuthorMapAuthor_Id" });
        }
    }
}
