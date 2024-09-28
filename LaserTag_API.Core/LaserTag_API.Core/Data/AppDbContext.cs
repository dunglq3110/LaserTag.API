using LaserTag_API.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserTag_API.Core.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public AppDbContext()
        {
        }

        public DbSet<player> Players { get; set; }
        public DbSet<attribute> Attributes { get; set; }
        public DbSet<config> Configs { get; set; }
        public DbSet<hit_log> Hit_Logs { get; set; }
        public DbSet<match> Matches { get; set; }
        public DbSet<player_attribute> Player_Attributes { get; set; }
        public DbSet<player_match> Player_Matches { get; set; }
        public DbSet<player_upgrade> Player_Upgrades { get; set; }
        public DbSet<round> Rounds { get; set; }
        public DbSet<shared_base> Shared_Bases { get; set; }
        public DbSet<shared_group> Shared_Groups { get; set; }
        public DbSet<shoot_log> Shoot_Logs { get; set; }
        public DbSet<upgrade> Upgrades { get; set; }
        public DbSet<upgrade_attribute> Upgrade_Attributes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
