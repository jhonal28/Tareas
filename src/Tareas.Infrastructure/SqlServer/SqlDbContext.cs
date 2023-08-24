using Microsoft.EntityFrameworkCore;
using Tareas.Domain.Entities;

namespace Tareas.Infrastructure.SqlServer
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Work>().Property(w => w.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Work>()
                .HasOne(w => w.Category)
                .WithMany()
                .HasForeignKey(w => w.IdCategory);

            //modelBuilder.Entity<Work>(w =>
            //{
            //    //w.HasKey(p => p.Id);
            //    //w.HasOne(p => p.Category);
            //    w.Property()
            //});
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Work> works { get; set; }
    }
}
