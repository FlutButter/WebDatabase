using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishfirm
{
    public class VisitFishPlace
    {
        public int Id { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }
        [MaxLength(100)]
        public Quality Quality { get; set; }
        public int FishingOutId { get; set; }
        public FishingOut FishingOut { get; set; }
        public int FishPlaceId { get; set; }
        public FishPlace FishPlace { get; set; }
        public ICollection<Catch> Catches { get; set; } = new List<Catch>();
    }

    public enum Quality
    {
        Great,
        Good,
        Bad
    }
}
