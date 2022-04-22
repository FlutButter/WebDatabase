using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishfirm
{
    public class FishPlace
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public ICollection<VisitFishPlace> VisitFishPlaces { get; set; } = new List<VisitFishPlace>();
    }
}
