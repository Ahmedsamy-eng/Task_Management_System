using Microsoft.EntityFrameworkCore;

namespace Assesmant.Models.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>()
                .HasOne(p => p.project)
                .WithMany(t => t.tasks)
                .HasForeignKey(f => f.Pro_Id).OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Task>()
                .HasOne(t => t.team_member)
                .WithMany(t => t.tasks)
                .HasForeignKey(f => f.Mem_ID).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
