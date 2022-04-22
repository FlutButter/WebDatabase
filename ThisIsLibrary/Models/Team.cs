using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishfirm
{
    public class Team
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public ICollection<FishingOut> FishingOuts { get; set; } = new List<FishingOut>();
        public ICollection<Fisherman> Fishermen { get; set; } = new List<Fisherman>();
    }
}
