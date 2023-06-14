using AdminPanelNetCore.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelNetCore.EntityLayer
{
    public class AppDbContext: DbContext
    {
        public DbSet<User>? Users { get; set; }
        public DbSet<Turns>? Turns { get; set; }
        public DbSet<Position>? Position { get; set; }
        public DbSet<OptionsTerminal>? Options { get; set; }
        public DbSet<PositionService>? PositionService { get; set; }
        public DbSet<ServiseLangs>? ServiseLangs { get; set; }
        public DbSet<Service>? Services { get; set; }
        public DbSet<CurrentTurn>? CurrentTurn { get; set; }
        public DbSet<HistoryTurn>? HistoryTurns { get; set; }
        public DbSet<Branch>? Branchs { get; set; }
        public DbSet<TvTablosTickers>? TvTablosTickers { get; set; }
        public DbSet<Alphabet>? Alphabet { get; set; }
        public AppDbContext(DbContextOptions options) : base(options) { }
        
    }
}
