using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class jwt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "82719e8d-1c5a-4f0d-bb79-926c4805a548", null, "User", "USER" },
                    { "b80bf124-9c9a-4292-94ad-6bce11c8ee92", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "29c01b43-9260-4a96-94fe-fb06e0687329", 0, "8be9c503-9687-48c4-a732-1e1d98b2a655", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEG/B4ztyqp4MqhBLC4mpV6tygXddvKKMwkms+79inVCiBVY2aupp7rRrBYI+5nGf4g==", null, false, "ffd3752c-bed9-47d7-ae04-f332c607e9a8", false, "admin@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b80bf124-9c9a-4292-94ad-6bce11c8ee92", "29c01b43-9260-4a96-94fe-fb06e0687329" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82719e8d-1c5a-4f0d-bb79-926c4805a548");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b80bf124-9c9a-4292-94ad-6bce11c8ee92", "29c01b43-9260-4a96-94fe-fb06e0687329" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b80bf124-9c9a-4292-94ad-6bce11c8ee92");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29c01b43-9260-4a96-94fe-fb06e0687329");

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
    }
}
