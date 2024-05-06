using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdoPsiak.Migrations
{
    /// <inheritdoc />
    public partial class AddAdoptionForms3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ThirdQuestion",
                table: "AdoptionForms",
                newName: "AboutResponsibility");

            migrationBuilder.RenameColumn(
                name: "SecondQuestion",
                table: "AdoptionForms",
                newName: "AboutOtherAnimals");

            migrationBuilder.RenameColumn(
                name: "FirstQuestion",
                table: "AdoptionForms",
                newName: "AboutExperienceWithAnimals");

            migrationBuilder.RenameColumn(
                name: "BuildingNumber",
                table: "AdoptionForms",
                newName: "AboutEnviroment");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AboutResponsibility",
                table: "AdoptionForms",
                newName: "ThirdQuestion");

            migrationBuilder.RenameColumn(
                name: "AboutOtherAnimals",
                table: "AdoptionForms",
                newName: "SecondQuestion");

            migrationBuilder.RenameColumn(
                name: "AboutExperienceWithAnimals",
                table: "AdoptionForms",
                newName: "FirstQuestion");

            migrationBuilder.RenameColumn(
                name: "AboutEnviroment",
                table: "AdoptionForms",
                newName: "BuildingNumber");
        }
    }
}
