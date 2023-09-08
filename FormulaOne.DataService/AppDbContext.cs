using FormulaOne.Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataService
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<Driver> drivers { get; set; }
        public virtual DbSet<Achievement> achievements { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }

        // setting up foreign keys and relationship between tables
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Achievement>(entity =>
            {
                entity.HasOne(d => d.driver)
                      .WithMany(p => p.Achievements)
                      .HasForeignKey(d => d.DriverId)
                      .OnDelete(DeleteBehavior.NoAction)
                      .HasConstraintName("FK_Achivement_Driver");
            });
        }
       
    }
}
