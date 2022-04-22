using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Fishfirm
{
    class Program
    {
        public static void DataGenerator()
        {
            FishContext db = new();
            Fisherman f1 = new()
            {
                Name = "Игорь Петрович",
                Position = "Капитан",
                Address = "город Щёлково, пр. Ломоносова, 32"
            };
            Fisherman f2 = new()
            {
                Name = "Степан Олегович",
                Position = "Боцман",
                Address = "город Одинцово, пл. Косиора, 31"
            };
            Fisherman f3 = new()
            {
                Name = "Светлана Яковлевна",
                Position = "Рыбак",
                Address = "город Подольск, въезд Косиора, 98"
            };
            Fisherman f4 = new()
            {
                Name = "Захар Артемович",
                Position = "Капитан",
                Address = "город Москва, проезд Сталина, 52"
            };
            Fisherman f5 = new()
            {
                Name = "Даниил Евгеньевич",
                Position = "Боцман",
                Address = "город Зарайск, пер. Ладыгина, 11"
            };
            Fisherman f6 = new()
            {
                Name = "Лев Георгиевич",
                Position = "Рыбак",
                Address = "город Сергиев Посад, пер. Домодедовская, 40"
            };
            Fisherman f7 = new()
            {
                Name = "Надежда Степановна",
                Position = "Рыбак",
                Address = "город Красногорск, пер. Гагарина, 92"
            };
            db.Fishermen.AddRange(new List<Fisherman> { f1, f2, f3, f4, f5, f6, f7 });
            Team t1 = new() { Name = "Бравые" };
            t1.Fishermen.Add(f1);
            t1.Fishermen.Add(f2);
            t1.Fishermen.Add(f3);
            Team t2 = new() { Name = "Храбрые" };
            t2.Fishermen.Add(f4);
            t2.Fishermen.Add(f5);
            t2.Fishermen.Add(f3);
            Team t3 = new() { Name = "Морские волки" };
            t3.Fishermen.Add(f1);
            t3.Fishermen.Add(f5);
            t3.Fishermen.Add(f6);
            t3.Fishermen.Add(f7);
            db.Teams.AddRange(new List<Team> { t1, t2, t3 });
            Boat b1 = new()
            {
                Name = "Русалка",
                Type = "Траулер",
                Displacement = 5631,
                DateConstruct = new DateTime(2019, 03, 07)
            };
            Boat b2 = new()
            {
                Name = "Посейдон",
                Type = "Дрифтер",
                Displacement = 5982,
                DateConstruct = new DateTime(2016, 06, 21)
            };
            Boat b3 = new()
            {
                Name = "Фортуна",
                Type = "Сейнер",
                Displacement = 5459,
                DateConstruct = new DateTime(2020, 01, 04)
            };
            db.Boats.AddRange(new List<Boat> { b1, b2, b3 });
            FishPlace fp1 = new() { Name = "Богатые воды" };
            FishPlace fp2 = new() { Name = "Рыбный рай" };
            FishPlace fp3 = new() { Name = "Глубокий пруд" };
            FishPlace fp4 = new() { Name = "Тут рыбы завались" };
            FishPlace fp5 = new() { Name = "Угодья царь рыбы" };
            FishPlace fp6 = new() { Name = "Водный мир" };
            db.FishPlaces.AddRange(new List<FishPlace> { fp1, fp2, fp3, fp4, fp5, fp6 });
            FishingOut fo1 = new()
            {
                DateRelease = new DateTime(2019, 02, 23),
                DateReturn = new DateTime(2019, 04, 25),
                Boat = b1,
                Team = t1
            };
            FishingOut fo2 = new()
            {
                DateRelease = new DateTime(2019, 05, 03),
                DateReturn = new DateTime(2019, 07, 12),
                Boat = b2,
                Team = t1
            };
            FishingOut fo3 = new()
            {
                DateRelease = new DateTime(2019, 09, 07),
                DateReturn = new DateTime(2019, 11, 21),
                Boat = b1,
                Team = t2
            };
            FishingOut fo4 = new()
            {
                DateRelease = new DateTime(2020, 03, 04),
                DateReturn = new DateTime(2020, 07, 17),
                Boat = b3,
                Team = t3
            };
            db.FishingOuts.AddRange(new List<FishingOut> { fo1, fo2, fo3, fo4 });
            VisitFishPlace vfp1 = new() // рейс 1
            {
                DateIn = new DateTime(2019, 02, 24),
                DateOut = new DateTime(2019, 03, 01),
                Quality = Quality.Great,
                FishingOut = fo1,
                FishPlace = fp1
            };
            VisitFishPlace vfp2 = new()
            {
                DateIn = new DateTime(2019, 03, 02),
                DateOut = new DateTime(2019, 03, 12),
                Quality = Quality.Good,
                FishingOut = fo1,
                FishPlace = fp3
            };
            VisitFishPlace vfp3 = new()
            {
                DateIn = new DateTime(2019, 03, 14),
                DateOut = new DateTime(2019, 03, 25),
                Quality = Quality.Bad,
                FishingOut = fo1,
                FishPlace = fp5
            };
            VisitFishPlace vfp4 = new() // рейс 2
            {
                DateIn = new DateTime(2019, 05, 05),
                DateOut = new DateTime(2019, 05, 17),
                Quality = Quality.Great,
                FishingOut = fo2,
                FishPlace = fp2
            };
            VisitFishPlace vfp5 = new()
            {
                DateIn = new DateTime(2019, 05, 20),
                DateOut = new DateTime(2019, 06, 12),
                Quality = Quality.Great,
                FishingOut = fo2,
                FishPlace = fp3
            };
            VisitFishPlace vfp6 = new() // рейс 3
            {
                DateIn = new DateTime(2019, 09, 10),
                DateOut = new DateTime(2019, 09, 30),
                Quality = Quality.Good,
                FishingOut = fo3,
                FishPlace = fp4
            };
            VisitFishPlace vfp7 = new()
            {
                DateIn = new DateTime(2019, 10, 02),
                DateOut = new DateTime(2019, 10, 12),
                Quality = Quality.Bad,
                FishingOut = fo3,
                FishPlace = fp6
            };
            VisitFishPlace vfp8 = new() // рейс 4
            {
                DateIn = new DateTime(2020, 03, 05),
                DateOut = new DateTime(2019, 04, 01),
                Quality = Quality.Bad,
                FishingOut = fo4,
                FishPlace = fp6
            };
            VisitFishPlace vfp9 = new()
            {
                DateIn = new DateTime(2019, 04, 05),
                DateOut = new DateTime(2019, 05, 11),
                Quality = Quality.Good,
                FishingOut = fo4,
                FishPlace = fp1
            };
            db.VisitFishPlaces.AddRange(new List<VisitFishPlace>
            {
                vfp1, vfp2, vfp3, vfp4, vfp5,
                vfp6, vfp7, vfp8, vfp9
            });
            Fish fi1 = new() { Kind = "Горбуша" };
            Fish fi2 = new() { Kind = "Тунец" };
            Fish fi3 = new() { Kind = "Судак" };
            Fish fi4 = new() { Kind = "Тудак" };
            Fish fi5 = new() { Kind = "Карась" };
            db.Fish.AddRange(new List<Fish> { fi1, fi2, fi3, fi4, fi5 });
            Catch c1 = new() { Fish = fi1, Weight = 120, VisitFishPlace = vfp1 };
            Catch c2 = new() { Fish = fi2, Weight = 100, VisitFishPlace = vfp1 };
            Catch c3 = new() { Fish = fi3, Weight = 243, VisitFishPlace = vfp1 };
            Catch c4 = new() { Fish = fi4, Weight = 231, VisitFishPlace = vfp2 };
            Catch c5 = new() { Fish = fi5, Weight = 654, VisitFishPlace = vfp3 };
            Catch c6 = new() { Fish = fi2, Weight = 560, VisitFishPlace = vfp3 };
            Catch c7 = new() { Fish = fi2, Weight = 965, VisitFishPlace = vfp4 };
            Catch c8 = new() { Fish = fi1, Weight = 594, VisitFishPlace = vfp4 };
            Catch c9 = new() { Fish = fi1, Weight = 213, VisitFishPlace = vfp5 };
            Catch c10 = new() { Fish = fi1, Weight = 342, VisitFishPlace = vfp5 };
            Catch c11 = new() { Fish = fi3, Weight = 975, VisitFishPlace = vfp6 };
            Catch c12 = new() { Fish = fi4, Weight = 505, VisitFishPlace = vfp6 };
            Catch c13 = new() { Fish = fi5, Weight = 546, VisitFishPlace = vfp7 };
            Catch c14 = new() { Fish = fi5, Weight = 555, VisitFishPlace = vfp7 };
            Catch c15 = new() { Fish = fi2, Weight = 213, VisitFishPlace = vfp8 };
            Catch c16 = new() { Fish = fi2, Weight = 903, VisitFishPlace = vfp8 };
            Catch c17 = new() { Fish = fi3, Weight = 875, VisitFishPlace = vfp8 };
            Catch c18 = new() { Fish = fi2, Weight = 761, VisitFishPlace = vfp9 };
            db.Catches.AddRange(new List<Catch>
            {
                c1, c2, c3, c4, c5,
                c6, c7, c8, c9, c10,
                c11, c12, c13, c14,
                c15, c16, c17, c18
            });
            db.SaveChanges();
        }
        static void Main()
        {
            FishContext db = new();
            var info = new string("1 - Создать/пересоздать базу данных и заполнить исходными данными\n" +
                "2 - для каждого катера вывести даты выхода в море с указанием улова\n" +
                "3 - предоставить возможность добавления нового катера\n" +
                "4 - вывести список сортов рыбы и для каждого сорта список рейсов с указанием даты выхода и возвращения, количества улова\n" +
                "Для выхода введите любой другой символ");
            Console.WriteLine(info);
            while (true)
            {
                var s = Console.ReadLine();
                switch (s)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Ожидайте\n");
                        db.Database.EnsureDeleted();
                        db.Database.EnsureCreated();
                        DataGenerator();
                        Console.WriteLine("Готово\n" + info);
                        break;
                    case "2":
                        Console.Clear();
                        Task1.Program(db);
                        Console.WriteLine(info);
                        break;
                    case "3":
                        Console.Clear();
                        Task2.Program(db);
                        Console.WriteLine(info);
                        break;
                    case "4":
                        Console.Clear();
                        Task3.Program(db);
                        Console.WriteLine(info);
                        break;
                    default:
                        Console.Clear();
                        return;
                }
            }
        }
    }
}