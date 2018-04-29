using Kanban.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kanban.Infrastructure.Data
{
    public class KanbanDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<ProjectTask>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<ProjectTask>()
                .HasOne(x => x.Project)
                .WithMany(x => x.Tasks)
                .HasForeignKey(x => x.ProjectId);
            modelBuilder.Entity<ProjectTask>().Property(x => x.DueDate).IsRequired(false);
            modelBuilder.Entity<ProjectTask>().Property(x => x.CompletedDate).IsRequired(false);

            modelBuilder.Entity<User>()
                .HasKey(x => x.Id);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=Kanban;Trusted_Connection=True;");
        }
    }
}
