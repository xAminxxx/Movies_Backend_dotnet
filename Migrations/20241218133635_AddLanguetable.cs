using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddLanguetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d849dde6-dfc2-4864-939f-786ef92f7524");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c99ef002-8f7b-4e9d-aeed-839968fe988e", "7b5718e4-3962-42ad-b840-527afbe23e0c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c99ef002-8f7b-4e9d-aeed-839968fe988e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b5718e4-3962-42ad-b840-527afbe23e0c");

            migrationBuilder.CreateTable(
                name: "Langues",
                columns: table => new
                {
                    LangueID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Langues", x => x.LangueID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Langues");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c99ef002-8f7b-4e9d-aeed-839968fe988e", null, "Admin", "ADMIN" },
                    { "d849dde6-dfc2-4864-939f-786ef92f7524", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7b5718e4-3962-42ad-b840-527afbe23e0c", 0, "93122410-9f72-48ce-917d-b951801191c5", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEHBILooqEXb9l+yIyBPT0WSUKcHw4wcLNBNZy3+vAL03tq1ejNNeznDzxadPVXLfCw==", null, false, "78271642-6ad7-4dd6-ab39-7ca9354f82e9", false, "admin@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c99ef002-8f7b-4e9d-aeed-839968fe988e", "7b5718e4-3962-42ad-b840-527afbe23e0c" });
        }
    }
}
