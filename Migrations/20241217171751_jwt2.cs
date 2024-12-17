using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class jwt2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "23187fb6-72cf-4efe-8f31-519af0ec5a99", null, "User", "USER" },
                    { "c967899f-1fb9-4d54-9bfe-8d02aef7c32d", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d76aaa19-10b9-4256-b171-4312bdb29243", 0, "1e9f76e3-1188-46b7-8feb-f5bb74da881f", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEHfn7Blio4WsS6KxfrspjjM4HzD6xHRl4xAkV6lPoYnwDv0P9F8TWQsv2Vz7bjjPQQ==", null, false, "c736f05b-2789-4574-a6b8-ae3c25495045", false, "admin@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c967899f-1fb9-4d54-9bfe-8d02aef7c32d", "d76aaa19-10b9-4256-b171-4312bdb29243" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23187fb6-72cf-4efe-8f31-519af0ec5a99");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c967899f-1fb9-4d54-9bfe-8d02aef7c32d", "d76aaa19-10b9-4256-b171-4312bdb29243" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c967899f-1fb9-4d54-9bfe-8d02aef7c32d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d76aaa19-10b9-4256-b171-4312bdb29243");

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
    }
}
