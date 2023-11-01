using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nosted_dotnet.MVC.Migrations
{
    /// <inheritdoc />
    public partial class missingSjekkliste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Resultat",
                table: "Sjekkliste",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Resultat",
                table: "Sjekkliste");
        }
    }
}
