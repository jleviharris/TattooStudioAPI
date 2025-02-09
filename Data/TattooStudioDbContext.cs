using Microsoft.EntityFrameworkCore;
using TattooStudioApi.Models;

namespace TattooStudioApi.Data
{
    public class TattooStudioDbContext : DbContext
    {
        public TattooStudioDbContext(DbContextOptions<TattooStudioDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<ClientNote> ClientNotes { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<TattooDetail> TattooDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Prevent cascade delete cycle issues
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Client>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ClientNote>()
                .HasOne(cn => cn.User)
                .WithMany()
                .HasForeignKey(cn => cn.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Session>()
                .HasOne(s => s.Project)
                .WithMany()
                .HasForeignKey(s => s.ProjectId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Session>()
                .HasOne(s => s.Appointment)
                .WithMany()
                .HasForeignKey(s => s.AppointmentId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
