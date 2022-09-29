using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulkyBook.WebUI.Migrations
{
    public partial class Add_Book : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Writer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Name", "Price", "Publisher", "SubCategoryId", "Writer" },
                values: new object[,]
                {
                    { 1, "Üç Kız Kardeş", 23.40m, "İş Bankası Kültür Yayınları", 1, "Anton Pavloviç Çehov" },
                    { 2, "Bir Çöküşün Öyküsü", 16.20m, "İş Bankası Kültür Yayınları", 2, "Stefan Zweig" },
                    { 3, "Esen TYT Matematik Orta İleri Düzey Soru Bankası", 45.90m, "Esen Yayınları", 3, "Nevzat Asma, Halit Bıyık" },
                    { 4, "2022 DGS 6 Muhteşem Fasikül Fasikül Deneme", 53.40m, "Tasarı Eğitim Yayınları", 4, "Özgen Bulut" }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2022, 9, 29, 15, 9, 0, 368, DateTimeKind.Local).AddTicks(8015));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2022, 9, 29, 15, 9, 0, 368, DateTimeKind.Local).AddTicks(8027));

            migrationBuilder.CreateIndex(
                name: "IX_Books_SubCategoryId",
                table: "Books",
                column: "SubCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2022, 9, 29, 9, 56, 14, 328, DateTimeKind.Local).AddTicks(7323));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2022, 9, 29, 9, 56, 14, 328, DateTimeKind.Local).AddTicks(7335));
        }
    }
}
