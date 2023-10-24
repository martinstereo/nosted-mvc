using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nosted_dotnet.MVC.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Navn = table.Column<string>(type: "TEXT", nullable: true),
                    Etternavn = table.Column<string>(type: "TEXT", nullable: true),
                    Adresse = table.Column<string>(type: "TEXT", nullable: true),
                    Telefonnummer = table.Column<string>(type: "TEXT", nullable: true),
                    Stilling = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateReceived = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ProductType = table.Column<string>(type: "TEXT", nullable: true),
                    TargetDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDone = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Kunde = table.Column<string>(type: "TEXT", nullable: false),
                    Serienummer = table.Column<string>(type: "TEXT", nullable: false),
                    MotattDato = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AvtaltMedKunden = table.Column<string>(type: "TEXT", nullable: false),
                    KundeMail = table.Column<string>(type: "TEXT", nullable: false),
                    KundeAdresse = table.Column<string>(type: "TEXT", nullable: false),
                    KundeTelefonNr = table.Column<string>(type: "TEXT", nullable: false),
                    Produkttype = table.Column<string>(type: "TEXT", nullable: false),
                    Årsmodell = table.Column<string>(type: "TEXT", nullable: false),
                    ServiceRep = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerInformations_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerInformations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceSchemas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RepBeskrivelse = table.Column<string>(type: "TEXT", nullable: false),
                    MedgåtteDeler = table.Column<string>(type: "TEXT", nullable: false),
                    FerdigDato = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UtskiftetDelerRetur = table.Column<string>(type: "TEXT", nullable: false),
                    ForsendelsesMåte = table.Column<string>(type: "TEXT", nullable: false),
                    SignaturRep = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceSchemas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceSchemas_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceSchemas_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CheckLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CheckListId = table.Column<int>(type: "INTEGER", nullable: false),
                    Mechanic = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ConsumedHours = table.Column<decimal>(type: "TEXT", nullable: false),
                    MechanicComment = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerName = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerEmail = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerStreet = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerCity = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerZipcode = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerTelephoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerComment = table.Column<string>(type: "TEXT", nullable: false),
                    VinsjType = table.Column<string>(type: "TEXT", nullable: false),
                    VinsjModel = table.Column<string>(type: "TEXT", nullable: false),
                    VinsjRegNr = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    ServiceSchemaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckLists_ServiceSchemas_ServiceSchemaId",
                        column: x => x.ServiceSchemaId,
                        principalTable: "ServiceSchemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckLists_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChecklistCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GroupName = table.Column<string>(type: "TEXT", nullable: false),
                    CheckListId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CategoryType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChecklistCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChecklistCategories_CheckLists_CheckListId",
                        column: x => x.CheckListId,
                        principalTable: "CheckLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistCategories_CheckListId",
                table: "ChecklistCategories",
                column: "CheckListId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckLists_ServiceSchemaId",
                table: "CheckLists",
                column: "ServiceSchemaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CheckLists_UserId",
                table: "CheckLists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInformations_OrderId",
                table: "CustomerInformations",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInformations_UserId",
                table: "CustomerInformations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceSchemas_OrderId",
                table: "ServiceSchemas",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceSchemas_UserId",
                table: "ServiceSchemas",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChecklistCategories");

            migrationBuilder.DropTable(
                name: "CustomerInformations");

            migrationBuilder.DropTable(
                name: "CheckLists");

            migrationBuilder.DropTable(
                name: "ServiceSchemas");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
