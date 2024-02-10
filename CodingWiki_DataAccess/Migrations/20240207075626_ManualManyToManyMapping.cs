using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ManualManyToManyMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorBook");

            migrationBuilder.CreateTable(
                name: "BookAuthorMap",
                columns: table => new
                {
                    Book_Id = table.Column<int>(type: "int", nullable: false),
                    Author_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthorMap", x => new { x.Book_Id, x.Author_Id });
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorBookAuthorMap");

            migrationBuilder.DropTable(
                name: "BookBookAuthorMap");

            migrationBuilder.DropTable(
                name: "BookAuthorMap");

            migrationBuilder.CreateTable(
                name: "AuthorBook",
                columns: table => new
                {
                    AuthorsAuthor_Id = table.Column<int>(type: "int", nullable: false),
                    BooksBookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBook", x => new { x.AuthorsAuthor_Id, x.BooksBookId });
                    table.ForeignKey(
                        name: "FK_AuthorBook_Authors_AuthorsAuthor_Id",
                        column: x => x.AuthorsAuthor_Id,
                        principalTable: "Authors",
                        principalColumn: "Author_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBook_Books_BooksBookId",
                        column: x => x.BooksBookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBook_BooksBookId",
                table: "AuthorBook",
                column: "BooksBookId");
        }
    }
}
