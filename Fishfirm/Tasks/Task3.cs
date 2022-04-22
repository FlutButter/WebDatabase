using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishfirm
{
    public class Task3
    {
        public static void Program(FishContext db)
        {
            var fishes = db.Fish
                .Include(x => x.Catches)
                    .ThenInclude(x => x.VisitFishPlace)
                        .ThenInclude(x => x.FishingOut)
                .ToList();
            foreach (var fish in fishes)
            {
                Console.WriteLine($"Сорт: {fish.Kind}");
                int count = 0;
                var races = new List<String>();
                foreach (var cat in fish.Catches)
                {
                    count += cat.Weight;
                    races.Add($"Рейс #{cat.VisitFishPlace.FishingOut.Id}, " +
                       $"Даты: { cat.VisitFishPlace.FishingOut.DateRelease:dd.MM.yyyy} - { cat.VisitFishPlace.FishingOut.DateReturn:dd.MM.yyyy}");
                }
                var sorted = races.Distinct();
                foreach (var race in sorted)
                    Console.WriteLine(race);
                Console.WriteLine($"Общий улов: {count} кг.");
            }
        }
    }
}
