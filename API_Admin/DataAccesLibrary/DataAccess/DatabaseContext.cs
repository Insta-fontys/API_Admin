using DataAccesLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLibrary.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Creator> Creators { get; set; }
        public DbSet<Fan> Fans { get; set; }
        public DbSet<LikedPosts> LikedPosts { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<SavedPosts> SavedPosts { get; set; }
        public DbSet<CreatorFans> CreatorFans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Creator>(i =>
            {
                i.Property(p => p.Id)
                .ValueGeneratedOnAdd();

                i.HasMany(i => i.BannedFans);

                i.HasMany(i => i.Posts)
                .WithOne(i => i.Creator)
                .HasForeignKey(i => i.CreatorId)
                .OnDelete(DeleteBehavior.Cascade);

                i.HasMany(i => i.Followers)
                .WithOne(i => i.Creator)
                .HasForeignKey(i => i.CreatorId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Fan>(i =>
            {
                i.Property(p => p.Id)
                .ValueGeneratedOnAdd();

                i.HasMany(i => i.CreatorFans)
                .WithOne(i => i.Fan)
                .HasForeignKey(i => i.FanId)
                .OnDelete(DeleteBehavior.Cascade);

                i.HasMany(i => i.Reactions)
                .WithOne(i => i.Fan)
                .HasForeignKey(i => i.FanId)
                .OnDelete(DeleteBehavior.Cascade);

                i.HasMany(i => i.LikedPosts)
                .WithOne(i => i.Fan)
                .HasForeignKey(i => i.FanId)
                .OnDelete(DeleteBehavior.Cascade);

                i.HasMany(i => i.SavedPosts)
                .WithOne(i => i.Fan)
                .HasForeignKey(i => i.FanId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<CreatorFans>(i =>
            {
                i.Property(p => p.Id)
                .ValueGeneratedOnAdd();

                i.HasOne(i => i.Fan)
                .WithMany(i => i.CreatorFans)
                .HasForeignKey(i => i.FanId)
                .OnDelete(DeleteBehavior.Cascade);

                i.HasOne(i => i.Creator)
                .WithMany(i => i.Followers)
                .HasForeignKey(i => i.CreatorId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Reaction>(i =>
            {
                i.Property(p => p.Id)
                .ValueGeneratedOnAdd();

                i.HasOne(i => i.Fan)
                .WithMany(i => i.Reactions)
                .HasForeignKey(i => i.FanId)
                .OnDelete(DeleteBehavior.Cascade);

                i.HasOne(i => i.Post)
                .WithMany(i => i.Reactions)
                .HasForeignKey(i => i.PostId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<LikedPosts>(i =>
            {
                i.Property(p => p.Id)
                .ValueGeneratedOnAdd();

                i.HasOne(i => i.Fan)
                .WithMany(i => i.LikedPosts)
                .HasForeignKey(i => i.FanId)
                .OnDelete(DeleteBehavior.Cascade);

                i.HasOne(i => i.Post);

            });

            modelBuilder.Entity<SavedPosts>(i =>
            {
                i.Property(p => p.Id)
                .ValueGeneratedOnAdd();

                i.HasOne(i => i.Fan)
                .WithMany(i => i.SavedPosts)
                .HasForeignKey(i => i.FanId)
                .OnDelete(DeleteBehavior.Cascade);

                i.HasOne(i => i.Post);
            });
        }
    }
}
