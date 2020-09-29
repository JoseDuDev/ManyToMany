using ManyToMany.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManyToMany.Data
{
    public class ManyToManyContext : DbContext
    {
        public ManyToManyContext(DbContextOptions<ManyToManyContext> options) : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostTag>().HasKey(pt => new { pt.PostId, pt.TagId });

            modelBuilder.Entity<PostTag>()
                .HasOne(pt => pt.Post)
                .WithMany(pt => pt.PostTags)
                .HasForeignKey(p => p.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PostTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(pt => pt.PostTags)
                .HasForeignKey(p => p.TagId);
        }
    }
}
