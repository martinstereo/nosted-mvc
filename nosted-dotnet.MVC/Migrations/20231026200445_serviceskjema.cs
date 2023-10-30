using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nosted_dotnet.MVC.Migrations
{
    /// <inheritdoc />
    public partial class serviceskjema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrdreId",
                table: "ServiceSkjema",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceSkjema_OrdreId",
                table: "ServiceSkjema",
                column: "OrdreId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceSkjema_Ordre_OrdreId",
                table: "ServiceSkjema",
                column: "OrdreId",
                principalTable: "Ordre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceSkjema_Ordre_OrdreId",
                table: "ServiceSkjema");

            migrationBuilder.DropIndex(
                name: "IX_ServiceSkjema_OrdreId",
                table: "ServiceSkjema");

            migrationBuilder.DropColumn(
                name: "OrdreId",
                table: "ServiceSkjema");
        }
    }
}
