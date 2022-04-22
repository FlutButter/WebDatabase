using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishfirm
{
    public class Catch
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public int Weight { get; set; }
        public int VisitFishPlaceId { get; set; }
        public int FishId { get; set; }
        public Fish Fish { get; set; }
        public VisitFishPlace VisitFishPlace { get; set; }
    }
}
