using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjeTeklas.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ogretmens",
                columns: table => new
                {
                    OgretmenId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(nullable: true),
                    Soyad = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogretmens", x => x.OgretmenId);
                });

            migrationBuilder.CreateTable(
                name: "Sinifs",
                columns: table => new
                {
                    SinifId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SinifAdi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sinifs", x => x.SinifId);
                });

            migrationBuilder.CreateTable(
                name: "Ogrencis",
                columns: table => new
                {
                    OgrenciId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(nullable: true),
                    Soyad = table.Column<string>(nullable: true),
                    DogumTarihi = table.Column<DateTime>(nullable: false),
                    SinifId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogrencis", x => x.OgrenciId);
                    table.ForeignKey(
                        name: "FK_Ogrencis_Sinifs_SinifId",
                        column: x => x.SinifId,
                        principalTable: "Sinifs",
                        principalColumn: "SinifId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OgretmenSinifs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SinifId = table.Column<int>(nullable: false),
                    OgretmenId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OgretmenSinifs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OgretmenSinifs_Ogretmens_OgretmenId",
                        column: x => x.OgretmenId,
                        principalTable: "Ogretmens",
                        principalColumn: "OgretmenId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OgretmenSinifs_Sinifs_SinifId",
                        column: x => x.SinifId,
                        principalTable: "Sinifs",
                        principalColumn: "SinifId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ogrencis_SinifId",
                table: "Ogrencis",
                column: "SinifId");

            migrationBuilder.CreateIndex(
                name: "IX_OgretmenSinifs_OgretmenId",
                table: "OgretmenSinifs",
                column: "OgretmenId");

            migrationBuilder.CreateIndex(
                name: "IX_OgretmenSinifs_SinifId",
                table: "OgretmenSinifs",
                column: "SinifId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ogrencis");

            migrationBuilder.DropTable(
                name: "OgretmenSinifs");

            migrationBuilder.DropTable(
                name: "Ogretmens");

            migrationBuilder.DropTable(
                name: "Sinifs");
        }
    }
}
