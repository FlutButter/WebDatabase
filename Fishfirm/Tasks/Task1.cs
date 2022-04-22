using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishfirm
{
    public class Task1
    {
        public static void Program(FishContext db)
        {
            var boats = db.Boats.ToList();
            foreach (var boat in boats)
            {
                Console.WriteLine($"Катер: {boat.Name}");
                var fo = db.FishingOuts.Where(i => i.BoatId == boat.Id).ToList();
                foreach (var date in fo)
                {
                    int count = 0;
                    Console.WriteLine($"Дата выхода: {date.DateRelease:dd.MM.yyyy}");
                    var vfp = db.VisitFishPlaces.Where(i => i.FishingOutId == date.Id).ToList();
                    foreach (var item in vfp)
                    {
                        var catches = db.Catches.Where(i => i.VisitFishPlaceId == item.Id).ToList();
                        foreach (var fish in catches)
                        {
                            count += fish.Weight;
                        }
                    }
                    Console.WriteLine($"Общий вес улова: {count} кг.");
                }
                Console.WriteLine("----------------------------------");
            }
        }
    }
}
