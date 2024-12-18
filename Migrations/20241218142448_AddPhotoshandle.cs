using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddPhotoshandle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0922dc51-02a2-4393-8785-8b06c2af9621");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f2c2f553-0810-4a5a-b753-809b2d2710c3", "10ae7d62-0bd6-4e29-bf03-4e5b75643093" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2c2f553-0810-4a5a-b753-809b2d2710c3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10ae7d62-0bd6-4e29-bf03-4e5b75643093");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0922dc51-02a2-4393-8785-8b06c2af9621", null, "User", "USER" },
                    { "f2c2f553-0810-4a5a-b753-809b2d2710c3", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "10ae7d62-0bd6-4e29-bf03-4e5b75643093", 0, "631be6d2-a081-4db4-8266-b2172ee25b53", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEMzETGoadWmtKAiiaVrLZWk3vZpcetfLkSZI5hNqbJ/uYZltKM3YzKaLEmii2DpGOg==", null, false, "4acf87f6-5dd6-4557-8496-93403437555a", false, "admin@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f2c2f553-0810-4a5a-b753-809b2d2710c3", "10ae7d62-0bd6-4e29-bf03-4e5b75643093" });
        }
    }
}
