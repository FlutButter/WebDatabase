using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishfirm
{
    public class FishContext : DbContext
    {
        public DbSet<Boat> Boats { get; set; }
        public DbSet<Catch> Catches { get; set; }
        public DbSet<Fish> Fish { get; set; }
        public DbSet<Fisherman> Fishermen { get; set; }
        public DbSet<FishingOut> FishingOuts { get; set; }
        public DbSet<VisitFishPlace> VisitFishPlaces { get; set; }
        public DbSet<FishPlace> FishPlaces { get; set; }
        public DbSet<Team> Teams { get; set; }

        public FishContext(DbContextOptions<FishContext> options) : base(options) { }

        public FishContext()
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-3N99OKM\SQLEXPRESS;Initial Catalog=FishFirm;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //}
    }
}
