using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Enum;

namespace Infrastructure.Data
{
    public class AlbunsContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Albun> Albuns { get; set; }
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public AlbunsContext(DbContextOptions<AlbunsContext> options ) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasDiscriminator<UserType>("UserType")
                .HasValue<Admin>(UserType.Admin)
                .HasValue<Musician>(UserType.Musician)
                .HasValue<Subscriber>(UserType.Subscriber);


            modelBuilder.Entity<Subscriber>()
                .HasMany(s => s.Reviews)
                .WithOne(r => r.Subscriber)
                .HasForeignKey(r => r.SubscriberId);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Subscriber)
                .WithMany(s => s.Reviews)
                .HasForeignKey(s => s.SubscriberId);
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Albun)
                .WithMany(a => a.Reviews)
                .HasForeignKey(a => a.AlbunId);

            modelBuilder.Entity<Albun>()
                .HasOne(a => a.Musician)
                .WithMany(m => m.Albuns)
                .HasForeignKey(a => a.MusicianId);

            modelBuilder.Entity<Musician>()
                .HasMany(m => m.Albuns)
                .WithOne(a => a.Musician)
                .HasForeignKey(a => a.MusicianId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
