using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishfirm
{
    public class Fisherman
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Position { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
        public ICollection<Team> Teams { get; set; } = new List<Team>();
    }
}
