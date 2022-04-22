using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishfirm
{
    public class Fish
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Kind { get; set; }
        public ICollection<Catch> Catches { get; set; } = new List<Catch>();
    }
}
