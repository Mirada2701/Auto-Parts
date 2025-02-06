using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Helpers
{
    public static class SeederDb
    {
        public static void SeedCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category[]
            {
                new Category
                {
                    Id = 1,
                    Name = "Двигун і його компоненти"
                },
                new Category
                {
                    Id = 2,
                    Name = "Гальмівна система"
                },
                new Category
                {
                    Id = 3,
                    Name = "Електрообладнання та запалювання"
                },
                new Category
                {
                    Id = 4,
                    Name = "Ходова частина (підвіска, рульове управління)"
                },
                new Category
                {
                    Id = 5,
                    Name = "Трансмісія та привід"
                },
                new Category
                {
                    Id = 6,
                    Name = "Система охолодження"
                },
                new Category
                {
                    Id = 7,
                    Name = "Вихлопна система"
                },
                new Category
                {
                    Id = 8,
                    Name = "Паливна система"
                },
                new Category
                {
                    Id = 9,
                    Name = "Кузовні деталі"
                },
                new Category
                {
                    Id = 10,
                    Name = "Оптика та освітлення"
                },
                new Category
                {
                    Id = 11,
                    Name = "Колеса та шини"
                },
                new Category
                {
                    Id = 12,
                    Name = "Автоелектроніка та мультимедіа"
                },
                new Category
                {
                    Id = 13,
                    Name = "Інтер’єр та аксесуари"
                },
                new Category
                {
                    Id = 14,
                    Name = "Рідини та витратні матеріали"
                }
             });
        }
        public static void SeedSubCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubCategory>().HasData(new SubCategory[]
            {
                // Двигун і його компоненти
               new SubCategory { Id = 1, CategoryId = 1, Title = "Блок двигуна" },
               new SubCategory { Id = 2, CategoryId = 1, Title = "Головка блока циліндрів" },
               new SubCategory { Id = 3, CategoryId = 1, Title = "Поршні та кільця" },
               new SubCategory { Id = 4, CategoryId = 1, Title = "Клапани та розпредвал" },
               new SubCategory { Id = 5, CategoryId = 1, Title = "Колінчастий вал" },
               new SubCategory { Id = 6, CategoryId = 1, Title = "Турбокомпресор" },
               new SubCategory { Id = 7, CategoryId = 1, Title = "Масляний насос" },
               new SubCategory { Id = 8, CategoryId = 1, Title = "Прокладки та ущільнення" },

               // Гальмівна система
               new SubCategory { Id = 9, CategoryId = 2, Title = "Гальмівні диски" },
               new SubCategory { Id = 10, CategoryId = 2, Title = "Гальмівні колодки" },
               new SubCategory { Id = 11, CategoryId = 2, Title = "Гальмівні барабани" },
               new SubCategory { Id = 12, CategoryId = 2, Title = "Гальмівні шланги" },
               new SubCategory { Id = 13, CategoryId = 2, Title = "Головний гальмівний циліндр" },
               new SubCategory { Id = 14, CategoryId = 2, Title = "ABS-сенсори" },

               // Електрообладнання та запалювання
               new SubCategory { Id = 15, CategoryId = 3, Title = "Стартер" },
               new SubCategory { Id = 16, CategoryId = 3, Title = "Генератор" },
               new SubCategory { Id = 17, CategoryId = 3, Title = "Акумулятор" },
               new SubCategory { Id = 18, CategoryId = 3, Title = "Свічки запалювання" },
               new SubCategory { Id = 19, CategoryId = 3, Title = "Котушка запалювання" },
               new SubCategory { Id = 20, CategoryId = 3, Title = "Датчики (кисневий, температури, тиску тощо)" },
               new SubCategory { Id = 21, CategoryId = 3, Title = "Електропроводка" },

               // Ходова частина
               new SubCategory { Id = 22, CategoryId = 4, Title = "Амортизатори" },
               new SubCategory { Id = 23, CategoryId = 4, Title = "Пружини підвіски" },
               new SubCategory { Id = 24, CategoryId = 4, Title = "Кульові опори" },
               new SubCategory { Id = 25, CategoryId = 4, Title = "Рульові тяги та наконечники" },
               new SubCategory { Id = 26, CategoryId = 4, Title = "Стабілізатори та втулки" },
               new SubCategory { Id = 27, CategoryId = 4, Title = "Рульова рейка" },
               new SubCategory { Id = 28, CategoryId = 4, Title = "Підшипники маточини" },

               // Трансмісія та привід
               new SubCategory { Id = 29, CategoryId = 5, Title = "Зчеплення" },
               new SubCategory { Id = 30, CategoryId = 5, Title = "КПП" },
               new SubCategory { Id = 31, CategoryId = 5, Title = "Привідні вали та ШРУСи" },
               new SubCategory { Id = 32, CategoryId = 5, Title = "Роздавальна коробка" },
               new SubCategory { Id = 33, CategoryId = 5, Title = "Мости та диференціал" },
               // Система охолодження
                new SubCategory { Id = 34, CategoryId = 6, Title = "Радіатор охолодження" },
                new SubCategory { Id = 35, CategoryId = 6, Title = "Водяний насос (помпа)" },
                new SubCategory { Id = 36, CategoryId = 6, Title = "Термостат" },
                new SubCategory { Id = 37, CategoryId = 6, Title = "Вентилятор" },
                new SubCategory { Id = 38, CategoryId = 6, Title = "Розширювальний бачок" },
                new SubCategory { Id = 39, CategoryId = 6, Title = "Шланги та патрубки" },
                
                // Вихлопна система
                new SubCategory { Id = 40, CategoryId = 7, Title = "Глушник" },
                new SubCategory { Id = 41, CategoryId = 7, Title = "Каталізатор" },
                new SubCategory { Id = 42, CategoryId = 7, Title = "Лямбда-зонд" },
                new SubCategory { Id = 43, CategoryId = 7, Title = "Резонатор" },
                new SubCategory { Id = 44, CategoryId = 7, Title = "Випускний колектор" },
                
                // Паливна система
                new SubCategory { Id = 45, CategoryId = 8, Title = "Паливний насос" },
                new SubCategory { Id = 46, CategoryId = 8, Title = "Форсунки" },
                new SubCategory { Id = 47, CategoryId = 8, Title = "Карбюратор" },
                new SubCategory { Id = 48, CategoryId = 8, Title = "Бензобак" },
                new SubCategory { Id = 49, CategoryId = 8, Title = "Паливний фільтр" },
                new SubCategory { Id = 50, CategoryId = 8, Title = "Рампа" },
                
                // Кузовні деталі
                new SubCategory { Id = 51, CategoryId = 9, Title = "Капот" },
                new SubCategory { Id = 52, CategoryId = 9, Title = "Двері" },
                new SubCategory { Id = 53, CategoryId = 9, Title = "Крила" },
                new SubCategory { Id = 54, CategoryId = 9, Title = "Бампери" },
                new SubCategory { Id = 55, CategoryId = 9, Title = "Дзеркала" },
                new SubCategory { Id = 56, CategoryId = 9, Title = "Скло (лобове, бічне, заднє)" },
                new SubCategory { Id = 57, CategoryId = 9, Title = "Фари та задні ліхтарі" },
                
                // Оптика та освітлення
                new SubCategory { Id = 58, CategoryId = 10, Title = "Фари головного світла" },
                new SubCategory { Id = 59, CategoryId = 10, Title = "Протитуманні фари" },
                new SubCategory { Id = 60, CategoryId = 10, Title = "Ліхтарі заднього ходу" },
                new SubCategory { Id = 61, CategoryId = 10, Title = "Габаритні вогні" },
                new SubCategory { Id = 62, CategoryId = 10, Title = "Лампи та LED-елементи" },
                
                // Колеса та шини
                new SubCategory { Id = 63, CategoryId = 11, Title = "Диски (легкосплавні, сталеві)" },
                new SubCategory { Id = 64, CategoryId = 11, Title = "Шини" },
                new SubCategory { Id = 65, CategoryId = 11, Title = "Гайки та болти кріплення" },
                
                // Автоелектроніка та мультимедіа
                new SubCategory { Id = 66, CategoryId = 12, Title = "Бортовий комп’ютер" },
                new SubCategory { Id = 67, CategoryId = 12, Title = "Камера заднього виду" },
                new SubCategory { Id = 68, CategoryId = 12, Title = "Парктроніки" },
                new SubCategory { Id = 69, CategoryId = 12, Title = "Магнітола" },
                new SubCategory { Id = 70, CategoryId = 12, Title = "Дисплеї та мультимедійні системи" },
                
                // Інтер’єр та аксесуари
                new SubCategory { Id = 71, CategoryId = 13, Title = "Кермо" },
                new SubCategory { Id = 72, CategoryId = 13, Title = "Сидіння" },
                new SubCategory { Id = 73, CategoryId = 13, Title = "Панель приладів" },
                new SubCategory { Id = 74, CategoryId = 13, Title = "Килимки" },
                new SubCategory { Id = 75, CategoryId = 13, Title = "Підлокітники" },
                
                // Рідини та витратні матеріали
                new SubCategory { Id = 76, CategoryId = 14, Title = "Масло моторне/трансмісійне" },
                new SubCategory { Id = 77, CategoryId = 14, Title = "Антифриз" },
                new SubCategory { Id = 78, CategoryId = 14, Title = "Гальмівна рідина" },
                new SubCategory { Id = 79, CategoryId = 14, Title = "Омивач скла" },
                new SubCategory { Id = 80, CategoryId = 14, Title = "Мастильні матеріали" }
            });
        }

        public static void SeedProducers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producer>().HasData(new Producer[]
            {
                new Producer { Id = 1, Name = "Bosch", Country = "Німеччина" },
                new Producer { Id = 2, Name = "Continental", Country = "Німеччина" },
                new Producer { Id = 3, Name = "Delphi", Country = "США" },
                new Producer { Id = 4, Name = "Denso", Country = "Японія" },
                new Producer { Id = 5, Name = "Valeo", Country = "Франція" },
                new Producer { Id = 6, Name = "NGK", Country = "Японія" },
                new Producer { Id = 7, Name = "Sachs", Country = "Німеччина" },
                new Producer { Id = 8, Name = "Bilstein", Country = "Німеччина" }
            });
        }

        public static void SeedProviders(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Provider>().HasData(new Provider[]
            {
                new Provider { Id = 1, Name = "AutoTrade", Contact = "info@autotrade.ua" },
                new Provider { Id = 2, Name = "PartsExpress", Contact = "sales@partsexpress.pl" },
                new Provider { Id = 3, Name = "EuroParts", Contact = "support@europarts.de" },
                new Provider { Id = 4, Name = "GlobalAuto", Contact = "contact@globalauto.com" }
            });
        }

        public static void SeedParts(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SparePart>().HasData(new SparePart[]
            {
                new SparePart
                {
                    Id = 1,
                    Name = "Дискові гальмівні колодки Bosch",
                    ImageUrl = "https://content.rozetka.com.ua/goods/images/big/498080167.jpg",
                    CategoryId = 2,
                    ProducerId = 1,
                    ProviderId = 1,
                    PartNumber = "8570259",
                    Description = "Високоякісні гальмівні колодки Bosch для надійного гальмування.",
                    Quantity = 50,
                    Price = 1200.50f
                },
                new SparePart
                {
                    Id = 2,
                    Name = "Свічки запалювання NGK VAG",
                    ImageUrl = "https://content1.rozetka.com.ua/goods/images/big/347984637.jpg",
                    CategoryId = 3,
                    ProducerId = 6,
                    ProviderId = 2,
                    PartNumber = "BKUR6ET-10/2397",
                    Description = "Свічки запалювання преміум-класу від NGK для покращення ефективності двигуна.",
                    Quantity = 100,
                    Price = 350.75f
                 },
                 new SparePart
                {
                     Id = 3,
                     Name = "Амортизатор Sachs (передній) VAG",
                     ImageUrl = "https://content.rozetka.com.ua/goods/images/big/299470781.jpg",
                     CategoryId = 4,
                     ProducerId = 7,
                     ProviderId = 3,
                     PartNumber = "315087",
                     Description = "Надійний амортизатор Sachs для комфортної їзди.",
                     Quantity = 30,
                     Price = 2500.99f
                 },
                 new SparePart
                 {
                     Id = 4,
                     Name = "Паливний насос Denso DFP-0106",
                     ImageUrl = "https://img.dok.ua/images/card/product/0320/16/904005_1.jpg",
                     CategoryId = 8,
                     ProducerId = 4,
                     ProviderId = 4,
                     PartNumber = "01209160",
                     Description = "Високопродуктивний паливний насос Denso для стабільної подачі пального.",
                     Quantity = 20,
                     Price = 3200.00f
                 }
            });
        }
    }
}
