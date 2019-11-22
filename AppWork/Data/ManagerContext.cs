using AppWork.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWork.Data
{
    public class ManagerContext : DbContext
    {
        #region Constructors
        public ManagerContext(DbContextOptions<ManagerContext> options) : base (options)
         { }

        #region DbSets 
        public DbSet<Proekt> Proekts { get; set; }
        public DbSet<Programist> Programists { get; set; }
        public DbSet<Manager> Managers { get; set; }
        #endregion DbSets

        #region Model Creating
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proekt>().ToTable("Proekt");
            modelBuilder.Entity<Programist>().ToTable("Programist");
            modelBuilder.Entity<Manager>().ToTable("ManageWork");

            modelBuilder.Entity<Manager>()
               .HasKey(c => new { c.ProgramistId, c.ProektId });

        }
        #endregion Model Creating
    }
}
#endregion