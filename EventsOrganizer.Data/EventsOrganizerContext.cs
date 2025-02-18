
using EventsOrganizer.Data.Common;
using EventsOrganizer.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace EventsOrganizer.Data
{
    public class EventsOrganizerContext : DbContext
    {
        public EventsOrganizerContext()
        {

        }

        public DbSet<Event>? Events { get; set; }
        public DbSet<ButtonOnOff>? ButtonOnOffs { get; set; }
        public DbSet<EnBgWord>? EnBgWords { get; set; }
        public DbSet<Result>? Results { get; set; }
        public DbSet<RepeatWord>? RepeatWords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DbConfig.ConnectionString);
                optionsBuilder.EnableSensitiveDataLogging();
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
