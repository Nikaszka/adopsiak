using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdoPsiak.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SuperHeroes",
                table: "SuperHeroes");

            migrationBuilder.RenameTable(
                name: "SuperHeroes",
                newName: "Superbohaterowie");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Superbohaterowie",
                table: "Superbohaterowie",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Superbohaterowie",
                table: "Superbohaterowie");

            migrationBuilder.RenameTable(
                name: "Superbohaterowie",
                newName: "SuperHeroes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SuperHeroes",
                table: "SuperHeroes",
                column: "Id");
        }
    }
}
