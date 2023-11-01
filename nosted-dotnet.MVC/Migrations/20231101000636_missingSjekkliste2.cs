using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nosted_dotnet.MVC.Migrations
{
    /// <inheritdoc />
    public partial class missingSjekkliste2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FunksjonsTestKommentar",
                table: "Sjekkliste");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FunksjonsTestKommentar",
                table: "Sjekkliste",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
