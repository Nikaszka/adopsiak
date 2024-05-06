using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdoPsiak.Migrations
{
    /// <inheritdoc />
    public partial class AddPhotoAndForms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Superbohaterowie");

            migrationBuilder.AddColumn<Guid>(
                name: "AnimalPhotoId",
                table: "Animals",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CatFriendly",
                table: "Animals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ChildFriendly",
                table: "Animals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DoesntLikeShelter",
                table: "Animals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DogFriendly",
                table: "Animals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LikesToCuddle",
                table: "Animals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LikesToPlay",
                table: "Animals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Animals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FormStatus",
                table: "AdoptionForms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AnimalPhotos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalPhotos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactForms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageStatus = table.Column<int>(type: "int", nullable: false),
                    SendingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactForms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MonetarySupportEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<decimal>(type: "decimal(16,2)", precision: 16, scale: 2, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonetarySupportEntries", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_AnimalPhotoId",
                table: "Animals",
                column: "AnimalPhotoId",
                unique: true,
                filter: "[AnimalPhotoId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_AnimalPhotos_AnimalPhotoId",
                table: "Animals",
                column: "AnimalPhotoId",
                principalTable: "AnimalPhotos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_AnimalPhotos_AnimalPhotoId",
                table: "Animals");

            migrationBuilder.DropTable(
                name: "AnimalPhotos");

            migrationBuilder.DropTable(
                name: "ContactForms");

            migrationBuilder.DropTable(
                name: "MonetarySupportEntries");

            migrationBuilder.DropIndex(
                name: "IX_Animals_AnimalPhotoId",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "AnimalPhotoId",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "CatFriendly",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "ChildFriendly",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "DoesntLikeShelter",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "DogFriendly",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "LikesToCuddle",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "LikesToPlay",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "FormStatus",
                table: "AdoptionForms");

            migrationBuilder.CreateTable(
                name: "Superbohaterowie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Superbohaterowie", x => x.Id);
                });
        }
    }
}
