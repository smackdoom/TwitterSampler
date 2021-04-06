using System;
using Microsoft.EntityFrameworkCore;
using TwitterSampler.Models.Data;

namespace TwitterSampler.Data
{
    public class TwitterDbContext : DbContext
    {
        public TwitterDbContext(DbContextOptions<TwitterDbContext> options) : base(options) { }

        public DbSet<Emoji> Emoji { get; set; }
        public DbSet<HashTag> HashTag { get; set; }
        public DbSet<Tweet> Tweet { get; set; }
        public DbSet<Url> Url { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Emoji>(entity =>
            {
                entity.Property(e => e.EmojiId)
                    .IsRequired()
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<HashTag>(entity =>
            {
                entity.Property(e => e.HashTagId)
                    .IsRequired()
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Url>(entity =>
            {
                entity.Property(e => e.UrlId)
                    .IsRequired()
                    .ValueGeneratedOnAdd();
            });
        }
    }
}
