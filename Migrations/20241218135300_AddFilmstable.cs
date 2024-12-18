using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddFilmstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    FilmID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateCreated = table.Column<int>(type: "int", nullable: false),
                    Duree = table.Column<int>(type: "int", nullable: false),
                    Poster = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CategorieID = table.Column<int>(type: "int", nullable: false),
                    ActeurPID = table.Column<int>(type: "int", nullable: false),
                    EditeurID = table.Column<int>(type: "int", nullable: false),
                    LangueID = table.Column<int>(type: "int", nullable: false),
                    RealisateurID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.FilmID);
                    table.ForeignKey(
                        name: "FK_Films_Acteurs_ActeurPID",
                        column: x => x.ActeurPID,
                        principalTable: "Acteurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Films_Categories_CategorieID",
                        column: x => x.CategorieID,
                        principalTable: "Categories",
                        principalColumn: "CategorieID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Films_Editeurs_EditeurID",
                        column: x => x.EditeurID,
                        principalTable: "Editeurs",
                        principalColumn: "EditeurID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Films_Langues_LangueID",
                        column: x => x.LangueID,
                        principalTable: "Langues",
                        principalColumn: "LangueID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Films_Realisateurs_RealisateurID",
                        column: x => x.RealisateurID,
                        principalTable: "Realisateurs",
                        principalColumn: "RealisateursID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.CreateIndex(
                name: "IX_Films_ActeurPID",
                table: "Films",
                column: "ActeurPID");

            migrationBuilder.CreateIndex(
                name: "IX_Films_CategorieID",
                table: "Films",
                column: "CategorieID");

            migrationBuilder.CreateIndex(
                name: "IX_Films_EditeurID",
                table: "Films",
                column: "EditeurID");

            migrationBuilder.CreateIndex(
                name: "IX_Films_LangueID",
                table: "Films",
                column: "LangueID");

            migrationBuilder.CreateIndex(
                name: "IX_Films_RealisateurID",
                table: "Films",
                column: "RealisateurID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Films");

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
    }
}
