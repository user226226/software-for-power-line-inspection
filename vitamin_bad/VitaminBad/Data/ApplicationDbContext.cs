using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;
using VitaminBad.Domain.Entity;

namespace VitaminBad.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
: base(options)
        {

        }
        public DbSet<Coordinate> Coordinates { get; set; }
        public DbSet<Dron> Drons { get; set; }
        public DbSet<Emploee> Emploees { get; set; }
        public DbSet<StatusEvent> StatusEvents { get; set; }
        public DbSet<TypeEvent> TypeEvents { get; set; }
        public DbSet<PNagruzka> PNagruzkas { get; set; }

        public DbSet<Domain.Entity.Path> Paths { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Crew> Crews { get; set; }     


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
