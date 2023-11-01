using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nosted_dotnet.MVC.Migrations
{
    /// <inheritdoc />
    public partial class sjekkNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Wire",
                table: "Sjekkliste",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<float>(
                name: "TrykkSetting",
                table: "Sjekkliste",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "TrommelLager",
                table: "Sjekkliste",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<float>(
                name: "TrekKraft",
                table: "Sjekkliste",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "SylinderLekasje",
                table: "Sjekkliste",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Slanger",
                table: "Sjekkliste",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "RingsylinderTetninger",
                table: "Sjekkliste",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Radio",
                table: "Sjekkliste",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "PinionLager",
                table: "Sjekkliste",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "OljeskifteTank",
                table: "Sjekkliste",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "OljeskifteGirboks",
                table: "Sjekkliste",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Ledningsnett",
                table: "Sjekkliste",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Knappekasse",
                table: "Sjekkliste",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Kjedestrammer",
                table: "Sjekkliste",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "KjedehjulKile",
                table: "Sjekkliste",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "HydraulikkblokkTest",
                table: "Sjekkliste",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "FunksjonsTestKommentar",
                table: "Sjekkliste",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "ClutchLameller",
                table: "Sjekkliste",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "BremsesylinderTetninger",
                table: "Sjekkliste",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "BremserBP",
                table: "Sjekkliste",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<float>(
                name: "BremseKraft",
                table: "Sjekkliste",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "float");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sjekkliste",
                keyColumn: "Wire",
                keyValue: null,
                column: "Wire",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Wire",
                table: "Sjekkliste",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<float>(
                name: "TrykkSetting",
                table: "Sjekkliste",
                type: "float",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Sjekkliste",
                keyColumn: "TrommelLager",
                keyValue: null,
                column: "TrommelLager",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "TrommelLager",
                table: "Sjekkliste",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<float>(
                name: "TrekKraft",
                table: "Sjekkliste",
                type: "float",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Sjekkliste",
                keyColumn: "SylinderLekasje",
                keyValue: null,
                column: "SylinderLekasje",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "SylinderLekasje",
                table: "Sjekkliste",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Sjekkliste",
                keyColumn: "Slanger",
                keyValue: null,
                column: "Slanger",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Slanger",
                table: "Sjekkliste",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Sjekkliste",
                keyColumn: "RingsylinderTetninger",
                keyValue: null,
                column: "RingsylinderTetninger",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "RingsylinderTetninger",
                table: "Sjekkliste",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Sjekkliste",
                keyColumn: "Radio",
                keyValue: null,
                column: "Radio",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Radio",
                table: "Sjekkliste",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Sjekkliste",
                keyColumn: "PinionLager",
                keyValue: null,
                column: "PinionLager",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "PinionLager",
                table: "Sjekkliste",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Sjekkliste",
                keyColumn: "OljeskifteTank",
                keyValue: null,
                column: "OljeskifteTank",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "OljeskifteTank",
                table: "Sjekkliste",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Sjekkliste",
                keyColumn: "OljeskifteGirboks",
                keyValue: null,
                column: "OljeskifteGirboks",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "OljeskifteGirboks",
                table: "Sjekkliste",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Sjekkliste",
                keyColumn: "Ledningsnett",
                keyValue: null,
                column: "Ledningsnett",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Ledningsnett",
                table: "Sjekkliste",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Sjekkliste",
                keyColumn: "Knappekasse",
                keyValue: null,
                column: "Knappekasse",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Knappekasse",
                table: "Sjekkliste",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Sjekkliste",
                keyColumn: "Kjedestrammer",
                keyValue: null,
                column: "Kjedestrammer",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Kjedestrammer",
                table: "Sjekkliste",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Sjekkliste",
                keyColumn: "KjedehjulKile",
                keyValue: null,
                column: "KjedehjulKile",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "KjedehjulKile",
                table: "Sjekkliste",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Sjekkliste",
                keyColumn: "HydraulikkblokkTest",
                keyValue: null,
                column: "HydraulikkblokkTest",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "HydraulikkblokkTest",
                table: "Sjekkliste",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Sjekkliste",
                keyColumn: "FunksjonsTestKommentar",
                keyValue: null,
                column: "FunksjonsTestKommentar",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "FunksjonsTestKommentar",
                table: "Sjekkliste",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Sjekkliste",
                keyColumn: "ClutchLameller",
                keyValue: null,
                column: "ClutchLameller",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "ClutchLameller",
                table: "Sjekkliste",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Sjekkliste",
                keyColumn: "BremsesylinderTetninger",
                keyValue: null,
                column: "BremsesylinderTetninger",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "BremsesylinderTetninger",
                table: "Sjekkliste",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Sjekkliste",
                keyColumn: "BremserBP",
                keyValue: null,
                column: "BremserBP",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "BremserBP",
                table: "Sjekkliste",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<float>(
                name: "BremseKraft",
                table: "Sjekkliste",
                type: "float",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "float",
                oldNullable: true);
        }
    }
}
