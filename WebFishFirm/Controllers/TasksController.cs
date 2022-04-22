using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fishfirm;

namespace WebFishFirm.Controllers
{
    public class TasksController : Controller
    {
        private readonly FishContext _context;

        public TasksController(FishContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Task1()
        {
            var boats = _context.Boats.ToList();
            var data = new List<string>();
            foreach (var boat in boats)
            {
                data.Add($"Катер: {boat.Name}");
                var fo = _context.FishingOuts.Where(i => i.BoatId == boat.Id).ToList();
                foreach (var date in fo)
                {
                    int count = 0;
                    data.Add($"Дата выхода: {date.DateRelease:dd.MM.yyyy}");
                    var vfp = _context.VisitFishPlaces.Where(i => i.FishingOutId == date.Id).ToList();
                    foreach (var item in vfp)
                    {
                        var catches = _context.Catches.Where(i => i.VisitFishPlaceId == item.Id).ToList();
                        foreach (var fish in catches)
                        {
                            count += fish.Weight;
                        }
                    }
                    data.Add($"Общий вес улова: {count} кг.");
                }
            }
            return View(data);
        }

        public IActionResult Task2()
        {
            var data = new List<string>();
            var fishes = _context.Fish
               .Include(x => x.Catches)
                   .ThenInclude(x => x.VisitFishPlace)
                       .ThenInclude(x => x.FishingOut)
               .ToList();
            foreach (var fish in fishes)
            {
                data.Add($"Сорт: {fish.Kind}");
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
                    data.Add(race);
                data.Add($"Общий улов: {count} кг.");
            }
            return View(data);
        }
    }
}
