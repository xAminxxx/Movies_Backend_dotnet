using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc80c3f6-e2b1-40cf-9346-32c28e6e6ab6");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ee9a6db6-7b8c-40bc-b6d2-b32a90ed26ca", "afb41fd9-9ae4-4a51-9b48-a197beb2df07" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee9a6db6-7b8c-40bc-b6d2-b32a90ed26ca");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "afb41fd9-9ae4-4a51-9b48-a197beb2df07");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3f13365a-a51d-4b10-8bd0-2fa0319fbd85", null, "User", "USER" },
                    { "60ed98fa-177e-4254-89d3-0fce37a1e976", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ce15c64e-3e88-4b34-876d-5e8784c40af9", 0, "e7a24f86-b948-45cb-ab16-d1fa895fb6ea", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAENbCsHRcjHClJNd0JRLGvRi3jLqWCqTpdLtGYa3vQaR3tI4KzR9yRDaCuh+wru1Vfw==", null, false, "1c29bf2c-cd79-4ded-9d6a-25f5f9a87983", false, "admin@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "60ed98fa-177e-4254-89d3-0fce37a1e976", "ce15c64e-3e88-4b34-876d-5e8784c40af9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f13365a-a51d-4b10-8bd0-2fa0319fbd85");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "60ed98fa-177e-4254-89d3-0fce37a1e976", "ce15c64e-3e88-4b34-876d-5e8784c40af9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60ed98fa-177e-4254-89d3-0fce37a1e976");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce15c64e-3e88-4b34-876d-5e8784c40af9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ee9a6db6-7b8c-40bc-b6d2-b32a90ed26ca", null, "Admin", "ADMIN" },
                    { "fc80c3f6-e2b1-40cf-9346-32c28e6e6ab6", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "afb41fd9-9ae4-4a51-9b48-a197beb2df07", 0, "9095735c-db22-47bc-b58e-7f43b8142102", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEBoaQH1av+r+Kxq/S9pHX3VQwlWjLsOweQHVq6i18xu+pqj1lou0a4qErMmbWlWEOw==", null, false, "484a60f0-a4b3-4d68-9f43-468a1fe88511", false, "admin@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ee9a6db6-7b8c-40bc-b6d2-b32a90ed26ca", "afb41fd9-9ae4-4a51-9b48-a197beb2df07" });
        }
    }
}
