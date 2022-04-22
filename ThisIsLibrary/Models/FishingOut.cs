using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishfirm
{
    public class FishingOut
    {
        public int Id { get; set; }
        public DateTime DateRelease { get; set; }
        public DateTime DateReturn { get; set; }
        public int BoatId { get; set; }
        public Boat Boat { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public ICollection<VisitFishPlace> VisitFishPlaces { get; set; } = new List<VisitFishPlace>();

    }
}
