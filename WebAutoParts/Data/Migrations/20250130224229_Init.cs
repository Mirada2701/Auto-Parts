using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Contact = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpareParts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    ProducerId = table.Column<int>(type: "integer", nullable: false),
                    ProviderId = table.Column<int>(type: "integer", nullable: false),
                    PartNumber = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpareParts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpareParts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpareParts_Producers_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "Producers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpareParts_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Двигун і його компоненти" },
                    { 2, "Гальмівна система" },
                    { 3, "Електрообладнання та запалювання" },
                    { 4, "Ходова частина (підвіска, рульове управління)" },
                    { 5, "Трансмісія та привід" },
                    { 6, "Система охолодження" },
                    { 7, "Вихлопна система" },
                    { 8, "Паливна система" },
                    { 9, "Кузовні деталі" },
                    { 10, "Оптика та освітлення" },
                    { 11, "Колеса та шини" },
                    { 12, "Автоелектроніка та мультимедіа" },
                    { 13, "Інтер’єр та аксесуари" },
                    { 14, "Рідини та витратні матеріали" }
                });

            migrationBuilder.InsertData(
                table: "Producers",
                columns: new[] { "Id", "Country", "Name" },
                values: new object[,]
                {
                    { 1, "Німеччина", "Bosch" },
                    { 2, "Німеччина", "Continental" },
                    { 3, "США", "Delphi" },
                    { 4, "Японія", "Denso" },
                    { 5, "Франція", "Valeo" },
                    { 6, "Японія", "NGK" },
                    { 7, "Німеччина", "Sachs" },
                    { 8, "Німеччина", "Bilstein" }
                });

            migrationBuilder.InsertData(
                table: "Providers",
                columns: new[] { "Id", "Contact", "Name" },
                values: new object[,]
                {
                    { 1, "info@autotrade.ua", "AutoTrade" },
                    { 2, "sales@partsexpress.pl", "PartsExpress" },
                    { 3, "support@europarts.de", "EuroParts" },
                    { 4, "contact@globalauto.com", "GlobalAuto" }
                });

            migrationBuilder.InsertData(
                table: "SpareParts",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "PartNumber", "Price", "ProducerId", "ProviderId", "Quantity" },
                values: new object[,]
                {
                    { 1, 2, "Високоякісні гальмівні колодки Bosch для надійного гальмування.", "https://content.rozetka.com.ua/goods/images/big/498080167.jpg", "Дискові гальмівні колодки Bosch", "8570259", 1200.5f, 1, 1, 50 },
                    { 2, 3, "Свічки запалювання преміум-класу від NGK для покращення ефективності двигуна.", "https://content1.rozetka.com.ua/goods/images/big/347984637.jpg", "Свічки запалювання NGK VAG", "BKUR6ET-10/2397", 350.75f, 6, 2, 100 },
                    { 3, 4, "Надійний амортизатор Sachs для комфортної їзди.", "https://content.rozetka.com.ua/goods/images/big/299470781.jpg", "Амортизатор Sachs (передній) VAG", "315087", 2500.99f, 7, 3, 30 },
                    { 4, 8, "Високопродуктивний паливний насос Denso для стабільної подачі пального.", "https://img.dok.ua/images/card/product/0320/16/904005_1.jpg", "Паливний насос Denso DFP-0106", "01209160", 3200f, 4, 4, 20 }
                });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "CategoryId", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Блок двигуна" },
                    { 2, 1, "Головка блока циліндрів" },
                    { 3, 1, "Поршні та кільця" },
                    { 4, 1, "Клапани та розпредвал" },
                    { 5, 1, "Колінчастий вал" },
                    { 6, 1, "Турбокомпресор" },
                    { 7, 1, "Масляний насос" },
                    { 8, 1, "Прокладки та ущільнення" },
                    { 9, 2, "Гальмівні диски" },
                    { 10, 2, "Гальмівні колодки" },
                    { 11, 2, "Гальмівні барабани" },
                    { 12, 2, "Гальмівні шланги" },
                    { 13, 2, "Головний гальмівний циліндр" },
                    { 14, 2, "ABS-сенсори" },
                    { 15, 3, "Стартер" },
                    { 16, 3, "Генератор" },
                    { 17, 3, "Акумулятор" },
                    { 18, 3, "Свічки запалювання" },
                    { 19, 3, "Котушка запалювання" },
                    { 20, 3, "Датчики (кисневий, температури, тиску тощо)" },
                    { 21, 3, "Електропроводка" },
                    { 22, 4, "Амортизатори" },
                    { 23, 4, "Пружини підвіски" },
                    { 24, 4, "Кульові опори" },
                    { 25, 4, "Рульові тяги та наконечники" },
                    { 26, 4, "Стабілізатори та втулки" },
                    { 27, 4, "Рульова рейка" },
                    { 28, 4, "Підшипники маточини" },
                    { 29, 5, "Зчеплення" },
                    { 30, 5, "КПП" },
                    { 31, 5, "Привідні вали та ШРУСи" },
                    { 32, 5, "Роздавальна коробка" },
                    { 33, 5, "Мости та диференціал" },
                    { 34, 6, "Радіатор охолодження" },
                    { 35, 6, "Водяний насос (помпа)" },
                    { 36, 6, "Термостат" },
                    { 37, 6, "Вентилятор" },
                    { 38, 6, "Розширювальний бачок" },
                    { 39, 6, "Шланги та патрубки" },
                    { 40, 7, "Глушник" },
                    { 41, 7, "Каталізатор" },
                    { 42, 7, "Лямбда-зонд" },
                    { 43, 7, "Резонатор" },
                    { 44, 7, "Випускний колектор" },
                    { 45, 8, "Паливний насос" },
                    { 46, 8, "Форсунки" },
                    { 47, 8, "Карбюратор" },
                    { 48, 8, "Бензобак" },
                    { 49, 8, "Паливний фільтр" },
                    { 50, 8, "Рампа" },
                    { 51, 9, "Капот" },
                    { 52, 9, "Двері" },
                    { 53, 9, "Крила" },
                    { 54, 9, "Бампери" },
                    { 55, 9, "Дзеркала" },
                    { 56, 9, "Скло (лобове, бічне, заднє)" },
                    { 57, 9, "Фари та задні ліхтарі" },
                    { 58, 10, "Фари головного світла" },
                    { 59, 10, "Протитуманні фари" },
                    { 60, 10, "Ліхтарі заднього ходу" },
                    { 61, 10, "Габаритні вогні" },
                    { 62, 10, "Лампи та LED-елементи" },
                    { 63, 11, "Диски (легкосплавні, сталеві)" },
                    { 64, 11, "Шини" },
                    { 65, 11, "Гайки та болти кріплення" },
                    { 66, 12, "Бортовий комп’ютер" },
                    { 67, 12, "Камера заднього виду" },
                    { 68, 12, "Парктроніки" },
                    { 69, 12, "Магнітола" },
                    { 70, 12, "Дисплеї та мультимедійні системи" },
                    { 71, 13, "Кермо" },
                    { 72, 13, "Сидіння" },
                    { 73, 13, "Панель приладів" },
                    { 74, 13, "Килимки" },
                    { 75, 13, "Підлокітники" },
                    { 76, 14, "Масло моторне/трансмісійне" },
                    { 77, 14, "Антифриз" },
                    { 78, 14, "Гальмівна рідина" },
                    { 79, 14, "Омивач скла" },
                    { 80, 14, "Мастильні матеріали" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpareParts_CategoryId",
                table: "SpareParts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SpareParts_ProducerId",
                table: "SpareParts",
                column: "ProducerId");

            migrationBuilder.CreateIndex(
                name: "IX_SpareParts_ProviderId",
                table: "SpareParts",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpareParts");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "Producers");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
