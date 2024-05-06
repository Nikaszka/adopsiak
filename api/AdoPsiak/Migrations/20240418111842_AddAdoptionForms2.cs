using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdoPsiak.Migrations
{
    /// <inheritdoc />
    public partial class AddAdoptionForms2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmailAdress",
                table: "AdoptionForms",
                newName: "EmailAddress");

            migrationBuilder.RenameColumn(
                name: "ApartamentNumber",
                table: "AdoptionForms",
                newName: "ApartmentNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "AdoptionForms",
                newName: "EmailAdress");

            migrationBuilder.RenameColumn(
                name: "ApartmentNumber",
                table: "AdoptionForms",
                newName: "ApartamentNumber");
        }
    }
}
