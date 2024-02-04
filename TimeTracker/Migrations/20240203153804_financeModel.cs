using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeTracker.Migrations
{
    /// <inheritdoc />
    public partial class financeModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Finances_AspNetUsers_AuthorId",
                table: "Finances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Finances",
                table: "Finances");

            migrationBuilder.RenameTable(
                name: "Finances",
                newName: "Finance");

            migrationBuilder.RenameIndex(
                name: "IX_Finances_AuthorId",
                table: "Finance",
                newName: "IX_Finance_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Finance",
                table: "Finance",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Finance_AspNetUsers_AuthorId",
                table: "Finance",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Finance_AspNetUsers_AuthorId",
                table: "Finance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Finance",
                table: "Finance");

            migrationBuilder.RenameTable(
                name: "Finance",
                newName: "Finances");

            migrationBuilder.RenameIndex(
                name: "IX_Finance_AuthorId",
                table: "Finances",
                newName: "IX_Finances_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Finances",
                table: "Finances",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Finances_AspNetUsers_AuthorId",
                table: "Finances",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
