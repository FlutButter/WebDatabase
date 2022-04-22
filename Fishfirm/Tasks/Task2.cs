using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishfirm
{
    public class Task2
    {
        public static void Program(FishContext db)
        {
            Console.WriteLine($"Введите название судна");
            var name = Console.ReadLine();
            Console.WriteLine($"Введите тип судна");
            var type = Console.ReadLine();
            Console.WriteLine($"Введите водоизмещение (целое)");
            var displacement = Console.ReadLine();
            Console.WriteLine($"Введите дату постройки судна (yyyy.mm.dd)");
            var date = Console.ReadLine();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(type)
                || name.Length > 100 || type.Length > 100
                || string.IsNullOrEmpty(displacement) || string.IsNullOrEmpty(date)
                || !Utils.CheckNum(displacement) || !Utils.CheckDate(date))
            {
                Console.WriteLine("Некорректные данные\n");
                return;
            }
            Boat boat = new()
            {
                Name = name,
                Type = type,
                Displacement = Convert.ToInt32(displacement),
                DateConstruct = Convert.ToDateTime(date)
            };
            Console.WriteLine($"Судно {name} успешно добавлено");
            db.Boats.Add(boat);
            db.SaveChanges();
        }
    }
}
