using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishfirm
{
    public class Boat
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Type { get; set; }
        public int Displacement { get; set; } //водоизмещение
        public DateTime DateConstruct { get; set; }
        public ICollection<FishingOut> FishingOuts { get; set; } = new List<FishingOut>();

    }
}
