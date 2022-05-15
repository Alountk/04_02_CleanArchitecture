using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Blog.Core.Entities;

namespace Blog.Infrastructure.Data
{
    public partial class BlogDbContext : DbContext
    {
        public BlogDbContext()
        {
        }

        public BlogDbContext(DbContextOptions<BlogDbContext> options)
            : base(options)
        {
        }

        // public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        // public virtual DbSet<PostCategory> PostCategories { get; set; } = null!;
        // public virtual DbSet<PostComment> PostComments { get; set; } = null!;
        // public virtual DbSet<PostMeta> PostMetas { get; set; } = null!;
        // public virtual DbSet<Schemaversion> Schemaversions { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogDbContext).Assembly);
            // modelBuilder.Entity<Schemaversion>(entity =>
            // {
            //     entity.HasKey(e => e.Schemaversionsid)
            //         .HasName("PK_schemaversions_Id");

            //     entity.ToTable("schemaversions");

            //     entity.Property(e => e.Schemaversionsid).HasColumnName("schemaversionsid");

            //     entity.Property(e => e.Applied)
            //         .HasColumnType("timestamp without time zone")
            //         .HasColumnName("applied");

            //     entity.Property(e => e.Scriptname)
            //         .HasMaxLength(255)
            //         .HasColumnName("scriptname");
            // });
        }
    }
}
