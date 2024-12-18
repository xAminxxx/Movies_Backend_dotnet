using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class Fixdatecreated3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a430a1d4-1421-4fff-ba18-655f532f7f0a");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "62418968-25df-447a-bafd-a7999cdd3890", "c912d275-77e1-4501-ade8-41178a920e62" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62418968-25df-447a-bafd-a7999cdd3890");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c912d275-77e1-4501-ade8-41178a920e62");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Films",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Films",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "Description",
                table: "Films",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "DateCreated",
                table: "Films",
                type: "int",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "62418968-25df-447a-bafd-a7999cdd3890", null, "Admin", "ADMIN" },
                    { "a430a1d4-1421-4fff-ba18-655f532f7f0a", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c912d275-77e1-4501-ade8-41178a920e62", 0, "be824f1a-9277-4567-8760-0d4b3c13cfcc", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEPoD9FsXKJ8nvz4iZ/zgWVYHJCo+LI3yy/nk5ZJ/r7kM+E0KE769zmtcz8IXCqt2TQ==", null, false, "d8d3d443-cbe1-4ff1-81dc-b78c71865f90", false, "admin@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "62418968-25df-447a-bafd-a7999cdd3890", "c912d275-77e1-4501-ade8-41178a920e62" });
        }
    }
}
