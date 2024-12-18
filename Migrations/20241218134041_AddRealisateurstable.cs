using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddRealisateurstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc67d067-9560-41e3-a7b7-116fb4c56a8d");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "42b072c5-c770-42fb-bd54-a185f00192f0", "de8322a4-7975-4ed4-9132-4d51377ee046" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42b072c5-c770-42fb-bd54-a185f00192f0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "de8322a4-7975-4ed4-9132-4d51377ee046");

            migrationBuilder.CreateTable(
                name: "Realisateurs",
                columns: table => new
                {
                    RealisateursID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Prenom = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Realisateurs", x => x.RealisateursID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "39efc4a5-d81e-4f69-84c6-b3e7384fc218", null, "User", "USER" },
                    { "ee18b892-cfe1-42bd-a35a-22d36fa0f69b", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9c715742-e0d1-4780-a58a-e652ed16e093", 0, "7443670a-a146-47ae-9acb-ceb6cbb9a7f4", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAED0K6kzO9zapnye6wSNMUUnndB0MmHpskKsGZOkzlgYwQApDmoZ9QUbFgBxxFXFsPg==", null, false, "886c20ba-0f05-4889-8250-920d31b94ca6", false, "admin@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ee18b892-cfe1-42bd-a35a-22d36fa0f69b", "9c715742-e0d1-4780-a58a-e652ed16e093" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Realisateurs");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39efc4a5-d81e-4f69-84c6-b3e7384fc218");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ee18b892-cfe1-42bd-a35a-22d36fa0f69b", "9c715742-e0d1-4780-a58a-e652ed16e093" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee18b892-cfe1-42bd-a35a-22d36fa0f69b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c715742-e0d1-4780-a58a-e652ed16e093");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "42b072c5-c770-42fb-bd54-a185f00192f0", null, "Admin", "ADMIN" },
                    { "bc67d067-9560-41e3-a7b7-116fb4c56a8d", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "de8322a4-7975-4ed4-9132-4d51377ee046", 0, "da099c37-bab8-4682-9b06-42669eefca3c", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEFhg4IvJH6up2lLaLwYxJVRsFNiAkmqBM7lkt6EHbdBZ+641qgI2k1ppEwviLir9NA==", null, false, "e3f28283-3772-46bb-8dc0-fe60e1642e90", false, "admin@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "42b072c5-c770-42fb-bd54-a185f00192f0", "de8322a4-7975-4ed4-9132-4d51377ee046" });
        }
    }
}
