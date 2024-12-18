using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class Fixdatecreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b33faa0-d536-49da-8475-ce4d3323f0d6");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c9c1e2fc-c5d4-4b9e-add0-8c8a3dbae744", "adbf206f-e738-4b91-b54a-91f025aca194" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9c1e2fc-c5d4-4b9e-add0-8c8a3dbae744");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adbf206f-e738-4b91-b54a-91f025aca194");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Description",
                table: "Films",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8c19c8d7-9410-4973-b56b-363dc83bc213", null, "Admin", "ADMIN" },
                    { "d4cdb6cf-6b71-4726-b6de-fbc4bd10482e", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9268fe35-6621-4b24-81aa-352681ebf221", 0, "f0cb8516-164c-4a9d-b3b9-89ea49cee04d", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEPdy4z3ITNfgrT0LGtsQ5hdhWgfyldOHaKpKW8mteqYIZhLPpQ+H6aHPTEUyzMdO9g==", null, false, "d7f8062b-5a9d-4d44-8fd0-11e790d34aaa", false, "admin@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8c19c8d7-9410-4973-b56b-363dc83bc213", "9268fe35-6621-4b24-81aa-352681ebf221" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4cdb6cf-6b71-4726-b6de-fbc4bd10482e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8c19c8d7-9410-4973-b56b-363dc83bc213", "9268fe35-6621-4b24-81aa-352681ebf221" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c19c8d7-9410-4973-b56b-363dc83bc213");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9268fe35-6621-4b24-81aa-352681ebf221");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Films",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1b33faa0-d536-49da-8475-ce4d3323f0d6", null, "User", "USER" },
                    { "c9c1e2fc-c5d4-4b9e-add0-8c8a3dbae744", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "adbf206f-e738-4b91-b54a-91f025aca194", 0, "10269fa9-cc6d-44d1-82cb-4038533afc17", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEF9DsYthvYL1kd6KC/SUdp4t/hZ3/RGuh2zJ2wTvfZymnCDhxxBzkt8sPM1DFH/lWg==", null, false, "ae854f45-5426-466d-b502-2118c4ae18fc", false, "admin@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c9c1e2fc-c5d4-4b9e-add0-8c8a3dbae744", "adbf206f-e738-4b91-b54a-91f025aca194" });
        }
    }
}
