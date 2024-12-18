using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class finale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84192de3-204a-4734-95c2-201276c18c27");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fa0c3855-5ee2-4096-97cd-95fca6b02ade", "c656df5d-dcdb-47ba-9ecb-63b03bfdee59" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa0c3855-5ee2-4096-97cd-95fca6b02ade");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c656df5d-dcdb-47ba-9ecb-63b03bfdee59");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0bd6dbbf-afcb-4018-9f98-25ca1cf2e138", null, "Admin", "ADMIN" },
                    { "984db43b-7e42-4965-bc88-8538cbe3733e", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "85252d1c-60f7-4ded-bc0b-98e345c021dd", 0, "72338661-38f5-412c-85e8-40300575667f", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEK2zpoabQbTWGivGO8gE3zD8DxH2HN7/sGnMjpYgAuIao3GGW5Xt6rMfctE1t8FUJw==", null, false, "b8e2f87a-20cf-4886-8490-dda1ae8a75dc", false, "admin@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0bd6dbbf-afcb-4018-9f98-25ca1cf2e138", "85252d1c-60f7-4ded-bc0b-98e345c021dd" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "984db43b-7e42-4965-bc88-8538cbe3733e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0bd6dbbf-afcb-4018-9f98-25ca1cf2e138", "85252d1c-60f7-4ded-bc0b-98e345c021dd" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0bd6dbbf-afcb-4018-9f98-25ca1cf2e138");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85252d1c-60f7-4ded-bc0b-98e345c021dd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "84192de3-204a-4734-95c2-201276c18c27", null, "User", "USER" },
                    { "fa0c3855-5ee2-4096-97cd-95fca6b02ade", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c656df5d-dcdb-47ba-9ecb-63b03bfdee59", 0, "9035d2b1-5613-4509-a729-b0cf199287c7", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEPrD36ZCNiABf0k51r47VF4T9BdGaSG0kaAbf9f/AwjA+UdbVSGTnCmE4ZRF9DJsaw==", null, false, "a4e1b66d-4822-40fe-baed-39b422ce65d4", false, "admin@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fa0c3855-5ee2-4096-97cd-95fca6b02ade", "c656df5d-dcdb-47ba-9ecb-63b03bfdee59" });
        }
    }
}
