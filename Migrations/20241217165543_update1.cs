using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "5d4a3604-ac26-4114-8f91-7802a8c604df", null, "Admin", "ADMIN" },
                    { "a208ec67-d4b9-4b62-92ac-6b93ce0ac4e3", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f8beaf97-09c5-4411-8287-6baf2f08757e", 0, "79c29ace-2820-462e-9f8c-3b09232eecba", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEJZsUsgnWkQ0RYTz7YobW+4Sf2o+YAs27OiBqV9jDrvKHcuTb6Yzxqj3RghgLvVObg==", null, false, "5c1819da-30be-4c9f-97d8-3c4df89ed3c0", false, "admin@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5d4a3604-ac26-4114-8f91-7802a8c604df", "f8beaf97-09c5-4411-8287-6baf2f08757e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a208ec67-d4b9-4b62-92ac-6b93ce0ac4e3");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5d4a3604-ac26-4114-8f91-7802a8c604df", "f8beaf97-09c5-4411-8287-6baf2f08757e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d4a3604-ac26-4114-8f91-7802a8c604df");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f8beaf97-09c5-4411-8287-6baf2f08757e");

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
    }
}
