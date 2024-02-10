using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class add_Fluent_OneToOneRelation_Book_BookDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Book_Id",
                table: "Fluent_Bookdetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_Bookdetails_Book_Id",
                table: "Fluent_Bookdetails",
                column: "Book_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_Bookdetails_Fluent_Books_Book_Id",
                table: "Fluent_Bookdetails",
                column: "Book_Id",
                principalTable: "Fluent_Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_Bookdetails_Fluent_Books_Book_Id",
                table: "Fluent_Bookdetails");

            migrationBuilder.DropIndex(
                name: "IX_Fluent_Bookdetails_Book_Id",
                table: "Fluent_Bookdetails");

            migrationBuilder.DropColumn(
                name: "Book_Id",
                table: "Fluent_Bookdetails");
        }
    }
}
