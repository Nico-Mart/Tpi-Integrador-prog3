using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Albuns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Songs = table.Column<string>(type: "TEXT", nullable: false),
                    Duration = table.Column<float>(type: "REAL", nullable: false),
                    MusicianId = table.Column<int>(type: "INTEGER", nullable: false),
                    ReviewId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albuns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    UserType = table.Column<int>(type: "INTEGER", nullable: false),
                    Alias = table.Column<string>(type: "TEXT", nullable: true),
                    Musiciansquant = table.Column<int>(type: "INTEGER", nullable: true),
                    MusicianName = table.Column<string>(type: "TEXT", nullable: true),
                    Genre = table.Column<string>(type: "TEXT", nullable: true),
                    AlbunId = table.Column<int>(type: "INTEGER", nullable: true),
                    Phone = table.Column<int>(type: "INTEGER", nullable: true),
                    FavoriteGenre = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Albuns_AlbunId",
                        column: x => x.AlbunId,
                        principalTable: "Albuns",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Score = table.Column<int>(type: "INTEGER", nullable: false),
                    SubscriberId = table.Column<int>(type: "INTEGER", nullable: true),
                    AlbunId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Albuns_AlbunId",
                        column: x => x.AlbunId,
                        principalTable: "Albuns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_SubscriberId",
                        column: x => x.SubscriberId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albuns_MusicianId",
                table: "Albuns",
                column: "MusicianId");

            migrationBuilder.CreateIndex(
                name: "IX_Albuns_ReviewId",
                table: "Albuns",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_AlbunId",
                table: "Reviews",
                column: "AlbunId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_SubscriberId",
                table: "Reviews",
                column: "SubscriberId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AlbunId",
                table: "Users",
                column: "AlbunId");

            migrationBuilder.AddForeignKey(
                name: "FK_Albuns_Reviews_ReviewId",
                table: "Albuns",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Albuns_Users_MusicianId",
                table: "Albuns",
                column: "MusicianId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albuns_Reviews_ReviewId",
                table: "Albuns");

            migrationBuilder.DropForeignKey(
                name: "FK_Albuns_Users_MusicianId",
                table: "Albuns");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Albuns");
        }
    }
}
