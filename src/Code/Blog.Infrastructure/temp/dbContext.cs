using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Blog.Infrastructure.temp
{
    public partial class dbContext : DbContext
    {
        public dbContext()
        {
        }

        public dbContext(DbContextOptions<dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<PostCategory> PostCategories { get; set; } = null!;
        public virtual DbSet<PostComment> PostComments { get; set; } = null!;
        public virtual DbSet<PostMeta> PostMetas { get; set; } = null!;
        public virtual DbSet<Schemaversion> Schemaversions { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=192.168.1.62;Port=9988;Database=postgres;User Id=postgres;Pwd=77cb799O8;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories", "blog");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.MetaTitle)
                    .HasMaxLength(100)
                    .HasColumnName("meta_title");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.Slug)
                    .HasMaxLength(100)
                    .HasColumnName("slug");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("posts", "blog");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.AuthorId).HasColumnName("author_id");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.MetaTitle)
                    .HasMaxLength(100)
                    .HasColumnName("meta_title");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.Published).HasColumnName("published");

                entity.Property(e => e.PublishedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("published_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Slug)
                    .HasMaxLength(100)
                    .HasColumnName("slug");

                entity.Property(e => e.Summary).HasColumnName("summary");

                entity.Property(e => e.Title)
                    .HasMaxLength(75)
                    .HasColumnName("title");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("now()");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_blogposts_author_id");
            });

            modelBuilder.Entity<PostCategory>(entity =>
            {
                entity.ToTable("post_categories", "blog");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.PostCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_blogpostcategory_category");
            });

            modelBuilder.Entity<PostComment>(entity =>
            {
                entity.ToTable("post_comments", "blog");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.Property(e => e.Published).HasColumnName("published");

                entity.Property(e => e.PublishedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("published_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .HasColumnName("title");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostComments)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_blogpostcomments_post");
            });

            modelBuilder.Entity<PostMeta>(entity =>
            {
                entity.ToTable("post_metas", "blog");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.MetaKey)
                    .HasMaxLength(100)
                    .HasColumnName("meta_key");

                entity.Property(e => e.MetaValue).HasColumnName("meta_value");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostMeta)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_blogpostmeta_post");
            });

            modelBuilder.Entity<Schemaversion>(entity =>
            {
                entity.HasKey(e => e.Schemaversionsid)
                    .HasName("PK_schemaversions_Id");

                entity.ToTable("schemaversions");

                entity.Property(e => e.Schemaversionsid).HasColumnName("schemaversionsid");

                entity.Property(e => e.Applied)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("applied");

                entity.Property(e => e.Scriptname)
                    .HasMaxLength(255)
                    .HasColumnName("scriptname");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users", "blog");

                entity.HasIndex(e => e.Email, "uq_blogusers_email")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("first_name")
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsAdmin).HasColumnName("is_admin");

                entity.Property(e => e.LastLogin)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("last_login");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("last_name")
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(32)
                    .HasColumnName("password_hash");

                entity.Property(e => e.RegisteredAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("registered_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
